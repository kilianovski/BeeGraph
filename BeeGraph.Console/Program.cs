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
            var factory = IoC.IoC.Container.GetInstance<IDialogProvider>();
            var graph = factory.GetDialog();
            var dialog = new UserDialog(new StatefulDialog(graph));

            while (true)
            {
                var userMessage = ReadLine();
                var response = dialog.Talk(userMessage);
                System.Console.WriteLine(response);
            }

        }
    }
}
