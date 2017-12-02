using System.Collections.Generic;
using System.Linq;
using BeeGraph.Core.Domain;
using BeeGraph.Infrastructure.Monads;

namespace BeeGraph.Core
{
    public class UserDialog
    {
        private readonly StatefulDialog _statefulDialog;

        private const string DefaultAnswer = "Ooops! There is no such option..";

        public UserDialog(StatefulDialog statefulDialog)
        {
            _statefulDialog = statefulDialog;
        }

        public (string response, IEnumerable<Edge> options) Talk(string message)
        {
            return _statefulDialog.Talk(message).Match(
                ifJust: ParseNode,
                ifNothing: () => (DefaultAnswer, Enumerable.Empty<Edge>()));
        }

        public static (string response, IEnumerable<Edge> options) ParseNode(Node n) =>
            (n.Body, GetNodeOptioins(n));

        private static IEnumerable<Edge> GetNodeOptioins(Node n) =>
            n.OutEdges;
    }
}
