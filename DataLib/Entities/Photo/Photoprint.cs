using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLib.Entities.Photo
{
    [Table("tblPhotoPrint")]
    public class Photoprint
    {
        [Key]
        public int Id { get; set; }
        public string Format { get; set; }
        public string ExactSizes { get; set; }
        public int Price { get; set; }

    }
}
