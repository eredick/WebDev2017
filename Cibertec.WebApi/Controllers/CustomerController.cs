using Cibertec.Models;
using Cibertec.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Cibertec.WebApi.Controllers
{
    [RoutePrefix("Customer")]
    public class CustomerController : BaseController
    {
        public CustomerController(IUnitOfWork unit) : base(unit)
        {
        }

        [Route("list")]
        public IHttpActionResult GetList()
        {
            return Ok(_unit.Customers.GetList());
        }

        [Route("list1")]
        public IHttpActionResult GetList1()
        {
            return Ok(_unit.Customers.GetList().Take(5));
        }

        public IHttpActionResult Get(string id)
        {
            var customer = _unit.Customers.GetByStringId(id);
            if (customer == null) return NotFound();
            return Ok(customer);
        }

        [HttpPost]
        public IHttpActionResult Post(Customer customer)//([FromUri]Customer customer)**para mandar parametros por url
        {
            if (!ModelState.IsValid) return BadRequest();
            var id = _unit.Customers.Insert(customer);
            return Ok(new { id });
        }

        [HttpPut]
        public IHttpActionResult Put(Customer customer)
        {
            if (!ModelState.IsValid) return BadRequest();
            if (!_unit.Customers.Update(customer)) return BadRequest("No existe un Customer con el ID indicado");
            return Ok(new { update = true });
        }

        [HttpDelete]
        public IHttpActionResult Delete(Customer customer)
        {
            if (!ModelState.IsValid) return BadRequest();
            var result = _unit.Customers.Delete(customer);
            return Ok(new { delete = result });
        }
    }
}
