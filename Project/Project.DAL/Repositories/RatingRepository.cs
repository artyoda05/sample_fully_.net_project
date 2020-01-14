using System.Collections.Generic;
using System.Data.Entity;
using Project.DAL.Context;
using Project.DAL.Entities;
using Project.DAL.Interfaces;

namespace Project.DAL.Repositories
{
    public class RatingRepository : IRepository<Rating>
    {
        private readonly EFContext _context;
        public RatingRepository(EFContext context) => _context = context;
        public IEnumerable<Rating> ReadAll()
        {
            return _context.Ratings;
        }

        public Rating Read(int id)
        {
            return _context.Ratings.Find(id);
        }

        public void Create(Rating item)
        {
            _context.Ratings.Add(item);
        }

        public void Update(Rating item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public void Delete(Rating item)
        {
            _context.Ratings.Remove(item);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}