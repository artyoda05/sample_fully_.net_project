using Project.DAL.Entities;
using Project.DAL.Interfaces;
using Project.DAL.Context;
using System.Data.Entity;

namespace Project.DAL.Repositories
{
    public class MaterialRepository : IRepository<Material>
    {
        private readonly EFContext _context;
        public MaterialRepository(EFContext context) => _context = context;
        
        public Material Read(int id)
        {
            return _context.Materials.Find(id);
        }

        public void Create(Material item)
        {
            _context.Materials.Add(item);
        }

        public void Update(Material item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public void Delete(Material item)
        {
            _context.Materials.Remove(item);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}