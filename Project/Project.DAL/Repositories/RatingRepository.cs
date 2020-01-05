using System.Collections.Generic;
using Project.DAL.Entities;
using Project.DAL.Interfaces;

namespace Project.DAL.Repositories
{
    public class RatingRepository : IRepository<Rating>
    {
        public IEnumerable<Rating> ReadAll()
        {
            throw new System.NotImplementedException();
        }

        public Rating Read(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Create(Rating item)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Rating item)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}