using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O5PP4S_mestint_szorgalmi
{
    internal class MiniMax : Solver
    {
        State currentState;

        int maxDepth;


        public MiniMax(State state, int maxDepth)
        {
            this.currentState = state;
            this.maxDepth = maxDepth;
        }


        public void Play()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(currentState);
                Operator playerMove = null;
                do
                {
                    int num = -1;

                    do
                    {
                        Console.Write("Your move (1-9): ");
                    } while (!int.TryParse(Console.ReadLine(), out num) || num < 1 || num > 9);

                    playerMove = new Operator(num, 'X');

                } while (!playerMove.IsExistingState(currentState));

                currentState = playerMove.ApplyState(currentState, 'X');

                if (currentState.IsTargetState('X'))
                {
                    Console.Clear();
                    Console.WriteLine(currentState);
                    Console.WriteLine("Player won!");
                    break;
                }
                else if (currentState.IsDraw())
                {
                    Console.Clear();
                    Console.WriteLine(currentState);
                    Console.WriteLine("Draw");
                    break;
                }


                Console.WriteLine(currentState);

                Console.WriteLine("Computer moves!");

                currentState = NextState();

                //Console.WriteLine(currentState);

                if (currentState.IsTargetState('O'))
                {
                    Console.Clear();
                    Console.WriteLine(currentState);
                    Console.WriteLine("Computer won!");
                    break;
                }
                else if (currentState.IsDraw())
                {
                    Console.Clear();
                    Console.WriteLine(currentState);
                    Console.WriteLine("Draw");
                    break;
                }


            }
        }

        private State NextState()
        {
            Node start = new Node(this.currentState.Clone() as State, 0, 'O');

            GenerateTree(start);

            Node nextStateNode = null;

            foreach (var item in start.Children)
            {
                if (nextStateNode is null || item.Weight() > nextStateNode.Weight())
                {
                    nextStateNode = item;
                }
            }

            return nextStateNode.State;
        }

        private void GenerateTree(Node node)
        {

            if (node.Depth > maxDepth || node.State.IsDraw() ||
                node.State.IsTargetState('X') ||
                node.State.IsTargetState('O'))
            {
                return;
            }

            List<Operator> applicableOperators = ApplicableOperators(node.State, node.NextPlayerChar);

            foreach (Operator op in applicableOperators)
            {
                State newState = op.ApplyState(node.State, node.NextPlayerChar);

                Node newNode = new Node(newState, node.Depth + 1, node.NextPlayerChar == 'X' ? 'O' : 'X');

                node.Children.Add(newNode);
            }

            foreach (Node item in node.Children)
            {
                GenerateTree(item);
            }

            return;
        }
    }
}
