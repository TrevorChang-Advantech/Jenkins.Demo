namespace Jenkins.Demo.Service
{
    public class UserNameValidator : IUserNameValidator
    {
        public bool EnsureUsernameIsLongerThanFiveCharacters(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                return false;
            }

            if (userName.Length < 5)
            {
                return false;
            }

            return true;
        }
    }
}