using System;
using System.Collections.Generic;
using System.Text;

namespace ImageGallery.BLL.DTO
{
   public class ImageDTO
    {
       public int Id { get; set; }
        public string Link { get; set; }
        public UserDTO User { get; set; }
    }
}
