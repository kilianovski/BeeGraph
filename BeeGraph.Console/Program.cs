using System.Collections.Generic;
using System.Linq;
using BeeGraph.Core;
using BeeGraph.Core.Domain;
using BeeGraph.IoC;

using static System.Console;

namespace BeeGraph.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var dialogService = IoC.IoC.Container.GetInstance<IDialogService>();
            var graph = dialogService.GetAll().First();

            var dialog = new UserDialog(new StatefulDialog(graph));

            (var firstResponse, var firstOptions) = UserDialog.ParseNode(graph.StartNode);

            WriteLine(firstResponse);
            PrintOptions(firstOptions);

            while (true)
            {
                var userMessage = ReadLine();
                (var response, var options) = dialog.Talk(userMessage);
                WriteLine(response);
                PrintOptions(options);
            }
        }

        static readonly string Separator = new string('-', 12);

        static void PrintOptions(IEnumerable<Edge> options)
        {
            WriteLine(Separator);
            options.ToList().ForEach(PrintOption);
            WriteLine(Separator);
        }

        private static void PrintOption(Edge e)
        {
            WriteLine($"{e.Key} --- {e.To.Body}");
        }
    }
}
