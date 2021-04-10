using DateOfBirthApp.ViewModel.Enumeration;
using System;

namespace DateOfBirthApp.ViewModel.Model
{
    public class UserModel: BaseModel
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public TitleEnum Title { get; set; }
    }

    public class UserFormModel
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public TitleEnum Title { get; set; }
    }
}
