using RealEstateApp.Models;
using System.Linq;

namespace RealEstateApp.Interfaces
{
    public interface IAgentRepository
    {
        IQueryable<Agent> GetAll();
        IQueryable<Agent> GetAllByAge();
        Agent GetById(int id);
        void Add(Agent agent);
        void Update(Agent agent);
        void Delete(Agent agent);
        IQueryable<Agent> GetEkstremi();
    }
}
