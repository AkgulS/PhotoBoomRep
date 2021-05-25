using PhotoBoomApplicationCore.Domain;
using PhotoBoomApplicationCore.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoBoomApplicationCore.Services.Interfaces
{
    public interface IPhotoService:IRepository<Photo>
    {
    }
}
