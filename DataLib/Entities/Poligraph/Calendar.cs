﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLib.Entities.Poligraph
{
    [Table("tblCalendar")]
    public class Calendar
    {
        [Key]
        public int Id { get; set; }
        public string Density { get; set; }
        public string Laminating { get; set; }
        public decimal Price { get; set; }
    }
}
