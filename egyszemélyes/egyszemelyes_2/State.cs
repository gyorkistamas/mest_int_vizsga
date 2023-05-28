using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace egyszemelyes_2
{
    internal class State
    {
        private static char[,] table = new char[8, 8]
            {
                { 'S', ' ', ' ', ' ', 'O', ' ', ' ', ' ' },
                { ' ', ' ', 'O', ' ', ' ', ' ', 'O', ' ' },
                { ' ', ' ', 'W', ' ', ' ', ' ', ' ', 'W' },
                { ' ', ' ', 'O', ' ', 'O', ' ', ' ', ' ' },
                { 'O', 'W', ' ', 'O', ' ', ' ', ' ', 'O' },
                { ' ', ' ', ' ', 'O', ' ', 'W', 'O', ' ' },
                { ' ', ' ', 'O', ' ', ' ', ' ', ' ', 'O' },
                { 'O', ' ', ' ', 'W', ' ', ' ', ' ', 'C' },
            };

        private Position playerPosition;
        private int moveCount;
        public Position PlayerPosition { get => playerPosition; set => playerPosition = value; }
        public static char[,] Table { get => table; }
        public int MoveCount { get => moveCount; set => moveCount = value; }

        public State(int x, int y, int moveCount)
        {
            this.PlayerPosition = new Position(0, 0);
            this.MoveCount = moveCount;
        }

        public bool IsTargetReached()
        {
            return this.PlayerPosition.X == 7 && this.PlayerPosition.Y == 7;
        }

        public object Clone()
        {
            return new State(this.PlayerPosition.X, this.PlayerPosition.Y, this.MoveCount);
        }

        public void ChangeMoveCount()
        {
            if (this.MoveCount == 2)
            {
                this.MoveCount = 3;
            }
            else
            {
                this.MoveCount = 2;
            }

        }

        public override string ToString()
        {
            StringBuilder sr = new StringBuilder();

            for (int i = 0; i < Table.GetLength(1) * 3 + Table.GetLength(1) + 1; i++)
            {
                sr.Append("-");
            }
            sr.Append('\n');

            for (int i = 0; i < Table.GetLength(0); i++)
            {
                sr.Append("| ");
                for (int j = 0; j < Table.GetLength(1); j++)
                {
                    if (i == this.PlayerPosition.X && j == this.PlayerPosition.Y)
                    {
                        sr.Append($"P | ");
                    }
                    else
                    {
                        sr.Append($"{Table[i, j]} | ");
                    }
                }
                sr.Append('\n');
                for (int j = 0; j < Table.GetLength(1) * 3 + Table.GetLength(1) + 1; j++)
                {
                    sr.Append("-");
                }
                sr.Append('\n');
            }

            return sr.ToString();
        }

        public override bool Equals(object? obj)
        {
            if (obj is null || obj is not State)
                return false;

            State other = obj as State;

            return this.PlayerPosition.Equals(other.PlayerPosition) && this.MoveCount.Equals(other.MoveCount);
        }
    }
}
