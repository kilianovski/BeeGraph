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

        public string Talk(string message)
        {
            return _statefulDialog.Talk(message).Match(
                ifJust: n => n.Body,
                ifNothing: () => DefaultAnswer);
        }
    }
}
