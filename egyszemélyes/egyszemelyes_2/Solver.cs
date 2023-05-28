using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace egyszemelyes_2
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
            for (int i = 0; i < 8; i++) 
            {
                for (int j = 0; j < 8; j++)
                {
                    for (int k = 0; k < 8; k++)
                    {
                        for (int l = 0; l < 8; l++)
                        {
                            operators.Add(new Operator(new Position(i, j), new Position(k, l)));
                        }
                    }
                }
            }
        }
    }
}
