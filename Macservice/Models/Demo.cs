using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Macservice.Models
{
    // Tên table
    [Table("Demos")]
    public class Demo
    {
        [Key]
        public string Name { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Địa chỉ không được đẻ trống")]
        [MaxLength(10, ErrorMessage = "Độ dài tối đa là 10 ký")]
        public string address { get; set; }
    }
}