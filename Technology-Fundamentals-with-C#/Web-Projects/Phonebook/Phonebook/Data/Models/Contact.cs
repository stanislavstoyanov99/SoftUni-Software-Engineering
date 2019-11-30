﻿using System.ComponentModel.DataAnnotations;

namespace Phonebook.Data.Models
{
    public class Contact : DataAccess
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Number { get; set; }
    }
}
