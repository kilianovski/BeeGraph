﻿using System;
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
                Console.WriteLine(response.Value.Body);                
            }
        }
    }

    internal class NodeBuilder
    {
        public static NodeBuilder Instance => new NodeBuilder();

        private int _counter = 0;

        public Node NewNode(string name) => new Node(_counter++, name);
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

                var fromHomeToJoke = new Edge(0, "joke", home, joke);
                var fromHomeToAbout = new Edge(1, "about", home, about);
                var fromJokeToHome = new Edge(2, "home", home, home);

                var nodes = new[]
                {
                    home,
                    joke,
                    about
                };

                var edges = new[]
                {
                    fromHomeToJoke,
                    fromHomeToAbout,
                    fromJokeToHome
                };

                var result = new DialogGraph(nodes, edges);
                return result;
            }
        }
    }
}
