using System;
using System.Collections.Generic;

using csBurgerShack.Models;
using csBurgerShack.Repositories;

namespace csBurgerShack.Services
{
  public class BurgerService
  {
    private readonly BurgerRepository _repo;
    public BurgerService(BurgerRepository repo)
    {
      _repo = repo;
    }
    public IEnumerable<Burger> GetAll()
    {
      return _repo.GetAll();
    }

    public Burger GetOne(int id)
    {
      Burger foundBurger = _repo.GetOne(id);
      if (foundBurger == null)
      {
        throw new Exception("There is no burger");
      }
      return foundBurger;
    }

    public Burger Create(Burger newBurger)
    {
      return _repo.Create(newBurger);
    }

    public string Delete(int id)
    {
      if (_repo.Delete(id))
      {
        return "Deleted!";
      }
      throw new Exception("Failure");

    }

    public Burger Edit(Burger editedBurger, int id)
    {
      Burger foundBurger = _repo.GetOne(id);
      editedBurger.Id = foundBurger.Id;
      editedBurger.Title = editedBurger.Title == null ? foundBurger.Title : editedBurger.Title;
      editedBurger.Price = editedBurger.Price == 0 ? foundBurger.Price : editedBurger.Price;
      editedBurger.Toppings = editedBurger.Toppings == null ? foundBurger.Toppings : editedBurger.Toppings;
      editedBurger.IsAvailable = editedBurger.IsAvailable == false ? foundBurger.IsAvailable : editedBurger.IsAvailable;

      return _repo.Edit(editedBurger, id);
    }
  }
}