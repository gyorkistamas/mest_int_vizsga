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
    public class StateTests
    {
        [TestMethod()]
        public void IsTargetStateReturnsTrueForGoodTable()
        {
            int[,] correctTable = new int[State.TABLE_ROW_COUNT, State.TABLE_COL_COUNT];

            int counter = 1;
            for (int i = 0; i < State.TABLE_ROW_COUNT; i++)
            {
                for (int j = 0; j < State.TABLE_COL_COUNT; j++)
                {
                    correctTable[i, j] = counter;
                    counter++;
                }
            }

            State state = new State(correctTable);

            Assert.IsTrue(state.IsTargetReached());
        }

        [TestMethod()]
        public void IsTargetStateReturnsFalseForBadTable()
        {
            int[,] badTable = new int[State.TABLE_ROW_COUNT, State.TABLE_COL_COUNT];

            Random rnd = new Random();
            for (int i = 0; i < State.TABLE_ROW_COUNT; i++)
            {
                for (int j = 0; j < State.TABLE_COL_COUNT; j++)
                {
                    badTable[i, j] = rnd.Next(1, State.TABLE_ROW_COUNT * State.TABLE_COL_COUNT + 1);
                }
            }

            State state = new State(badTable);

            Assert.IsFalse(state.IsTargetReached());
        }
    }
}