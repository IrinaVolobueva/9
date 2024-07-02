using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9
{
    public class ChangeCalculator
    {
        public Change CalculateChange(decimal cost, decimal money)
        {
            decimal changeAmount = money - cost;
            Change change = new Change();

            change.Rubles = (int)changeAmount;
            decimal kopecks = (changeAmount - change.Rubles) * 100;

            change.Kopecks = (int)kopecks;

            int[] coinValues = { 50, 20, 10, 5, 2, 1 };
            foreach (int coinValue in coinValues)
            {
                int count = (int)(kopecks / coinValue);
                kopecks -= count * coinValue;
                change.Coins.Add(new Coin(coinValue, count));
            }

            return change;
        }
    }

    public class Change
    {
        public int Rubles { get; set; }
        public int Kopecks { get; set; }
        public List<Coin> Coins { get; set; } = new List<Coin>();
    }

    public class Coin
    {
        public int Value { get; set; }
        public int Count { get; set; }

        public Coin(int value, int count)
        {
            Value = value;
            Count = count;
        }
    }
}
