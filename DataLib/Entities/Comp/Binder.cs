using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLib.Entities.Comp
{
    [Table("tblBinder")]
    public class Binder
    {
        [Key]
        public int Id { get; set; }
        public string PagesQty { get; set; }
        public decimal Price { get; set; }
    }
}
