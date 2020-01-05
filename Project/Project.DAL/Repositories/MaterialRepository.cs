using System.Collections.Generic;
using Project.DAL.Entities;
using Project.DAL.Interfaces;

namespace Project.DAL.Repositories
{
    public class MaterialRepository : IRepository<Material>
    {
        public IEnumerable<Material> ReadAll()
        {
            throw new System.NotImplementedException();
        }

        public Material Read(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Create(Material item)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Material item)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}