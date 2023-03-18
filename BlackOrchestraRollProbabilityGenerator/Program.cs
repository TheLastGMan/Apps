using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int targetsNeeded = 2;
            int insigniaIgnored = 10;
            int maxDice = 10;

            for (int insigniaMatching = 3; insigniaMatching >= 1; insigniaMatching--)
            {
                var results = new List<DiceRollSummary>(maxDice);

                for (int cnt = 1; cnt <= maxDice; cnt++)
                {
                    var result = DiceRoll(cnt, targetsNeeded, insigniaMatching, insigniaIgnored);
                    results.Add(result);
                }

                Console.WriteLine($"TGTS: { targetsNeeded } | INSIGS: { insigniaMatching }");
                foreach (var res in results)
                    Console.WriteLine($"D: { res.DiceCount.ToString().PadRight(2, ' ') } | C: { res.Combinations.ToString().PadLeft(8, ' ') } | F: { res.Failed.ToString().PadLeft(8, ' ') } | K: { res.Killed.ToString().PadLeft(8, ' ') } | U: { res.Undetected.ToString().PadLeft(8, ' ') }");
                Console.WriteLine("");
            }
        }

        private static DiceRollSummary DiceRoll(int dices, int targetsNeeded, int insigniaMatching, int insigniaIgnored)
        {
            var dRes = new DiceValue[dices];
            var rolls = new List<DiceRollResult>();
            do
            {
                if (InsigniaCount(dRes) >= (insigniaMatching + insigniaIgnored))
                    rolls.Add(DiceRollResult.Failed);
                else if (TargetCount(dRes) >= targetsNeeded)
                    rolls.Add(DiceRollResult.Killed);
                else
                    rolls.Add(DiceRollResult.Undetected);
            } while (!IsBaseDiceSet(NextCombination(dRes)));

            //aggregate results
            var result = new DiceRollSummary()
            {
                DiceCount = dices,
                Combinations = rolls.Count
            };

            foreach (var roll in rolls)
                switch (roll)
                {
                    case DiceRollResult.Failed:
                        result.Failed++;
                        break;
                    case DiceRollResult.Killed:
                        result.Killed++;
                        break;
                    default:
                        result.Undetected++;
                        break;
                }

            return result;
        }

        private static bool IsBaseDiceSet(DiceValue[] diceSet)
        {
            var baseSet = new DiceValue[diceSet.Length];
            for (int i = 0; i < diceSet.Length; i++)
                if (baseSet[i] != diceSet[i])
                    return false;

            return true;
        }

        private static DiceValue[] NextCombination(DiceValue[] diceSet)
        {
            for (int i = 0; i < diceSet.Length; i++)
            {
                int currVal = (int)diceSet[i];
                int nextVal = (currVal + 1) % 6;
                diceSet[i] = (DiceValue)nextVal;

                if (nextVal < currVal)
                    //rolled over, go to next
                    continue;

                //otherwise, valid no rollover, just update
                break;
            }

            return diceSet;
        }

        private static int InsigniaCount(DiceValue[] diceSet)
        {
            int count = 0;
            foreach (var d in diceSet)
                if (d == DiceValue.Insignia)
                    count++;
            return count;
        }

        private static int TargetCount(DiceValue[] diceSet)
        {
            int count = 0;
            foreach (var d in diceSet)
                if (d == DiceValue.Target1 || d == DiceValue.Target2)
                    count++;
            return count;
        }

        private enum DiceValue : int
        {
            Insignia = 0,
            One = 1,
            Two = 2,
            Three = 3,
            Target1 = 4,
            Target2 = 5
        }

        private enum DiceRollResult
        {
            Failed,
            Undetected,
            Killed
        }

        private class DiceRollSummary
        {
            public int DiceCount { get; set; }
            public int Combinations { get; set; }

            public int Failed { get; set; }
            public int Killed { get; set; }
            public int Undetected { get; set; }

            public decimal FailPercent { get { return Math.Round((decimal)Failed / Combinations * 100, 2); } }
            public decimal KilledPercent { get { return Math.Round((decimal)Killed / Combinations * 100, 2); } }
            public decimal UndetectedPercent { get { return Math.Round((decimal)Undetected / Combinations * 100, 2); } }
        }
    }
}
