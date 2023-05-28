using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O5PP4S_mestint_szorgalmi
{
    internal class State : ICloneable
    {
        char[,] table = { {' ', ' ', ' '},
                          {' ', ' ', ' '},
                          {' ', ' ', ' '}};

        public char[,] Table { get => table; set => table = value; }

        public bool IsTargetState(char item)
        {
            int count = 0;

            for (int i = 0; i < Table.GetLength(0); i++)
            {
                for (int j = 0; j < Table.GetLength(1); j++)
                {
                    if (Table[i, j] == item)
                    {
                        count++;
                    }
                    else
                    {
                        count = 0;
                        break;
                    }
                }

                if (count == 3)
                    return true;

                for (int j = 0; j < Table.GetLength(1); j++)
                {
                    if (Table[j, i] == item)
                    {
                        count++;
                    }
                    else
                    {
                        count = 0;
                        break;
                    }
                }

                if (count == 3)
                    return true;

            }

            for (int i = 0; i < Table.GetLength(1); i++)
            {
                if (Table[i, i] == item)
                {
                    count++;
                }
                else
                {
                    count = 0;
                    break;
                }
            }

            if (count == 3)
                return true;

            for (int i = Table.GetLength(1) - 1; i >= 0; i--)
            {
                if (Table[i, 2 - i] == item)
                {
                    count++;
                }
                else
                {
                    count = 0;
                    break;
                }
            }

            if (count == 3)
                return true;

            return false;
        }

        public bool IsDraw()
        {
            if (IsTargetState('X') || IsTargetState('O'))
            {
                return false;
            }

            for (int i = 0; i < Table.GetLength(0); i++)
            {
                for (int j = 0; j < Table.GetLength(1); j++)
                {
                    if (Table[i, j] == ' ')
                    {
                        return false;
                    }
                }
            }

            return true;
        }


        public override string ToString()
        {
            string value = "-----------------\n";

            for (int i = 0; i < Table.GetLength(0); i++)
            {
                for (int j = 0; j < Table.GetLength(1); j++)
                {
                    value += $" {Table[i, j]}  | ";
                }
                value += "\n-----------------\n";
            }

            return value;
        }

        public object Clone()
        {
            State newState = new State();

            for (int i = 0; i < this.Table.GetLength(0); i++)
            {
                for (int j = 0; j < this.Table.GetLength(1); j++)
                {
                    newState.Table[i, j] = this.Table[i, j];
                }
            }

            return newState;
        }
    }
}
