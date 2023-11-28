namespace SirenApp.Services.Crypto
{
    public interface ILuhnAlgoService
    {
        public int CalculateControlDigit(string IdentityCode);

        public int CalculateLuhnSum(string inputCode);
    }
}
