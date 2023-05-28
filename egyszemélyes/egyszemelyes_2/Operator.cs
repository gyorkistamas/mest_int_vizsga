using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace egyszemelyes_2
{
    internal class Operator
    {
        private Position from, to;

        public Operator(Position from, Position to)
        {
            From = from;
            To = to;
        }

        public Position From { get => from; set => from = value; }
        public Position To { get => to; set => to = value; }

        public bool IsExistingState(State state)
        {
            return IsInSideTheTable() &&
                   PlayerIsOnCoords(state) &&
                   (MoveIsHorizontal() || MoveIsVertical()) &&
                   MoveCountIsCorrect(state) &&
                   NoWallsBetween(state);
        }

        private bool IsInSideTheTable()
        {
            return From.X >= 0 && From.X <= 7 &&
                   From.Y >= 0 && From.Y <= 7 &&
                   To.X   >= 0 && To.X   <= 7 &&
                   To.Y   >= 0 && To.Y   <= 7;
        }

        private bool PlayerIsOnCoords(State state)
        {
            return From.Equals(state.PlayerPosition);
        }

        private bool MoveIsHorizontal()
        {
            return From.X == To.X;
        }

        private bool MoveIsVertical()
        {
            return From.Y == To.Y;
        }

        private bool MoveCountIsCorrect(State state)
        {
            if (MoveIsHorizontal())
            {
                return Math.Abs(from.Y - to.Y) == state.MoveCount;
            }
            else
            {
                return Math.Abs(from.X - to.X) == state.MoveCount;
            }
        }

        private bool NoWallsBetween(State state)
        {
            int start = 0;
            int end = 0;

            if (MoveIsHorizontal())
            {  
                if (From.Y > To.Y)
                {
                    start = To.Y;
                    end = From.Y;
                }
                else
                {
                    end = To.Y;
                    start = From.Y;
                }

                for (int i = start + 1; i < end; i++)
                {
                    if (State.Table[From.X, i] == 'W')
                    {
                        return false;
                    }
                }

                return true;
            }
            else
            {
                if (From.X > To.X)
                {
                    start = To.X;
                    end = From.X;
                }
                else
                {
                    end = To.X;
                    start = From.X;
                }

                for (int i = start + 1; i < end; i++)
                {
                    if (State.Table[i, From.Y] == 'W')
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        public State ApplyOperator(State state)
        {
            State newState = state.Clone() as State;

            newState.PlayerPosition = this.To.Clone() as Position;

            if (State.Table[To.X, To.Y] == 'O')
            {
                newState.ChangeMoveCount();
            }

            return newState;
        }
    }
}
