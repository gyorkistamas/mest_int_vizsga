using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace egyszemélyes
{
    public class Operator
    {
        private int index;
        private Direction direction;

        public int Index { get => index; set => index = value; }
        public Direction Direction { get => direction; set => direction = value; }
        public RowOrColumn RowOrColumn 
        { 
            get
            {
                if (direction == Direction.Left || direction == Direction.Right)
                    return RowOrColumn.Row;
                else
                    return RowOrColumn.Col;
            }
        }

        public Operator(int index, Direction direction)
        {
            this.Index = index;
            this.Direction = direction;
        }

        public bool IsExistingState()
        {
            if (this.Index < 0)
                return false;

            if (this.RowOrColumn == RowOrColumn.Row)
            {
                return this.Index < State.TABLE_ROW_COUNT;
            }
            else
            {
                return this.Index < State.TABLE_COL_COUNT;
            }
        }


        public State ApplyOperator(State state)
        {
            State newState = state.Clone() as State;

            if (this.RowOrColumn == RowOrColumn.Row)
                ShiftHorizontal(newState);
            else
                ShiftVertical(newState);

            return newState;
        }

        private void ShiftHorizontal(State state)
        {
            if (this.Direction == Direction.Left)
            {
                int firstValue = state.Table[this.Index, 0];

                for (int i = 1; i < State.TABLE_COL_COUNT; i++)
                {
                    state.Table[this.index, i - 1] = state.Table[this.index, i];
                }

                state.Table[this.index, State.TABLE_COL_COUNT - 1] = firstValue;
            }
            else
            {
                int firstValue = state.Table[this.Index, State.TABLE_COL_COUNT - 1];

                for (int i = State.TABLE_COL_COUNT - 2; i >= 0; i--)
                {
                    state.Table[this.index, i + 1] = state.Table[this.index, i];
                }

                state.Table[this.index, 0] = firstValue;
            }
        }


        private void ShiftVertical(State state)
        {
            if (this.Direction == Direction.Up)
            {
                int firstValue = state.Table[0, this.Index];

                for (int i = 0; i < State.TABLE_ROW_COUNT - 1; i++)
                {
                    state.Table[i, this.Index] = state.Table[i + 1, this.index];
                }

                state.Table[State.TABLE_ROW_COUNT - 1, this.Index] = firstValue;
            }
            else
            {
                int firstValue = state.Table[State.TABLE_ROW_COUNT - 1, this.Index];

                for (int i = State.TABLE_ROW_COUNT - 2; i >= 0; i--)
                {
                    state.Table[i + 1, this.Index] = state.Table[i, this.Index];
                }

                state.Table[0, this.Index] = firstValue;
            }
        }
    }
}
