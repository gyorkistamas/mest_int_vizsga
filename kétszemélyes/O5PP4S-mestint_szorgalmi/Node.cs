using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O5PP4S_mestint_szorgalmi
{
    internal class Node
    {
        List<Node> children = new List<Node>();

        int depth;

        State state;

        char nextPlayerChar;

        public List<Node> Children { get => children; set => children = value; }
        public State State { get => state; set => state = value; }
        public int Depth { get => depth; set => depth = value; }
        public char NextPlayerChar { get => nextPlayerChar; set => nextPlayerChar = value; }


        public Node(State state, int depth, char nextPlayerChar)
        {
            this.State = state.Clone() as State;
            this.Depth = depth;
            this.NextPlayerChar = nextPlayerChar;
        }

        public int Weight()
        {
            if (this.children.Count == 0)
            {
                return CalculateWeightForEndNode();
            }

            int value = 0;

            if (nextPlayerChar == 'X')
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

            if (this.State.IsDraw())
            {
                return 0;
            }

            if (this.State.IsTargetState('O'))
            {
                return 10;
            }

            if (this.state.IsTargetState('X'))
            {
                return -10;
            }

            int weight = 0;

            for (int i = 0; i < State.Table.GetLength(0); i++)
            {
                bool rowHasO = false;
                bool rowHasX = false;
                for (int j = 0; j < State.Table.GetLength(1); j++)
                {

                    if (State.Table[i, j] == 'O')
                    {
                        rowHasO = true;
                    }

                    if (State.Table[i, j] == 'X')
                    {
                        rowHasX = true;
                    }

                    if (rowHasX && rowHasO)
                    {
                        weight++;
                        break;
                    }
                }
            }

            for (int i = 0; i < State.Table.GetLength(1); i++)
            {
                bool columnHasO = false;
                bool colunmHasX = false;
                for (int j = 0; j < State.Table.GetLength(0); j++)
                {
                    if (State.Table[j, i] == 'O')
                    {
                        columnHasO = true;
                    }

                    if (State.Table[j, i] == 'X')
                    {
                        colunmHasX = true;
                    }

                    if (columnHasO && colunmHasX)
                    {
                        weight++;
                        break;
                    }
                }
            }


            bool diagonalHasX = false;
            bool diagonalHasO = false;
            for (int i = 0; i < State.Table.GetLength(0); i++)
            {
                if (State.Table[i, i] == 'O')
                {
                    diagonalHasO = true;
                }
                if (State.Table[i, i] == 'X')
                {
                    diagonalHasX = true;
                }
            }

            if (diagonalHasO && diagonalHasX)
            {
                weight++;
            }


            bool sideDiagonalHasX = false;
            bool sideDiagonalHasO = false;
            for (int i = 0; i < State.Table.GetLength(0); i++)
            {
                if (State.Table[i, State.Table.GetLength(0) - i - 1] == 'O')
                {
                    sideDiagonalHasO = true;
                }

                if (State.Table[i, State.Table.GetLength(0) - i - 1] == 'X')
                {
                    sideDiagonalHasX = true;
                }
            }

            if (sideDiagonalHasO && sideDiagonalHasX)
            {
                weight++;
            }

            return weight;
        }
    }
}
