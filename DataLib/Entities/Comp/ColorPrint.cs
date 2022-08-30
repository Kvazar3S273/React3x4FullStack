using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLib.Entities.Comp
{
    [Table("tblColorPrint")]
    public class ColorPrint
    {
        [Key]
        public int Id { get; set; }
        public string Material { get; set; }
        public decimal Price25 { get; set; }
        public decimal Price50 { get; set; }
        public decimal Price100 { get; set; }
    }
}
