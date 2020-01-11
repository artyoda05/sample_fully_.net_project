using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using Project.DAL.Context;
using Project.DAL.Entities;
using Project.DAL.Interfaces;

namespace Project.DAL.Repositories
{
    public class UserRepository : IRepository<UserProfile>
    {
        private readonly EFContext _context;
        public UserRepository(EFContext context) => _context = context;
        public IEnumerable<UserProfile> ReadAll()
        {
            throw new System.NotImplementedException();
        }

        public UserProfile Read(int id)
        {
            return _context.UserProfiles.Find(id);
        }

        public void Create(UserProfile item)
        {
            _context.UserProfiles.Add(item);
        }

        public void Update(UserProfile item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public void Delete(UserProfile item)
        {
            _context.UserProfiles.Remove(item);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}