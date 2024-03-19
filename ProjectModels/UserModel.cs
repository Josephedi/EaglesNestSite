using System.ComponentModel.DataAnnotations;

namespace ProjectModels
{
    public class UserModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Username { get; set; }
        public string? MiddleName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Phone { get; set; }
        public string? DateOfBirth { get; set; }
        public string? Street1 { get; set; }
        public string? Street2 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public bool IsActive { get; set; }

        public UserModel()
        {
            IsActive = false;
        }
    }
}