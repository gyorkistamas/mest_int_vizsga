using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ketszemelyes_2
{
    public class Solver
    {
        private List<Operator> operators = new List<Operator>();

        public Solver()
        {
            GenerateOperators();
        }

        public List<Operator> RedOperators
        {
            get
            {
                List<Operator> ret = new List<Operator>();

                foreach (Operator op in Operators)
                {
                    if (op.Color == 'R')
                        ret.Add(op);
                }

                return ret;
            }
        }
        public List<Operator> BlueOperators
        {
            get
            {
                List<Operator> ret = new List<Operator>();

                foreach (Operator op in Operators)
                {
                    if (op.Color == 'B')
                        ret.Add(op);
                }

                return ret;
            }
        }

        public List<Operator> Operators { get => operators; set => operators = value; }

        public void GenerateOperators()
        {
            for (int i = 0; i < State.ROW_COUNT; i++)
            {
                for (int j = 0; j < State.COLUMN_COUNT; j++)
                {
                    operators.Add(new Operator(i, j, 'R'));
                    operators.Add(new Operator(i, j, 'B'));
                }
            }
        }

        public List<Operator> ApplicableOperators(State state, char player)
        {
            List<Operator> temp = new List<Operator>();

            List<Operator> selectFrom = null;

            if (player == 'B')
                selectFrom = BlueOperators;
            else
                selectFrom = RedOperators;

            foreach (Operator op in selectFrom)
            {
                if (op.IsExistingState(state))
                    temp.Add(op);
            }

            return temp;
        }

    }
}
