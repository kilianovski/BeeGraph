using System;
using System.Collections.Generic;
using System.Linq;
using BeeGraph.Core;
using BeeGraph.Domain;

namespace BeeGraph
{
    class Program
    {
        static void Main(string[] args)
        {
            var dialog = new BeeGraphDialog(TestData.TestGraph);

            while (true)
            {
                var userResponse = Console.ReadLine();
                var response = dialog.Talk(userResponse);
                Console.WriteLine(response.Body);

                foreach (var edge in response.Edges)
                {
                    Console.WriteLine(edge.Body);
                    foreach (var edgeKey in edge.Keys)
                    {
                        Console.WriteLine(edgeKey);
                    }

                }
            }
            Console.WriteLine("Hello World!");
        }

        
    }

    internal class NodeBuilder
    {
        public static NodeBuilder Instance => new NodeBuilder();

        private int _counter = 0;

        public Node NewNode(string name) => new Node(_counter++, name, Enumerable.Empty<Edge>());
    }

    public static class TestData
    {
        public static DialogGraph TestGraph
        {
            get
            {
                var nodeBuilder = NodeBuilder.Instance;

                var home = nodeBuilder.NewNode("Home");
                var joke = nodeBuilder.NewNode("Joke");
                var about = nodeBuilder.NewNode("About");

                var fromHomeToJoke = new Edge(0, "To the joke!", new[] { "1", "joke" }, joke);
                home.WithNewEdge(fromHomeToJoke);

                var fromHomeToAbout = new Edge(1, "About", new[] { "2", "about" }, about);
                home.WithNewEdge(fromHomeToAbout);

                var fromJokeToHome = new Edge(2, "Home", new[] { "3", "home" }, home);
                joke.WithNewEdge(fromJokeToHome);

                var result = new DialogGraph(new []
                {
                    home,
                    joke,
                    about
                });

                return result;
            }
        }
    }
}
