namespace CarLotUI
{
    public interface IValidationService
    {
        string ValidateString(string prompt);
        int ValidateInt(string prompt);
    }
}