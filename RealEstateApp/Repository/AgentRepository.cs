using RealEstateApp.Interfaces;
using RealEstateApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace RealEstateApp.Repository
{
    public class AgentRepository : IAgentRepository
    {
        private readonly AppDbContext _context;

        public AgentRepository(AppDbContext context)
        {
            this._context = context;
        }

        public void Add(Agent agent)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Agent agent)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<Agent> GetAll()
        {
            return _context.Agenti;
        }

        public IQueryable<Agent> GetAllByAge()
        {
            return _context.Agenti.OrderByDescending(a => a.GodinaRodjenja);
        }

        public Agent GetById(int id)
        {
            return _context.Agenti.FirstOrDefault(a => a.Id == id);
        }

        public IQueryable<Agent> GetEkstremi()
        {
            List<Agent> agenti = new List<Agent>();
            int maximum = _context.Agenti.Select(a => a.BrojProdatihNekretnina).Max();
            int minimum = _context.Agenti.Select(a => a.BrojProdatihNekretnina).Min();

            Agent max = _context.Agenti.Where(a => a.BrojProdatihNekretnina == maximum).SingleOrDefault();
            Agent min = _context.Agenti.Where(a => a.BrojProdatihNekretnina == minimum).SingleOrDefault();

            agenti.Add(max);
            agenti.Add(min);

            return agenti.AsQueryable().OrderByDescending(a => a.BrojProdatihNekretnina);
        }

        public void Update(Agent agent)
        {
            throw new System.NotImplementedException();
        }
    }
}
