using System.ComponentModel.DataAnnotations;

namespace API.DTOs.Users.Validations
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    //AttributeTargets makes it possible for us to specify the memeber we want to attach the attribute to it while AllowMultiple see that we dont apply multiple attribute
    public class GenderAttribute : ValidationAttribute
    {
        private const string male = "MALE";
        private const string female = "FEMALE";
        public override bool IsValid(object? value)
        {
            if (value is not string gender)
            {
                return false;
            }
            return gender.ToLower() == male.ToLower() || gender.ToLower() == female.ToLower();
        }
    }
}

