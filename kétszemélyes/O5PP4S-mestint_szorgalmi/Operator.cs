using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O5PP4S_mestint_szorgalmi
{
    internal class Operator
    {
        int x, y;
        char item;

        public Operator(int x, int y, char item)
        {
            X = x;
            Y = y;
            Item = item;
        }

        public Operator(int num, char item)
        {
            switch (num)
            {
                case 1:
                    X = 2;
                    Y = 0;
                    break;
                case 2:
                    X = 2;
                    Y = 1;
                    break;
                case 3:
                    X = 2;
                    Y = 2;
                    break;
                case 4:
                    X = 1;
                    Y = 0;
                    break;
                case 5:
                    X = 1;
                    Y = 1;
                    break;
                case 6:
                    X = 1;
                    Y = 2;
                    break;
                case 7:
                    X = 0;
                    Y = 0;
                    break;
                case 8:
                    X = 0;
                    Y = 1;
                    break;
                case 9:
                    X = 0;
                    Y = 2;
                    break;
            }
            Item = item;
        }

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public char Item { get => item; set => item = value; }

        public bool IsExistingState(State state)
        {
            if (state.Table[x, y] == ' ')
            {
                return true;
            }

            return false;
        }

        public State ApplyState(State state, char item)
        {
            State newState = state.Clone() as State;

            newState.Table[x, y] = item;

            return newState;
        }
    }
}
