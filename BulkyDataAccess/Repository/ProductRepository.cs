using BulkyBookDataAccess.Data;
using BulkyBookDataAccess.Repository.IRepository;
using BulkyBookModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBookDataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ApplicationDBContext _db;
        public ProductRepository(ApplicationDBContext db) : base (db)
        {
            _db = db;
        }
        public void Update(Product product)
        {
            _db.Update(product);
        }
    }
}
