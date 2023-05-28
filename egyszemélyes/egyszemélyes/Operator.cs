using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace egyszemélyes
{
    internal class Operator
    {
        private int index;
        private Direction direction;

        public int Index { get => index; set => index = value; }
        public Direction Direction { get => direction; set => direction = value; }

        public Operator(int index, Direction direction)
        {
            this.Index = index;
            this.Direction = direction;
        }

        public bool IsExistingState()
        {
            if (this.Index < 0)
                return false;

            if (this.Direction == Direction.Left || this.Direction == Direction.Right)
            {
                return this.Index < State.TABLE_X_LENGTH;
            }
            else
            {
                return this.Index < State.TABLE_Y_LENGTH;
            }
        }


        public State ApplyOperator(State state)
        {
            State newState = state.Clone() as State;

            switch(this.Direction)
            {
                case Direction.Left:
                case Direction.Right:
                    break;

                case Direction.Up: 
                case Direction.Down:
                    break;
            }


            return newState;
        }

        private void ShiftHorizontal(State state)
        {

        }


        private void ShoftVertical(State state)
        {

        }
    }
}
