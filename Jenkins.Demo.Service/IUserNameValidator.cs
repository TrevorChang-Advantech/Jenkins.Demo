namespace Jenkins.Demo.Service
{
    public interface IUserNameValidator
    {
        bool EnsureUsernameIsLongerThanFiveCharacters(string input);
    }
}