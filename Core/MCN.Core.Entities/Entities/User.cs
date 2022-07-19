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
        public string Phone { get; set; }
        public bool IsEmailVerified { get; set; }
        public bool? IsActive { get; set; }
        public int? UserLoginTypeId { get; set; }
        public ICollection<Account> Accounts { get; set; }
        public ICollection<Address> Address { get; set; }
    }
     
}


/*
Category
- Occupation
- Interest


SubCategory
 
 */