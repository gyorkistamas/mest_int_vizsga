using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ketszemelyes_2
{
    public class State : ICloneable
    {
        public const int ROW_COUNT = 5;
        public const int COLUMN_COUNT = 5;
        public const char PLAYER_COLOR = 'B';
        public const char CPU_COLOR = 'R';

        private char[,] table;
        private char playerToMove;

        public State()
        {
            Table = new char[ROW_COUNT, COLUMN_COUNT];
            PlayerToMove = 'B';
        }

        public char[,] Table { get => table; set => table = value; }
        public char PlayerToMove { get => playerToMove; set => playerToMove = value; }

        public void SetStartingState()
        {
            Table = new char[ROW_COUNT, COLUMN_COUNT]
            {
                { ' ', ' ', ' ', ' ', ' '},
                { ' ', ' ', ' ', ' ', ' '},
                { ' ', ' ', ' ', ' ', ' '},
                { ' ', ' ', ' ', ' ', ' '},
                { ' ', ' ', ' ', ' ', ' '},
            };
        }

        public bool IsTargetState(char player)
        {
            char enemy = player == 'B' ? 'R' : 'B';

            for (int i = 0; i < ROW_COUNT; i++)
            {
                for (int j = 0; j < COLUMN_COUNT; j++)
                {
                    if (table[i, j] == enemy && HasSameNeighbour(i, j, enemy))
                        return true;
                }
            }

            return false;
        }

        public bool IsDraw()
        {
            foreach (var item in table)
            {
                if (item == ' ')
                    return false;
            }
            return true;
        }


        private bool HasSameNeighbour(int x, int y, char enemy)
        {
            int upX = x - 1, upY = y;

            int leftX = x, leftY = y - 1;

            int rightX = x, rightY = y + 1;

            int downX = x + 1, downY = y;

            if (InsideTheTable(upX, upY) && table[upX, upY] == enemy)
            {
                return true;
            }

            if (InsideTheTable(leftX, leftY) && table[leftX, leftY] == enemy)
            {
                return true;
            }

            if (InsideTheTable(downX, downY) && table[downX, downY] == enemy)
            {
                return true;
            }

            if (InsideTheTable(rightX, rightY) && table[rightX, rightY] == enemy)
            {
                return true;
            }

            return false;
        }

        private bool InsideTheTable(int x, int y)
        {
            return x >= 0 && x < ROW_COUNT   &&
                   y >= 0 && y < COLUMN_COUNT;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null || obj is not State)
                return false;

            State other = obj as State;

            for (int i = 0; i < ROW_COUNT; i++)
            {
                for (int j = 0; j < COLUMN_COUNT; j++)
                {
                    if (this.Table[i, j] != other.Table[i, j])
                        return false;
                }
            }

            return true;
        }

        public override string ToString()
        {
            StringBuilder sr = new StringBuilder();

            for (int i = 0; i < COLUMN_COUNT * 5; i++)
            {
                sr.Append("-");
            }

            sr.Append('\n');

            for (int i = 0; i < ROW_COUNT; i++)
            {
                sr.Append($"{i + 1}   ");
                for (int j = 0; j < COLUMN_COUNT; j++)
                {
                    sr.Append($"| {this.Table[i, j]} ");
                }
                sr.Append("| \n");

                for (int j = 0; j < COLUMN_COUNT * 5; j++)
                {
                    sr.Append("-");
                }
                sr.AppendLine();
            }

            sr.AppendLine("    | a | b | c | d | e ");

            return sr.ToString();
        }

        public object Clone()
        {
            State newState = new State();

            for (int i = 0; i < ROW_COUNT; i++)
            {
                for (int j = 0; j < COLUMN_COUNT; j++)
                {
                    newState.Table[i, j] = this.Table[i, j];
                }
            }

            newState.PlayerToMove = this.PlayerToMove;

            return newState;
        }
    }
}
