using Bank.Context;
using Bank.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PPController:ControllerBase
    {
        private readonly AppDBContext _dbContext;

        public PPController(AppDBContext context)
        {
            _dbContext = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PhysicalPerson>> Get()
        {
            var persons=_dbContext.PhysicalPersons.ToList();
            if(persons is null)
            {
                return NotFound("Não há contas");
            }
            return Ok(persons);
        }
       
        [HttpGet("{id:int}", Name = "GetPhysicalPerson")]
        public ActionResult<PhysicalPerson> Get(int id) 
        {
            var personId=_dbContext.PhysicalPersons.Find(id);
            if(personId is null)
            {
                return BadRequest("Conta não encontrada");
            }
            return Ok(personId);
        }

        [HttpPost]
        public ActionResult Post(PhysicalPerson person)
        {
            if(person is null)
            {
                return BadRequest();
            }
            _dbContext.PhysicalPersons.Add(person);
            _dbContext.SaveChanges();
            return Ok(person);
        }
        [HttpPut("{id:int}")]
        public ActionResult Put(PhysicalPerson person,int id) 
        {
            if(person.Id != id)
            {
                return BadRequest("Id's diferentes");
            }
            var personId = _dbContext.PhysicalPersons.Find(id);
            person.Name = personId.Name;
            person.Birth=personId.Birth;
            person.CPF=personId.CPF;
            _dbContext.SaveChanges();
            return Ok(personId);
        }

        [HttpDelete ("{id:int}")]
        public ActionResult Delete(int id)
        {
            var personId = _dbContext.PhysicalPersons.Find(id);
            if( personId is null)
            {
                return BadRequest("Conta não localizada");
            }
            _dbContext.PhysicalPersons.Remove(personId);
            _dbContext.SaveChanges();
            return NotFound();
        }
    }
}
