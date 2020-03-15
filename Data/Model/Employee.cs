using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Необходимо ввести имя")]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }
        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Необходимо ввести фамилию")]
        public string LastName { get; set; }
        [ForeignKey("Position")]
        [Display(Name = "Должность")]
        public int? PositionId { get; set; }
        public Position Position { get; set; }
        [Display(Name = "Оклад")]
        [Range(typeof(decimal), "0,0", "1000000000,0", ErrorMessage = "Наименьшая сумма - 0, в качестве разделителя дробной и целой части используется запятая")]
        public decimal? Salary { get; set; }
        [Display(Name = "Нанят")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Необходимо ввести дату найма")]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Hired { get; set; }
        [Display(Name = "Уволен")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Fired { get; set; }


        [NotMapped]
        public string FullName => this.FirstName + " " + this.LastName;
    }
}
