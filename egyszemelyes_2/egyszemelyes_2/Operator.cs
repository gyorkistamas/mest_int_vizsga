using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace egyszemelyes_2
{
    public class Operator
    {
        private Direction direction;


        public Operator(Direction direction)
        {
            this.direction = direction;
        }

        public Direction Direction { get => direction; set => direction = value; }

        public bool IsExistingState(State state)
        {
            int toX, toY;

            GetToCoords(state, out toX, out toY);

            return IsInsideTheTable(toX, toY) && CanApplyDirection(state);

        }

        public State ApplyOperator(State state)
        {
            State newState = state.Clone() as State;

            int toX, toY;

            GetToCoords(state, out toX, out toY);

            newState.X = toX;
            newState.Y = toY;

            if (State.table[toX, toY].Shape == Shape.CIRCLE) 
            {
                newState.MoveCount++;
            }
            else if (State.table[toX, toY].Shape == Shape.SQUARE)
            {
                newState.MoveCount--;
            }

            return newState;
        }

        private bool CanApplyDirection(State state)
        {
            return State.table[state.X, state.Y].PossibleDirections.Contains(Direction);
        }

        private bool IsInsideTheTable(int toX, int toY)
        {
            return toX >= 0 && toX < State.table.GetLength(0) &&
                   toY >= 0 && toY < State.table.GetLength(1);
        }

        private void GetToCoords(State state, out int x, out int y)
        {
            switch (direction)
            {
                case Direction.UP:
                    x = state.X - state.MoveCount;
                    y = state.Y;
                    break;
                case Direction.UPRIGHT:
                    x = state.X - state.MoveCount;
                    y = state.Y + state.MoveCount;
                    break;
                case Direction.RIGHT:
                    x = state.X;
                    y = state.Y + state.MoveCount;
                    break;
                case Direction.DOWNRIGHT:
                    x = state.X + state.MoveCount;
                    y = state.Y + state.MoveCount;
                    break;
                case Direction.DOWN:
                    x = state.X + state.MoveCount;
                    y = state.Y;
                    break;
                case Direction.DOWNLEFT:
                    x = state.X + state.MoveCount;
                    y = state.Y - state.MoveCount;
                    break;
                case Direction.LEFT:
                    x = state.X;
                    y = state.Y - state.MoveCount;
                    break;
                case Direction.UPLEFT:
                    x = state.X - state.MoveCount;
                    y = state.Y - state.MoveCount;
                    break;
                default:
                    x = state.X;
                    y = state.Y;
                    break;
            }
        }
    }
}
