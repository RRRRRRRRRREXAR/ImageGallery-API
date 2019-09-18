﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ImageGallery.DAL.Entities
{
    public class Request
    {
        [KeyAttribute]
        public string Id { get; set; }
        public string Url { get; set; }
        public string Headers { get; set; }
        public string QueryParams { get; set; }
        public string Body { get; set; }
        public string HttpVerb { get; set; }
    }
}
