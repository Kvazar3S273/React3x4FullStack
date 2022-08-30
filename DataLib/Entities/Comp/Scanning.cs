using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLib.Entities.Comp
{
    [Table("tblScanning")]
    public class Scanning
    {
        [Key]
        public int Id { get; set; }
        public string Service { get; set; }
        public decimal Price { get; set; }
    }
}
