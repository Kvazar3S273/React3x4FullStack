using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLib.Entities.Photo
{
    [Table("tblPhotoDuplicate")]
    public class PhotoDuplicate
    {
        [Key]
        public int Id { get; set; }
        public string Format { get; set; }
        public int PriceFirst { get; set; }
        public int PriceEachOther { get; set; }
    }
}
