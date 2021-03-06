﻿using INTEREST.DAL.EF;
using INTEREST.DAL.Entities;
using INTEREST.DAL.Interfaces;
using System.Linq;

namespace INTEREST.DAL.Repositories
{
    public class PhotoRepository : BaseRepository<Photo>, IPhotoRepository
    {
        public PhotoRepository(AppDBContext context) : base(context)
        {

        }
    }
}
