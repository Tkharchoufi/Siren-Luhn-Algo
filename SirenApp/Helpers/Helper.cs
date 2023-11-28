namespace SirenApp.Helpers
{
    static class Helper
    {
        private static readonly int evenCoef = 2;
        private static readonly int oddCoef = 1;
        private static readonly int evenModulo = 2;
        private static readonly int digitModulo = 10;
        public static int GetCoef(int position)
        {
            return position % evenModulo == 0 ? evenCoef : oddCoef;
        }

        public static int GetDigitSum(int number)
        {
            int sum = 0;
            while (number != 0)
            {
                sum += number % digitModulo;
                number /= digitModulo;
            }

            return sum;
        }
    }
}
