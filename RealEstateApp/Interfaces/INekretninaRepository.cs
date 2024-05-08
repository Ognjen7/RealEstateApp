using RealEstateApp.Models;
using System.Linq;

namespace RealEstateApp.Interfaces
{
    public interface INekretninaRepository
    {
        IQueryable<Nekretnina> GetAll();
        Nekretnina GetById(int id);
        void Add(Nekretnina nekretnina);
        void Update(Nekretnina nekretnina);
        void Delete(Nekretnina nekretnina);
        IQueryable<Nekretnina> GetByYearMade(int napravljeno);
        IQueryable<Nekretnina> GetAllByArea(int mini, int maksi);
    }
}
