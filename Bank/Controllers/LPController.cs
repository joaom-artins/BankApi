using Bank.Context;
using Bank.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bank.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LPController : ControllerBase
{
    private readonly AppDBContext _dbContext;

    public LPController(AppDBContext context)
    {
        _dbContext = context;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<LegalPerson>>> Get()
    {
        var persons = await _dbContext.LegalPersons.ToListAsync();
        if (persons is null)
        {
            return NotFound("Não há contas");
        }
        return Ok(persons);
    }

    [HttpGet("{id:int}", Name = "GetLegalPerson")]
    public async Task<ActionResult<LegalPerson>> Get(int id)
    {
        var personId = await _dbContext.LegalPersons.FindAsync(id);
        if (personId is null)
        {
            return BadRequest("Conta não encontrada");
        }
        return Ok(personId);
    }

    [HttpPost]
    public async Task<ActionResult<LegalPerson>> Post(LegalPerson person)
    {
        if (person is null)
        {
            return BadRequest();
        }
        await _dbContext.LegalPersons.AddAsync(person);
        await _dbContext.SaveChangesAsync();
        return Ok(person);
    }
    [HttpPut("{id:int}")]
    public async Task<ActionResult<LegalPerson>> Put(LegalPerson person, int id)
    {
        if (person.Id != id)
        {
            return BadRequest("Id's diferentes");
        }
        var personId = await _dbContext.LegalPersons.FindAsync(id);
        person.CNPJ = personId.CNPJ;
        person.CorporateReason = personId.CorporateReason;
        person.FantasyName = personId.FantasyName;
        person.Number = personId.Number;
        await _dbContext.SaveChangesAsync();
        return Ok(personId);
    }
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<LegalPerson>> Delete(int id)
    {
        var person = await _dbContext.LegalPersons.FindAsync(id);
        if (person is null)
        {
            return BadRequest();
        }
        _dbContext.LegalPersons.Remove(person);
        await _dbContext.SaveChangesAsync();
        return NotFound();
    }
    [HttpPut("{id:int}&{amount:double}", Name = "WihtdrawLegalPerson"), Tags("Withdraw")]
    public async Task<ActionResult<LegalPerson>> WihtDraw(int id, double amount)
    {
        var person = await _dbContext.LegalPersons.FindAsync(id);
        if (person is null)
        {
            return BadRequest("Conta não encontrada");
        }
        person.Balance -= amount;
        await _dbContext.SaveChangesAsync();
        return Ok(person);
    }
    [HttpPut("{id:int}&&{amount:double}", Name = "DepositLegalPerson"), Tags("Deposit")]
    public async Task<ActionResult<LegalPerson>> Deposit(int id, double amount)
    {
        var person = await _dbContext.LegalPersons.FindAsync(id);
        if (person is null)
        {
            return BadRequest("Conta não encontrada");
        }
        person.Balance += amount;
        await _dbContext.SaveChangesAsync();
        return Ok(person);
    }
}

