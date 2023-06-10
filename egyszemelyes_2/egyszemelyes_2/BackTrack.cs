using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace egyszemelyes_2
{
    internal class BackTrack : Solver
    {
        Stack<Node> route = new Stack<Node>();
        int depthLimit = 26;
        Node currentNode;
        Node path;
        State state;
        public BackTrack(State state)
        {
            this.state = state;
            Solve();
        }
        void Solve()
        {
            route.Push(new Node(state, null));
            while (route.Count > 0 && !route.Peek().State.IsTargetReached())
            {
                currentNode = route.Peek();
                if (Operators.Count > currentNode.Index && currentNode.Depth < depthLimit)
                {
                    Operator currentOperator = Operators[currentNode.Index];
                    if (currentOperator.IsExistingState(currentNode.State))
                    {
                        State newState = currentOperator.ApplyOperator(currentNode.State);
                        Node newNode = new Node(newState, currentNode);
                        if (!route.Contains(newNode))
                        {
                            route.Push(newNode);
                        }
                    }
                    currentNode.Index++;
                }
                else
                {
                    route.Pop();
                }
            }

            if (route.Count > 0)
            {
                path = route.Peek();
                Display(path.ToString());
                Console.WriteLine($"\nSteps: {path.Depth}");

                Console.WriteLine("\nPress enter to exit!");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Failed to find path!");
            }
        }

        private void Display(string text)
        {
            string[] states = text.Split("DIVIDER");

            Console.WriteLine("Solution found!");
            Console.WriteLine("Press enter to cycle through the states!");

            foreach (string state in states)
            {
                Console.ReadLine();
                Console.Clear();
                foreach (char item in state)
                {
                    switch(item)
                    {
                        case 'P':
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;

                        case Program.LEFTARROW:
                        case Program.RIGHTARROW:
                        case Program.UPARROW:
                        case Program.DOWNARROW:
                        case Program.UPLEFTARROW:
                        case Program.UPRIGHTARROW:
                        case Program.DOWNLEFTARROW:
                        case Program.DOWNRIGHTARROW:
                            Console.ForegroundColor = ConsoleColor.Blue;
                            break;

                        case 'G':    
                        case 'S':
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            break;

                        case Program.SQUARE:
                        case Program.CIRCLE:
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;

                        default:
                            Console.ForegroundColor = ConsoleColor.Gray;
                            break;
                    }

                    Console.Write(item);
                }
            }
        }
    }
}
