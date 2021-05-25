using PhotoBoomApplicationCore.Domain;
using PhotoBoomApplicationCore.Repository;
using PhotoBoomApplicationCore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoBoomApplicationCore.Services
{
    public class PhotoService : Repository<Photo>, IPhotoService
    {
        public PhotoService(PhotoBoomContext context) : base(context)
        {
        }
    }
}
