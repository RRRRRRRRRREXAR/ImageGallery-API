using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ImageGallery.DAL.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName {get;set;}
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        ICollection<Image> Images { get; set; }

    }
}
