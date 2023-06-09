using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace egyszemelyes_2
{
    public class State : ICloneable
    {
        public static Cell[,] table =
        {
            { new Cell(new List<Direction>{Direction.DOWN, Direction.DOWNRIGHT }, Shape.NONE),
              new Cell(new List<Direction>{ Direction.DOWN}, Shape.SQUARE),
              new Cell(new List<Direction>{Direction.LEFT, Direction.RIGHT}, Shape.NONE),
              new Cell(new List<Direction>{ Direction.DOWNLEFT}, Shape.CIRCLE),
              new Cell(new List<Direction>{Direction.LEFT }, Shape.NONE)},

            { new Cell(new List<Direction>{Direction.UP, Direction.DOWN }, Shape.SQUARE), 
              new Cell(new List<Direction>{ Direction.DOWN, Direction.UPRIGHT}, Shape.SQUARE),
              new Cell(new List<Direction>{ }, Shape.GOAL),
              new Cell(new List<Direction>{Direction.LEFT, Direction.DOWNLEFT }, Shape.NONE),
              new Cell(new List<Direction>{Direction.LEFT, Direction.DOWN }, Shape.NONE)},

            { new Cell(new List<Direction>{Direction.UP, Direction.DOWN }, Shape.NONE),
              new Cell(new List<Direction>{Direction.RIGHT }, Shape.NONE),
              new Cell(new List<Direction>{Direction.UPLEFT, Direction.DOWNRIGHT }, Shape.NONE),
              new Cell(new List<Direction>{Direction.UP, Direction.DOWNLEFT, Direction.DOWNRIGHT }, Shape.NONE),
              new Cell(new List<Direction>{Direction.UP }, Shape.NONE )},

            { new Cell(new List<Direction>{ Direction.UP, Direction.RIGHT}, Shape.NONE),
              new Cell(new List<Direction>{Direction.UPRIGHT, Direction.RIGHT }, Shape.NONE),
              new Cell(new List<Direction>{Direction.RIGHT, Direction.DOWNRIGHT }, Shape.NONE),
              new Cell(new List<Direction>{Direction.UPLEFT, Direction.DOWNRIGHT}, Shape.NONE),
              new Cell(new List<Direction>{Direction.UP, }, Shape.CIRCLE)},

            { new Cell(new List<Direction>{ Direction.RIGHT}, Shape.SQUARE), new Cell(new List<Direction>{ Direction.LEFT, Direction.RIGHT}, Shape.NONE),new Cell(new List<Direction>{Direction.LEFT, Direction.UPRIGHT }, Shape.START),new Cell(new List<Direction>{ Direction.UP, Direction.UPRIGHT}, Shape.NONE),new Cell(new List<Direction>{Direction.UP}, Shape.CIRCLE)},

        };

        int x, y;
        int moveCount;

        public State()
        {
            X = 4;
            Y = 2;
            moveCount = 1;
        }

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public int MoveCount { get => moveCount; set => moveCount = value; }

        public object Clone()
        {
            State newState = new State();
            newState.x = X;
            newState.y = Y;
            newState.MoveCount = MoveCount;
            return newState;
        }

        public bool IsTargetReached()
        {
            return X == 1 && Y == 2;
        }

        public override bool Equals(object? obj)
        {
            if (obj is not null && obj is State other)
            {
                return other.X == this.X &&
                       other.Y == this.Y &&
                       other.MoveCount == this.MoveCount;
            }

            return false;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < table.GetLength(0); i++)
            {
                
                for (int j = 0; j < 3; j++)
                {
                    StringBuilder line = new StringBuilder();
                    for (int k = 0; k < table.GetLength(1); k++)
                    {
                        line.Append(table[i, k].ToString().Split('\n')[j].TrimEnd('\r'));

                        if (j == 1 && X == i && Y == k)
                        {
                            line = line.Remove(GetIndexForInsert(k), 1).Insert(GetIndexForInsert(k), "P");
                        }
                    }
                    sb.AppendLine(line.ToString());
                }
                sb.AppendLine();

            }

            sb.AppendLine($"Can step: {moveCount} cells");

            return sb.ToString();
        }

        private int GetIndexForInsert(int k) => k switch
        {
            0 => 4,
            1 => 13,
            2 => 22,
            3 => 31,
            4 => 40
        };
    }
}
