using Microsoft.EntityFrameworkCore;
using RealEstateApp.Interfaces;
using RealEstateApp.Models;
using System.Linq;

namespace RealEstateApp.Repository
{
    public class NekretninaRepository : INekretninaRepository
    {
        private readonly AppDbContext _context;

        public NekretninaRepository(AppDbContext context)
        {
            this._context = context;
        }

        public void Add(Nekretnina nekretnina)
        {
            _context.Add(nekretnina);
            _context.SaveChanges();
        }

        public void Delete(Nekretnina nekretnina)
        {
            _context.Remove(nekretnina);
            _context.SaveChanges();
        }

        public IQueryable<Nekretnina> GetAll()
        {
            return _context.Nekretnine.OrderByDescending(n => n.Cena);
        }

        public Nekretnina GetById(int id)
        {
            return _context.Nekretnine.Include(a => a.Agent).FirstOrDefault(n => n.Id == id);
        }

        public void Update(Nekretnina nekretnina)
        {
            _context.Entry(nekretnina).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public IQueryable<Nekretnina> GetByYearMade(int napravljeno)
        {
            return _context.Nekretnine.Include(a => a.Agent).Where(n => n.GodinaIzgradnje > napravljeno).OrderBy(n => n.GodinaIzgradnje);
        }

        public IQueryable<Nekretnina> GetAllByArea(int mini, int maksi)
        {
            return _context.Nekretnine.Where(n => n.Kvadratura >= mini && n.Kvadratura <= maksi).OrderBy(n => n.Kvadratura);
        }
    }
}
