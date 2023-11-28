namespace SirenApp.Services.Siren
{
    public interface ISirenService
    {
        bool CheckSirenValidity(string siren);
        string ComputeFullSiren(string sirenWithoutControlNumber);
    }
}
