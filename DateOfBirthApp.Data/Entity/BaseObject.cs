using System;

namespace DateOfBirthApp.Data.Entity
{
    public class BaseObject
    {
            public Guid Id { get; set; }
            public DateTime CreatedDate { get; set; }
            public DateTime? UpdatedDate { get; set; }
            public string CreatedBy { get; set; }
            public string UpdatedBy { get; set; }
    }
}
