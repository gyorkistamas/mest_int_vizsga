using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace egyszemélyes
{
    public class State : ICloneable
    {
        public const int TABLE_X_LENGTH = 5;
        public const int TABLE_Y_LENGTH = 5;

        private int[,] table;

        public int[,] Table { get => table; set => table = value; }

        public State()
        {
            Table =new int[TABLE_X_LENGTH, TABLE_Y_LENGTH]
            {
                { 01, 22, 12, 04, 19 },
                { 14, 17, 11, 09, 08 },
                { 18, 07, 02, 13, 05 },
                { 20, 16, 10, 24, 25 },
                { 21, 15, 23, 03, 06 }
            };

        }

        public State(int[,] table) : this()
        {
            if (table.GetLength(0) != TABLE_X_LENGTH ||
                table.GetLength(1) != TABLE_Y_LENGTH) 
            {
                throw new Exception($"A {TABLE_X_LENGTH}x{TABLE_Y_LENGTH} matrix is required!");
            }

            for (int i = 0; i < this.Table.GetLength(0); i++)
            {
                for (int j = 0; j < this.Table.GetLength(1); j++)
                {
                    this.Table[i, j] = table[i, j];
                }
            }
        }

        public bool IsTargetState()
        {
            int i = 0;
            foreach (int number in Table)
            {
                i++;
                if (number != i)
                    return false;
            }

            return true;
        }

        public object Clone()
        {
            return new State(this.Table);
        }

        public override string ToString()
        {
            StringBuilder sr = new StringBuilder();

            for (int i = 0; i < this.Table.GetLength(1) * 4 + this.Table.GetLength(1) + 1; i++)
            {
                sr.Append("-");
            }
            sr.Append('\n');

            for (int i = 0; i < this.Table.GetLength(0); i++)
            {
                sr.Append("| ");
                for (int j = 0; j < this.Table.GetLength(1); j++)
                {
                    sr.Append($"{this.Table[i,j].ToString().PadLeft(2)} | ");
                }
                sr.Append('\n');
            }


            for (int i = 0; i < this.Table.GetLength(1) * 4 + this.Table.GetLength(1) + 1; i++)
            {
                sr.Append("-");
            }
            sr.Append('\n');

            return sr.ToString();
        }

        public override bool Equals(object? obj)
        {
            if (obj is null || obj is not State)
                return false;

            State other = obj as State;

            for (int i = 0; i < TABLE_X_LENGTH; i++)
            {
                for (int j = 0; j < TABLE_Y_LENGTH; j++)
                {
                    if (this.Table[i, j] != other.Table[i, j])
                        return false;
                }
            }

            return true;
        }
    }
}
