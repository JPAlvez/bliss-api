using System;
using System.Text;

namespace Bliss.Recruitment.Tests
{
    public class TestUtils
    {
        private static readonly Random RandomGenerator = new Random((int)DateTime.Now.Ticks);

        public static int GetRandomInt(int min = 0, int max = int.MaxValue)
        {
            return RandomGenerator.Next(min, max);
        }

        public static string RandomString(int size)
        {
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * RandomGenerator.NextDouble() + 65)));
                builder.Append(ch);
            }
            return builder.ToString();
        }
    }
}
