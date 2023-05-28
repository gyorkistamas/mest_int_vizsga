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
        int depthLimit = 8;
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
                string pathString = path.ToString();

                foreach(char character in pathString)
                {
                    switch (character)
                    {
                        case '|':
                        case '-':
                            Console.ForegroundColor = ConsoleColor.White;
                            break;

                        case 'W':
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                        case 'O':
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            break;

                        case 'P':
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;

                        case 'C':
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            break;

                        case 'S':
                            Console.ForegroundColor = ConsoleColor.White;
                            break;

                        default:
                            Console.ForegroundColor = ConsoleColor.Gray;
                            break;
                    }

                    Console.Write(character);
                }


                Console.WriteLine($"Steps: {path.Depth}");
            }
            else
            {
                Console.WriteLine("Failed to find path!");
            }
        }
    }
}
