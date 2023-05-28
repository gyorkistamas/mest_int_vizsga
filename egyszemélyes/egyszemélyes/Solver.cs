using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace egyszemélyes
{
    internal class Solver
    {
        private List<Operator> operators = new List<Operator>();
        private List<State> routes = new List<State>();
        public Solver()
        {
            GenerateOperators();
        }

        public List<Operator> Operators { get => operators; set => operators = value; }
        public List<State> Routes { get => routes; set => routes = value; }

        void GenerateOperators()
        {
            for(int i = 0; i < State.TABLE_ROW_COUNT; i++)
            {
                operators.Add(new Operator(i, Direction.Left));
                operators.Add(new Operator(i, Direction.Right));
            }

            for (int i = 0; i < State.TABLE_COL_COUNT; i++)
            {
                operators.Add(new Operator(i, Direction.Up));
                operators.Add(new Operator(i, Direction.Down));
            }
        }
    }
}
