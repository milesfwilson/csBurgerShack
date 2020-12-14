using System;
using System.Collections.Generic;
using System.Data;
using csBurgerShack.Models;
using Dapper;

namespace csBurgerShack.Repositories
{
  public class BurgerRepository
  {
    private readonly IDbConnection _db;

    public BurgerRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Burger> GetAll()
    {
      string sql = "SELECT * FROM burgers";
      return _db.Query<Burger>(sql);
    }

    public Burger GetOne(int id)
    {
      string sql = "SELECT * FROM burgers WHERE id = @Id";
      return _db.QueryFirstOrDefault<Burger>(sql, new { id });
    }

    public Burger Create(Burger newBurger)
    {
      string sql = @"INSERT INTO burgers
      (title, price, toppings, isAvailable)
      VALUES
      (@Title, @Price, @Toppings, @IsAvailable);
      SELECT LAST_INSERT_ID();";
      newBurger.Id = _db.ExecuteScalar<int>(sql, newBurger);
      return newBurger;
    }

    public bool Delete(int id)
    {
      string sql = "DELETE FROM burgers WHERE id = @Id LIMIT 1";
      int affectedRows = _db.Execute(sql, new { id });
      return affectedRows > 0;
    }

    public Burger Edit(Burger editedBurger, int id)
    {
      string sql = "UPDATE burgers SET title = @Title, price = @Price, toppings = @Toppings, isAvailable = @IsAvailable WHERE id = @Id";
      _db.Execute(sql, editedBurger);
      return GetOne(id);
    }
  }
}