﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class Position
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name = "Должность")]
        [Required(ErrorMessage = "Необходимо ввести должность")]
        public string PositionName { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
