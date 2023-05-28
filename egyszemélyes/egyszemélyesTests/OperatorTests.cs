using Microsoft.VisualStudio.TestTools.UnitTesting;
using egyszemélyes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace egyszemélyes.Tests
{
    [TestClass()]
    public class OperatorTests
    {
        [TestMethod()]
        public void IsExistingStateTestReturnsTrueToGoodOperators()
        {
            List<Operator> ops = new List<Operator>();

            for (int i = 0; i < State.TABLE_ROW_COUNT; i++)
            {
                ops.Add(new Operator(i, Direction.Left));
                ops.Add(new Operator(i, Direction.Right));
            }

            for (int i = 0; i < State.TABLE_COL_COUNT; i++)
            {
                ops.Add(new Operator(i, Direction.Up));
                ops.Add(new Operator(i, Direction.Down));
            }

            foreach (Operator op in ops)
            {
                Assert.IsTrue(op.IsExistingState());
            }
        }

        [TestMethod()]
        public void IsExistingStateTestReturnsFalseToBadOperators()
        {
            List<Operator> ops = new List<Operator>();

            for (int i = State.TABLE_ROW_COUNT; i < State.TABLE_ROW_COUNT + 10; i++)
            {
                ops.Add(new Operator(i, Direction.Left));
                ops.Add(new Operator(i, Direction.Right));
            }

            for (int i = State.TABLE_ROW_COUNT; i < State.TABLE_ROW_COUNT + 10; i++)
            {
                ops.Add(new Operator(i, Direction.Up));
                ops.Add(new Operator(i, Direction.Down));
            }

            foreach (Operator op in ops)
            {
                Assert.IsFalse(op.IsExistingState());
            }
        }

    }
}