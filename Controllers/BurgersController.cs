using System.Collections.Generic;
using burgers.Services;
using Microsoft.AspNetCore.Mvc;
using burgers.Models;

namespace burgers.Controllers
{
    [ApiController]
    [Route("api/{controller}")]

    public class BurgersController : ControllerBase
    {
        private readonly BurgersService _bs;
        public BurgersController(BurgersService bs)
        {
            _bs = bs;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BurgersController>> Get()
        {
            try
            {
                return Ok(_bs.GetBurgers());
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Burger> GetBurgerById(int id)
        {
            try
            {
                Burger Burger = _bs.GetBurgerById(id);
                return Ok(Burger);
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPost]
        public ActionResult<Burger> Create([FromBody] Burger newBurger)
        {
            try
            {
                Burger Burger = _bs.Create(newBurger);
                return Ok(Burger);
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }
        [HttpPut("{id}")]
        public ActionResult<Burger> Edit([FromBody] Burger updated, int id)
        {
            try
            {
                updated.Id = id;
                Burger Burger = _bs.Edit(updated);
                return Ok(Burger);
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }
        [HttpDelete("{BurgerId}")]
        public ActionResult<string> Purchased(int BurgerId)
        {
            try
            {
                _bs.Delete(BurgerId);
                return Ok("Deleted");
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }

}