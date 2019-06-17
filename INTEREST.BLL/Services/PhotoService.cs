using INTEREST.BLL.DTO;
using INTEREST.DAL.Entities;
using INTEREST.DAL.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace INTEREST.BLL.Services
{
    public class PhotoService
    {
        private IHostingEnvironment appEnvironment;

        public IUnitOfWork Db { get; set; }

        public PhotoService(IUnitOfWork uow, IHostingEnvironment _appEnvironment)
        {
            Db = uow;
            appEnvironment = _appEnvironment;
        }

        async Task<Photo> AddPhoto(IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
                throw (new Exception("File not found!"));
            }
            string path = "/files/" + uploadedFile.FileName;
            using (var fileStream = new FileStream(appEnvironment.WebRootPath + path, FileMode.Create))
            {
                await uploadedFile.CopyToAsync(fileStream);
            }
            Photo photo = new Photo {
                URL = path };

            Db.PhotoRepository.Create(photo);

            await Db.SaveAsync();
            return photo;
        }
    }
}
