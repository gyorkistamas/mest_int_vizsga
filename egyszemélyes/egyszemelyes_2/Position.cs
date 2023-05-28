using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace egyszemelyes_2
{
    internal class Position : ICloneable
    {
        private int x, y;

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }

        public object Clone()
        {
            return new Position(X, Y);
        }

        public override bool Equals(object? obj)
        {
            if (obj is null || obj is not Position)
                return false;

            Position other = obj as Position;

            return other.X == X && other.Y == Y;
        }
    }
}
