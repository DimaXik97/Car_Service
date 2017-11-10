using Car_Service.DAL.Entities;
using System;

namespace Car_Service.DAL.Interfaces
{
    public interface IImageManager : IDisposable
    {
        void Create(Image item);
    }
}
