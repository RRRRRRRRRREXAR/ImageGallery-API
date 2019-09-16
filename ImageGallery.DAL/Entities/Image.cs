using System;
using System.Collections.Generic;
using System.Text;

namespace ImageGallery.DAL.Entities
{
    public class Image
    {
        public string Id { get; set; }
        public string Link { get; set; }
        public User User { get; set; }
    }
}
