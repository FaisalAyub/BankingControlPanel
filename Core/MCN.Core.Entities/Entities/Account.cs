using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MCN.Core.Entities.Entities
{
 
        public class Account { 
             [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
             [Key]
            public int Id { get; set; }
            public DateTime DateCreated { get; set; }
            public string AccountType { get; set; }

        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

    }
    
}
