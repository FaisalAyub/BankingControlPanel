using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MCN.Core.Entities.Entities
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public Double Latitude { get; set; }
        public Double Longitude { get; set; }
        public bool IsEmailVerified { get; set; }
        public bool? IsActive { get; set; }
        public int LoginFailureCount { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public int? UserLoginTypeId { get; set; } 
    }
     
}


/*
Category
- Occupation
- Interest


SubCategory
 
 */