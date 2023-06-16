﻿using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
    }
}
