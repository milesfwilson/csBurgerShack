using System.Collections.Generic;
using csBurgerShack.Models;
using csBurgerShack.Services;
using Microsoft.AspNetCore.Mvc;

namespace csBurgerShack.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class BurgerController : ControllerBase
  {
    private readonly BurgerService _bs;
    public BurgerController(BurgerService bs)
    {
      _bs = bs;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Burger>> Get()
    {
      try
      {
        return Ok(_bs.GetAll());
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Burger> GetOne(int id)
    {
      try
      {
        return Ok(_bs.GetOne(id));
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }

    [HttpPost]
    public ActionResult<Burger> Create([FromBody] Burger newBurger)
    {
      try
      {
        return Ok(_bs.Create(newBurger));
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        return Ok(_bs.Delete(id));
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }

    [HttpPut("{id}")]
    public ActionResult<IEnumerable<Burger>> Edit([FromBody] Burger editedBurger, int id)
    {
      try
      {
        return Ok(_bs.Edit(editedBurger, id));
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }
  }
}