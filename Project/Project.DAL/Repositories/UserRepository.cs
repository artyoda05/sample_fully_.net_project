using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using Project.DAL.Context;
using Project.DAL.Entities;
using Project.DAL.Interfaces;

namespace Project.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly EFContext _context;
        public UserRepository(EFContext context) => _context = context;
        public IEnumerable<UserProfile> ReadAll()
        {
            return _context.UserProfiles;
        }

        public UserProfile Read(string id)
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