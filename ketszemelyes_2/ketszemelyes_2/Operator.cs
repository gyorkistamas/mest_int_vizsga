using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ketszemelyes_2
{
    public class Operator
    {
        int toX, toY;
        char color;

        public Operator(int toX, char toY, char player)
        {
            this.Color = player;
            this.ToX = toX - 1;
            switch (toY)
            {
                case 'a':
                    this.ToY = 0;
                    break;
                case 'b':
                    this.ToY = 1;
                    break;
                case 'c':
                    this.ToY = 2;
                    break;
                case 'd':
                    this.ToY = 3;
                    break;
                case 'e':
                    this.ToY = 4;
                    break;
                default:
                    this.ToY = 0;
                    break;
                    
            }
        }

        public Operator(int toX, int toY, char player)
        {
            this.Color = player;
            this.ToX = toX;
            this.ToY = toY;
        }

        public int ToX { get => toX; set => toX = value; }
        public int ToY { get => toY; set => toY = value; }
        public char Color { get => color; set => color = value; }

        public bool IsExistingState(State state)
        {
            return InsideTheTable() &&
                   IsCellFree(state);
        }

        private bool InsideTheTable()
        {
            return ToX >= 0 && ToX < State.ROW_COUNT &&
                   ToY >= 0 && ToY < State.COLUMN_COUNT;
        }


        private bool IsCellFree(State state)
        {
            return state.Table[toX, toY] == ' ';
        }


        public State ApplyOperator(State state)
        {
            State newState = state.Clone() as State;

            newState.Table[ToX, ToY] = Color;

            newState.PlayerToMove = newState.PlayerToMove == 'B' ? 'R' : 'B';

            return newState;
        }
    }
}
