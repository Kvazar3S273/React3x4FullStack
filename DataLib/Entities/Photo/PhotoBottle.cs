﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLib.Entities.Photo
{
    [Table("tblPhotoBottle")]
    public class PhotoBottle
    {
        [Key]
        public int Id { get; set; }
        public string Service { get; set; }
        public int Price { get; set; }
    }
}
