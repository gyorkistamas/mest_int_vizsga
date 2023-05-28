using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O5PP4S_mestint_szorgalmi
{
    internal class Solver
    {
        List<Operator> Xoperators;
        List<Operator> Ooperators;

        public Solver()
        {
            Xoperators = new List<Operator>();
            Ooperators = new List<Operator>();
            GenerateOperators();
        }

        public List<Operator> Xoperators1 { get => Xoperators; set => Xoperators = value; }
        public List<Operator> Ooperators1 { get => Ooperators; set => Ooperators = value; }

        private void GenerateOperators()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Xoperators.Add(new Operator(i, j, 'X'));
                    Ooperators.Add(new Operator(i, j, 'O'));
                }
            }
        }

        public List<Operator> ApplicableOperators(State state, char player)
        {
            List<Operator> temp = new List<Operator>();

            List<Operator> selectFrom = null;

            if (player == 'X')
            {
                selectFrom = Xoperators;
            }
            else
            {
                selectFrom = Ooperators;
            }

            foreach (Operator op in selectFrom)
            {
                if (op.IsExistingState(state))
                {
                    temp.Add(op);
                }
            }

            return temp;

        }
    }
}
