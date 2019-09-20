using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageGallery.Models
{
    public class ImageModel
    {
        public string Id { get; set; }
        public string Link { get; set; }
        public Person Owner { get; set; }
    }
}
