using Car_Service.DAL.Entities;
using Car_Service.DAL.Interfaces;
using Car_Service.Model.EF;


namespace Car_Service.DAL.Repositories
{
    class ImageManager : IImageManager
    {
        public ApplicationContext Database { get; set; }
        public ImageManager(ApplicationContext db)
        {
            Database = db;
        }

        public void Create(Image item)
        {
            Database.Image.Add(item);
            Database.SaveChanges();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
