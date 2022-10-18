using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLib.Entities.Poligraph
{
    [Table("tblBirka")]
    public class Birka
    {
        [Key]
        public int Id { get; set; }
        public string Format { get; set; }
        public string Density { get; set; }
        public decimal Price { get; set; }
    }
}
