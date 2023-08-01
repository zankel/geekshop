using AutoMapper;
using GGstore.ProductAPI.Data.ValueObjects;
using GGstore.ProductAPI.Model;
using GGstore.ProductAPI.Model.Context;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.X86;
using System;

namespace GGstore.ProductAPI.Repository
{
    public class GameRepository : IGameRepository
    {
        private readonly MySQLContext _context;
        private IMapper _mapper;

        public GameRepository(MySQLContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GameVO>> FindAll()
        {
            List<Game> games = await _context.Games
                .Include(g => g.GameGeneros).ThenInclude(gg => gg.Genero)
                .Include(g => g.GamePlataformas).ThenInclude(gg => gg.Plataforma)

                .ToListAsync();

            return _mapper.Map<List<GameVO>>(games);
        }

        public async Task<GameVO> FindById(long id)
        {
            Game game = await _context.Games.Where(p => p.Id == id)
            .FirstOrDefaultAsync() ?? new Game();
            return _mapper.Map<GameVO>(game);
        }

        public async Task<GameVO> Create(GameVO vo)
        {
            Game game = _mapper.Map<Game>(vo);
            _context.Games.Add(game);
            await _context.SaveChangesAsync();
            return _mapper.Map<GameVO>(game);
        }
        public async Task<GameVO> Update(GameVO vo)
        {
            Game game = _mapper.Map<Game>(vo);
            _context.Games.Update(game);
            await _context.SaveChangesAsync();
            return _mapper.Map<GameVO>(game);
        }

        public async Task<bool> Delete(long id)
        {
            try
            {
                Game game =
                await _context.Games.Where(p => p.Id == id)
                    .FirstOrDefaultAsync() ?? new Game();
                if (game.Id <= 0) return false;
                _context.Games.Remove(game);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
