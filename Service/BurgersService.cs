using System;
using System.Collections.Generic;
using burgers.Models;
using burgers.db;
using burgers.Repositories;

namespace burgers.Services
{
    public class BurgersService
    {
        private readonly BurgerRepository _repo;
        public BurgersService(BurgerRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Burger> GetBurgers()
        {
            return _repo.GetAll();
        }
        internal Burger GetBurgerById(int id)
        {
            Burger Burger = _repo.GetById(id);
            if (Burger == null)
            {
                throw new Exception("Invalid id");
            }
            return Burger;
        }

        internal Burger Create(Burger newBurger)
        {
            return _repo.Create(newBurger);
        }

        internal Burger Edit(Burger updated)
        {
            Burger original = GetBurgerById(updated.Id);

            original.name = updated.name != null ? updated.name : original.name;
            original.description = updated.description != null ? updated.description : original.description;
            original.price = updated.price > 0 ? updated.price : original.price;

            return _repo.Edit(original);
        }
        internal Burger Delete(int id)
        {
            Burger burger = GetBurgerById(id);
            _repo.Delete(burger);
            return burger;
        }
    }

}