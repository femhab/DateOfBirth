using DateOfBirthApp.Data.Enum;
using System;

namespace DateOfBirthApp.Data.Entity
{
    public class User: BaseObject
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public Title Title { get; set; }
    }
}
