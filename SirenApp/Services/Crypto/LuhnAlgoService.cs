using SirenApp.Helpers;

namespace SirenApp.Services.Crypto
{
    public class LuhnAlgoService : ILuhnAlgoService
    {
        private readonly int _luhnModulo = 10;
        public int CalculateControlDigit(string IdentityCode)
        {
            var sum = CalculateLuhnSum(IdentityCode);

            return sum % _luhnModulo == 0 ? 0 : _luhnModulo - sum % _luhnModulo;
        }

        public int CalculateLuhnSum(string inputCode)
        {
            int sum = 0;

            for (int i = 0; i < inputCode.Length; i++)
            {
                var coef = Helper.GetCoef(i + 1);

                var digit = int.Parse(inputCode[i].ToString());

                sum += Helper.GetDigitSum(coef * digit);
            }

            return sum;
        }
    }
}
