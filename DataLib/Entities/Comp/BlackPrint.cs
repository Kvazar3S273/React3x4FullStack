using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLib.Entities.Comp
{
    [Table("tblBlackPrint")]
    public class BlackPrint
    {
        [Key]
        public int Id { get; set; }
        public string Material { get; set; }
        public decimal PriceText { get; set; }
        public decimal Price100 { get; set; }
    }
}
