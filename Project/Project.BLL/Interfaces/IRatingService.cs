using System.Collections.Generic;
using Project.BLL.DTO;

namespace Project.BLL.Interfaces
{
    public interface IRatingService
    {
        void Create(RatingDTO item);
    }
}