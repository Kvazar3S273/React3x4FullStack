using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLib.Entities.Photo
{
    [Table("tblFotoNaDoc")]
    public class Fnd
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public int Qty { get; set; }
        public int Price { get; set; }
        public int ArchivePice { get; set; }

    }
}
