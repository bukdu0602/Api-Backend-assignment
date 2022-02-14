using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Api_day1_Assignment.Models;

namespace Web_Api_day1_Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : Controller
    {
        private readonly MyDbContext _context;

        public StoreController(MyDbContext context)
        {
            _context = context;
        }

        // GetAll() is automatically recognized as
        // http://localhost:<port #>/api/todo
        [HttpGet]
        [Route("produce")]
        public IEnumerable<Produce> GetAllProduce()
        {
            return _context.Produces.ToList();
        }
        [HttpGet]
        [Route("supplier")]
        public IEnumerable<Supplier> GetAllSupplier()
        {
            return _context.Suppliers.ToList();
        }
        [HttpGet]
        [Route("producesupplier")]
        public IEnumerable<ProduceSupplier> GetAllproduceSupplier()
        {
            return _context.ProduceSuppliers.ToList();
        }


        // GetById() is automatically recognized as
        // http://localhost:<port #>/api/todo/{id}

        [HttpGet("produce/{id}")]
        public IActionResult GetByIdproduce(long id)
        {
            var item = _context.Produces.FirstOrDefault(t => t.ProduceID == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }
        [HttpGet("supplier/{id}")]
        public IActionResult GetByIdSupplier(long id)
        {
            var item = _context.Suppliers.FirstOrDefault(t => t.SupplierID == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }
        [HttpGet("producesupplier/{id}/{id2}")]
        public IActionResult GetByIdProduceSupplier(long id, long id2)
        {
            var item = _context.ProduceSuppliers.FirstOrDefault(t => t.ProduceID == id && t.SupplierID == id2);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        //Crete-------------------------------------------
        [HttpPost]
        [Route("produce")]
        public IActionResult CreateProduce([FromBody] Produce produce)
        {
            if (produce.Description == null || produce.Description == "")
            {
                return BadRequest();
            }
            _context.Produces.Add(produce);
            _context.SaveChanges();
            return new ObjectResult(produce);
        }
        [HttpPost]
        [Route("supplier")]
        public IActionResult CreateSupplier([FromBody] Supplier supplier)
        {
            if (supplier.SupplierName == null || supplier.SupplierName == "")
            {
                return BadRequest();
            }
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();
            return new ObjectResult(supplier);
        }
        [HttpPost]
        [Route("producesupplier")]
        public IActionResult CreateProduceSupplier([FromBody] ProduceSupplier produceSupplier)
        {
            if (produceSupplier.ProduceID == null || produceSupplier.SupplierID == null || produceSupplier.Qty == null)
            {
                return BadRequest();
            }
            _context.ProduceSuppliers.Add(produceSupplier);
            _context.SaveChanges();
            return new ObjectResult(produceSupplier);
        }

        //putrequest --------------------------------------------
        [HttpPut]
        [Route("produce/myedit")] // Custom route
        public IActionResult GetByParamsProduce([FromBody] Produce produce)
        {
            var item = _context.Produces.Where(t => t.ProduceID == produce.ProduceID).FirstOrDefault();
            if (item == null)
            {
                return NotFound();
            }
            else
            {
                item.Description = produce.Description;
                _context.SaveChanges();
            }
            return new ObjectResult(item);
        }
        [HttpPut]
        [Route("supplier/myedit")] // Custom route
        public IActionResult GetByParamsSupplier([FromBody] Supplier supplier)
        {
            var item = _context.Suppliers.Where(t => t.SupplierID == supplier.SupplierID).FirstOrDefault();
            if (item == null)
            {
                return NotFound();
            }
            else
            {
                item.SupplierName = supplier.SupplierName;
                _context.SaveChanges();
            }
            return new ObjectResult(item);
        }
        [HttpPut]
        [Route("producesupplier/myedit")] // Custom route
        public IActionResult GetByParamsProduceSupplier([FromBody] ProduceSupplier produceSupplier)
        {
            var item = _context.ProduceSuppliers.Where(t => t.ProduceID == produceSupplier.ProduceID && t.SupplierID == produceSupplier.SupplierID).FirstOrDefault();
            if (item == null)
            {
                return NotFound();
            }
            else
            {
                item.Qty = produceSupplier.Qty;
                _context.SaveChanges();
            }
            return new ObjectResult(item);
        }
        [HttpDelete("produce/{id}")]
        public IActionResult MyDeleteProduce(int id)
        {
            //System.Threading.Thread.Sleep(1000);
            var item = _context.Produces.Where(t => t.ProduceID == id).FirstOrDefault();
            if (item == null)
            {
                return NotFound();
            }
            _context.Produces.Remove(item);
            _context.SaveChanges();
            return new ObjectResult(item);
        }
        [HttpDelete("supplier/{id}")]
        public IActionResult MyDeleteSupplier(int id)
        {
            //System.Threading.Thread.Sleep(1000);
            var item = _context.Suppliers.Where(t => t.SupplierID == id).FirstOrDefault();
            if (item == null)
            {
                return NotFound();
            }
            _context.Suppliers.Remove(item);
            _context.SaveChanges();
            return new ObjectResult(item);
        }
        [HttpDelete("producesupplier/{id}/{sId}")]
        public IActionResult MyDelete(int id, int sId)
        {
            var item = _context.ProduceSuppliers.Where(t => t.ProduceID == id && t.SupplierID == sId).FirstOrDefault();
            if (item == null)
            {
                return NotFound();
            }
            _context.ProduceSuppliers.Remove(item);
            _context.SaveChanges();
            return new ObjectResult(item);
        }

    }
}
