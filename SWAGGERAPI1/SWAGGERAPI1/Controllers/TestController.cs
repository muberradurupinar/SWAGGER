using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWAGGERAPI1.Context;
using SWAGGERAPI1.Entity;

namespace SWAGGERAPI1.Controller
{
    [Route("api/Test")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private DBContext _contex;
        public TestController(DBContext contex)
        {
            _contex = contex;
        }

        [HttpGet("Get")]
        public IEnumerable<Urun> Get()
        {
            return _contex.Urun.ToList();
        }

        [HttpGet("Get/{id:int}")]
        public Urun Get(int id)
        {
            return _contex.Urun.FirstOrDefault(x => x.Id == id);
        }

        [HttpPost]
        public IActionResult Post(Urun urun)
        {
            try
            {
                _contex.Urun.AddAsync(urun);
                _contex.SaveChangesAsync();
                //return urun;
                return Ok("Success!");
            }
            catch (System.Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(Urun urun)
        {
            try
            {
                Urun urn = _contex.Urun.FirstOrDefault(d => d.Id == urun.Id);
                urn.Id = urun.Id;
                urn.Code = urun.Code;
                urn.Name = urun.Name;
                urn.Detay = urun.Detay;
                _contex.SaveChanges();
                return Ok("Success!");
            }
            catch (System.Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                Urun urn = _contex.Urun.FirstOrDefault(d => d.Id == id);
                _contex.Urun.Remove(urn);
                _contex.SaveChangesAsync();

                return Ok("Success!");
            }
            catch (System.Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }
    }
}
