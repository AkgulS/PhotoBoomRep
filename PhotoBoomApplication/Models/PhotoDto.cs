using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoBoomApplication.Models
{
    public class PhotoDto
    {
        public string Title { get; set; }
        public string Tags { get; set; }
        public IFormFile Photo { get; set; }
    }
}
