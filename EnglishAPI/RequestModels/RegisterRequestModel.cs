namespace EnglishAPI.RequestModels
{
    public class RegisterRequestModel: IRequestModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }

        public List<string> Valid()
        {
            List<string> errorStrings = new List<string>();
            
            if (!RequestValidator.notEmpty(Username))
            {
                errorStrings.Add("Username must not be empty");
            }

            if (!RequestValidator.between(Password, 7, 30))
            {
                errorStrings.Add("Password must be longer than 7 characters and less than 30");
            }

            if (!RequestValidator.containsNumber(Password))
            {
                errorStrings.Add("Password must contain a number");
            }

            if (!RequestValidator.containsUppercase(Password))
            {
                errorStrings.Add("Password must contain an uppercase letter");
            }

            if (Password != RePassword)
            {
                errorStrings.Add("Passwords must match");
            }

            return errorStrings;
        }
    }
}
