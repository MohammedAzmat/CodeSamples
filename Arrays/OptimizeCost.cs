using System;

namespace Arrays
{
    public class OptimizeCost
    {
        private int GetBookBundles(int money, int[] bundleCount, int[] bundleCost)
        {
            return GetBookBundles(money, 0, 0, bundleCount, bundleCost);
        }

        private int GetBookBundles(int money, int MaxBooks, int books, int[] bundleCount, int[] bundleCost)
        {
            if (money <= 0)
            {
                return MaxBooks;
            }
            for (int i = 0; i < bundleCount.Length; i++)
            {
                if (money < bundleCost[i])
                {
                    return books;
                }
                MaxBooks = Math.Max(MaxBooks, GetBookBundles(money - bundleCost[i], MaxBooks, books + bundleCount[i], bundleCount, bundleCost));
            }
            return MaxBooks;
        }

        public int OptimizeMyCost()
        {
            int[] bundleCount = new int[] { 20, 19 };
            int[] bundleCost = new int[] { 24, 20 };
            return GetBookBundles(50, bundleCount, bundleCost);

        }
    }
}
