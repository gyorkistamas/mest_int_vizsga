using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ketszemelyes_2
{
    internal class Node
    {
        List<Node> children = new List<Node>();

        int depth;

        State state;

        public List<Node> Children { get => children; set => children = value; }
        public State State { get => state; set => state = value; }
        public int Depth { get => depth; set => depth = value; }


        public Node(State state, int depth)
        {
            this.State = state.Clone() as State;
            this.Depth = depth;
        }

        public int Weight()
        {
            if (this.children.Count == 0)
            {
                return CalculateWeightForEndNode();
            }

            int value = 0;

            if (state.PlayerToMove == State.PLAYER_COLOR)
            {
                value = int.MaxValue;

                foreach (Node node in this.children)
                {
                    if (node.Weight() < value)
                    {
                        value = node.Weight();
                    }
                }
            }
            else
            {
                value = int.MinValue;
                foreach (Node node in this.children)
                {
                    if (node.Weight() > value)
                    {
                        value = node.Weight();
                    }
                }
            }

            return value;

        }

        private int CalculateWeightForEndNode()
        {

            if (this.State.IsTargetState(State.CPU_COLOR))
            {
                return 50;
            }

            if (this.state.IsTargetState(State.PLAYER_COLOR))
            {
                return -50;
            }

            if (this.state.IsDraw())
            {
                return 0;
            }

            int weight = 0;


            for (int i = 0; i < State.ROW_COUNT; i++)
            {
                for (int j = 0; j < State.COLUMN_COUNT; j++)
                {

                    if (state.Table[i ,j] == ' ' && !HasSameNeighbour(i, j, State.CPU_COLOR))
                    {
                        weight++;
                    }
                }
            }


            return weight;

        }


        private bool HasSameNeighbour(int x, int y, char enemy)
        {
            int upX = x - 1, upY = y;

            int leftX = x, leftY = y - 1;

            int rightX = x, rightY = y + 1;

            int downX = x + 1, downY = y;

            if (InsideTheTable(upX, upY) && state.Table[upX, upY] == enemy)
            {
                return true;
            }

            if (InsideTheTable(leftX, leftY) && state.Table[leftX, leftY] == enemy)
            {
                return true;
            }

            if (InsideTheTable(downX, downY) && state.Table[downX, downY] == enemy)
            {
                return true;
            }

            if (InsideTheTable(rightX, rightY) && state.Table[rightX, rightY] == enemy)
            {
                return true;
            }

            return false;
        }

        private bool InsideTheTable(int x, int y)
        {
            return x >= 0 && x < State.ROW_COUNT &&
                   y >= 0 && y < State.COLUMN_COUNT;
        }
    }
}
