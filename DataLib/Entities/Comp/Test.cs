using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLib.Entities.Comp
{
    [Table("tblTest")]
    public class Test
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal DealerPrice { get; set; }
        public decimal UserPrice { get; set; }
        public decimal AlternatePrice { get; set; }
    }
}
