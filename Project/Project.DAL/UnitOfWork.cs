using System;
using System.Collections.Generic;
using System.Text;
using Project.DAL.Entities;
using Project.DAL.Interfaces;
using Project.DAL.Repositories;

namespace Project.DAL
{
    public class UnitOfWork: IUnitOfWork
    {

        private UserRepository _users;
        private MaterialRepository _materials;
        private RatingRepository _ratings;
        public IRepository<User> Users => _users;
        public IRepository<Material> Materials => _materials;
        public IRepository<Rating> Ratings => _ratings;
        public void Save()
        {
            throw new NotImplementedException();
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
