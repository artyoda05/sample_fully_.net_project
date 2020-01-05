using System.Collections.Generic;
using Project.DAL.Entities;
using Project.DAL.Interfaces;

namespace Project.DAL.Repositories
{
    public class UserRepository : IRepository<User>
    {


        public IEnumerable<User> ReadAll()
        {
            throw new System.NotImplementedException();
        }

        public User Read(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Create(User item)
        {
            throw new System.NotImplementedException();
        }

        public void Update(User item)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}