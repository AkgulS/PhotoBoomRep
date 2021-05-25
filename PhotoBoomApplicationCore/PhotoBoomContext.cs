using Microsoft.EntityFrameworkCore;
using PhotoBoomApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoBoomApplicationCore
{
    public class PhotoBoomContext : DbContext
    {
        public PhotoBoomContext(DbContextOptions<PhotoBoomContext> options) : base(options)
        {

        }
        public DbSet<Photo> Photos { get; set; }
    }
}
