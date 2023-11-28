using SirenApp.Services.Crypto;

namespace SirenApp.Services.Siren
{
    public class SirenService : ISirenService
    {
        private readonly int _validSirenLength = 9;
        private readonly ILuhnAlgoService _luhnService;
        public SirenService(ILuhnAlgoService luhnService)
        {
            _luhnService = luhnService;
        }
        public bool CheckSirenValidity(string siren)
        {
            if (string.IsNullOrEmpty(siren) || siren.Length != _validSirenLength || !siren.All(char.IsDigit))
                return false;

            var sum = _luhnService.CalculateLuhnSum(siren);

            return sum % 10 == 0;
        }

        public string ComputeFullSiren(string sirenWithoutControlNumber)
        {
            return $"{sirenWithoutControlNumber}{_luhnService.CalculateControlDigit(sirenWithoutControlNumber)}";
        }
    }
}
