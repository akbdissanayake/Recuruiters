﻿using System.ComponentModel.DataAnnotations;

namespace Recruiters.Domain.Entities
{
    public class Recruiter
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public string Client { get; set; } = string.Empty;
        public string JobDescription { get; set; } = string.Empty;
    }
}
