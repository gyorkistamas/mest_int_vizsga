using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace egyszemelyes_2
{
    public class Cell
    {
        private List<Direction> possibleDirections;
        private Shape shape;

        public Cell(List<Direction> directions, Shape shape)
        {
            PossibleDirections = new List<Direction>(directions);
            this.Shape = shape;
        }

        public List<Direction> PossibleDirections { get => possibleDirections; set => possibleDirections = value; }
        public Shape Shape { get => shape; set => shape = value; }

        public override string ToString()
        {
            StringBuilder sr = new StringBuilder();

            sr.AppendLine($"| {(PossibleDirections.Contains(Direction.UPLEFT) ? Program.UPLEFTARROW : '_')} {(PossibleDirections.Contains(Direction.UP) ? Program.UPARROW : '_')} {(PossibleDirections.Contains(Direction.UPRIGHT) ? Program.UPRIGHTARROW : '_')} |");
            sr.AppendLine($"| {(PossibleDirections.Contains(Direction.LEFT) ? Program.LEFTARROW : '_')} {shape.Write()} {(PossibleDirections.Contains(Direction.RIGHT) ? Program.RIGHTARROW : '_')} |");
            sr.Append($"| {(PossibleDirections.Contains(Direction.DOWNLEFT) ? Program.DOWNLEFTARROW : '_')} {(PossibleDirections.Contains(Direction.DOWN) ? Program.DOWNARROW : '_')} {(PossibleDirections.Contains(Direction.DOWNRIGHT) ? Program.DOWNRIGHTARROW : '_')} |");

            return sr.ToString();
        }
    }
}
