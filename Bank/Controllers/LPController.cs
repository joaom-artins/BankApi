using Bank.Context;
using Bank.Model;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LPController:ControllerBase
{
    private readonly AppDBContext _dbContext;

    public LPController(AppDBContext context)
    {
        _dbContext = context;
    }
    [HttpGet]
    public ActionResult<IEnumerable<LegalPerson>> Get()
    {
        var persons = _dbContext.LegalPersons.ToList();
        if (persons is null)
        {
            return NotFound("Não há contas");
        }
        return Ok(persons);
    }
    
    [HttpGet("{id:int}", Name = "GetLegalPerson")]
    public ActionResult<LegalPerson> Get(int id)
    {
        var personId = _dbContext.LegalPersons.Find(id);
        if (personId is null)
        {
            return BadRequest("Conta não encontrada");
        }
        return Ok(personId);
    }

    [HttpPost]
    public ActionResult Post(LegalPerson person)
    {
        if (person is null)
        {
            return BadRequest();
        }
        _dbContext.LegalPersons.Add(person);
        _dbContext.SaveChanges();
        return Ok(person);
    }
    [HttpPut("{id:int}")]
    public ActionResult Put(LegalPerson person, int id)
    {
        if (person.Id != id)
        {
            return BadRequest("Id's diferentes");
        }
        var personId = _dbContext.LegalPersons.Find(id);
        person.CNPJ = personId.CNPJ;
        person.CorporateReason = personId.CorporateReason;
        person.FantasyName = personId.FantasyName;
        person.Number = personId.Number;
        _dbContext.SaveChanges();
        return Ok(personId);
    }
    [HttpDelete ("{id:int}")]
    public ActionResult Delete(int id)
    {
        var person = _dbContext.LegalPersons.Find(id);
        if(person is null)
        {
            return BadRequest();
        }
        _dbContext.LegalPersons.Remove(person);
        _dbContext.SaveChanges();
        return NotFound();  
    }
    [HttpPut("{id:int}&{amount:double}", Name = "WihtdrawLegalPerson"), Tags("Withdraw")]
    public ActionResult<LegalPerson> WihtDraw(int id, double amount)
    {
        var person = _dbContext.LegalPersons.Find(id);
        if (person is null)
        {
            return BadRequest("Conta não encontrada");
        }
        person.Balance -= amount;
        _dbContext.SaveChanges();
        return Ok(person);
    }
    [HttpPut("{id:int}&&{amount:double}", Name = "DepositLegalPerson"), Tags("Deposit")]
    public ActionResult<LegalPerson> Deposit(int id, double amount)
    {
        var person = _dbContext.LegalPersons.Find(id);
        if (person is null)
        {
            return BadRequest("Conta não encontrada");
        }
        person.Balance += amount;
        _dbContext.SaveChanges();
        return Ok(person);
    }
}

