using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ketszemelyes_2
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

                DisplayTable();

                Operator playerMove = GetOperatorFromPlayer();
                
                currentState = playerMove.ApplyOperator(currentState);

                if (currentState.IsTargetState(State.PLAYER_COLOR))
                {
                    Console.Clear();
                    DisplayTable();
                    Console.WriteLine("Player won!");
                    break;
                }
                else if (currentState.IsTargetState(State.CPU_COLOR))
                {
                    Console.Clear();
                    DisplayTable();
                    Console.WriteLine("CPU WON!");
                    break;
                }


                DisplayTable();

                currentState = NextState();

                //Console.WriteLine(currentState);

                if (currentState.IsTargetState(State.PLAYER_COLOR))
                {
                    Console.Clear();
                    DisplayTable();
                    Console.WriteLine("Player won!");
                    break;
                }
                else if (currentState.IsTargetState(State.CPU_COLOR))
                {
                    Console.Clear();
                    DisplayTable();
                    Console.WriteLine("CPU WON!");
                    break;
                }
            }
        }

        private State NextState()
        {
            Node start = new Node(this.currentState.Clone() as State, 0);

            GenerateTree(start);

            Node nextStateNode = null;

            foreach (var item in start.Children)
            {
                if (nextStateNode is null || item.Weight() > nextStateNode.Weight())
                {
                    nextStateNode = item;
                }
            }

            start = null;

            return nextStateNode.State;
        }

        private void GenerateTree(Node node)
        {

            if (node.Depth > maxDepth                              ||
                node.State.IsTargetState(State.PLAYER_COLOR) ||
                node.State.IsTargetState(State.CPU_COLOR))
            {
                return;
            }

            List<Operator> applicableOperators = ApplicableOperators(node.State, node.State.PlayerToMove);

            foreach (Operator op in applicableOperators)
            {
                State newState = op.ApplyOperator(node.State);

                Node newNode = new Node(newState, node.Depth + 1);

                node.Children.Add(newNode);
            }

            foreach (Node item in node.Children)
            {
                GenerateTree(item);
            }

            return;
        }

        private Operator GetOperatorFromPlayer()
        {
            Operator op = null;

            do
            {
                int toX = 0;
                char toY;
                do
                {
                    Console.Write("ToX: ");
                } while (!int.TryParse(Console.ReadLine(), out toX));

                Console.Write("ToY: ");
                toY = (char)Console.ReadLine()[0];

                op = new Operator(toX, toY, State.PLAYER_COLOR);
            } while (!op.IsExistingState(currentState));

            return op;
        }

        private void DisplayTable()
        {
            Console.Clear();
            foreach (char item in currentState.ToString())
            {
                switch (item)
                {
                    case 'B':
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        break;
                    case 'R':
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
