using Jenkins.Demo.Service;

namespace Jenkins.Demo.UnitTest
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("Adam", false)]
        [InlineData("Trevor", true)]
        [InlineData("", false)]
        [InlineData(null, false)]
        public void Test_EnsureUsernameIsLongerThanFiveCharacters(string username, bool expected)
        {
            var validator = new UserNameValidator();
            var result = validator.EnsureUsernameIsLongerThanFiveCharacters(username);
            Assert.Equal(expected, result);
        }
    }
}