using System.Collections.Generic;
using Project.BLL.DTO;

namespace Project.BLL.Interfaces
{
    public interface IMaterialService
    {
        void Create(MaterialDTO item, string author);
        MaterialDTO GetById(int id);
        IEnumerable<MaterialDTO> GetAll();
        void Remove(MaterialDTO item);
        void Update(MaterialDTO item);
        double GetRating(int materialId);
    }
}