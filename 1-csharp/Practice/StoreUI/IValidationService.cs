namespace StoreUI
{
    public interface IValidationService
    {
        /// <summary>
        /// Prompt
        /// </summary>
        /// <param name="prompt"></param>
        /// <returns></returns>
        string ValidateString(string prompt);
    }
}