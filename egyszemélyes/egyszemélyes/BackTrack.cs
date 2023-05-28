using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace egyszemélyes
{
    internal class BackTrack : Solver
    {
        Stack<Node> route = new Stack<Node>();

        List<Node> visitedNodes = new List<Node>();
        int depthLimit = (int)Math.Pow((State.TABLE_ROW_COUNT * State.TABLE_COL_COUNT), 2);
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
                    if (currentOperator.IsExistingState())
                    {
                        State newState = currentOperator.ApplyOperator(currentNode.State);
                        Node newNode = new Node(newState, currentNode);
                        if (!route.Contains(newNode) && !visitedNodes.Contains(newNode))
                        {
                            route.Push(newNode);
                            visitedNodes.Add(newNode);
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
                Console.WriteLine(path);
                Console.WriteLine($"Steps: {path.Depth}");
            }
            else
            {
                Console.WriteLine("Failed to find path!");
            }
        }
    }
}
