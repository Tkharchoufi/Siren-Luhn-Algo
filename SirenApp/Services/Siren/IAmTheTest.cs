namespace SirenApp.Services.Siren
{
    public interface IAmTheTest
    {
        bool CheckSirenValidity(string siren);
        string ComputeFullSiren(string sirenWithoutControlNumber);
    }
}
