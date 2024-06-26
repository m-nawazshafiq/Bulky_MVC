﻿using BulkyBookDataAccess.Data;
using BulkyBookDataAccess.Repository.IRepository;
using BulkyBookModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBookDataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDBContext _db;
        public CategoryRepository(ApplicationDBContext db) : base (db)
        {
            _db = db;
        }

        public void Update(Category category)
        {
            _db.Update(category);
        }
    }
}
