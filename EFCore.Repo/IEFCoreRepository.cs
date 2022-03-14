using EFCore.Dominio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Repo
{
    public interface IEFCoreRepository
    {
        //ENTIDADES GENERICAS
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;

        Task<bool> SaveChangesAsync();

        //HEROIS
        Task<IEnumerable<Heroi>> GetAllHerois(bool incluirBatalha = false);
        Task<Heroi> GetHeroiById(int id, bool incluirBatalha = false);
        Task<IEnumerable<Heroi>> GetHeroisByNome(string nome, bool incluirBatalha = false);

        //BATALHAS
        Task<IEnumerable<Batalha>> GetAllBatalhas(bool incluirHerois = false);
        Task<Batalha> GetBatalhaById(int id, bool incluirHerois = false);        
    }
}
