using GGstore.ProductAPI.Data.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GGstore.ProductAPI.Repository
{
    public interface IGameRepository
    {
        Task<IEnumerable<GameVO>> FindAll();
        Task<GameVO> FindById(long id);
        Task<GameVO> Create(GameVO vo);
        Task<GameVO> Update(GameVO vo);
        Task<bool> Delete(long id);
    }
}
