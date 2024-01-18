using Bank.Context;
using Bank.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bank.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PPController : ControllerBase
{
    private readonly AppDBContext _dbContext;

    public PPController(AppDBContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PhysicalPerson>>> Get()
    {
        var persons = await _dbContext.PhysicalPersons.ToListAsync();
        if (persons is null)
        {
            return NotFound("Não há contas");
        }
        return Ok(persons);
    }

    [HttpGet("{id:int}", Name = "GetPhysicalPerson")]
    public async Task<ActionResult<PhysicalPerson>> Get(int id)
    {
        var personId = await _dbContext.PhysicalPersons.FindAsync(id);
        if (personId is null)
        {
            return BadRequest("Conta não encontrada");
        }
        return Ok(personId);
    }

    [HttpPost]
    public async Task<ActionResult<PhysicalPerson>> Post(PhysicalPerson person)
    {
        if (person is null)
        {
            return BadRequest();
        }
        await _dbContext.PhysicalPersons.AddAsync(person);
        await _dbContext.SaveChangesAsync();
        return Ok(person);
    }
    [HttpPut("{id:int}")]
    public async Task<ActionResult<PhysicalPerson>> Put(PhysicalPerson person, int id)
    {
        if (person.Id != id)
        {
            return BadRequest("Id's diferentes");
        }
        var personId = await _dbContext.PhysicalPersons.FindAsync(id);
        person.Number = personId.Number;
        person.Name = personId.Name;
        person.Birth = personId.Birth;
        person.CPF = personId.CPF;
        await _dbContext.SaveChangesAsync();
        return Ok(personId);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<PhysicalPerson>> Delete(int id)
    {
        var personId = await _dbContext.PhysicalPersons.FindAsync(id);
        if (personId is null)
        {
            return BadRequest("Conta não localizada");
        }
        _dbContext.PhysicalPersons.Remove(personId);
        await _dbContext.SaveChangesAsync();
        return NotFound();
    }

    [HttpPut("{id:int}&{amount:double}&{tax:double}", Name = "Wihtdraw"), Tags("Withdraw")]
    public async Task<ActionResult<PhysicalPerson>> WihtDraw(int id, double amount, double tax)
    {
        var person = await _dbContext.PhysicalPersons.FindAsync(id);
        if (person is null)
        {
            return BadRequest("Conta não encontrada");
        }
        double totalAmount = amount + tax;
        person.Balance -= totalAmount;
        await _dbContext.SaveChangesAsync();
        return Ok(person);
    }
    [HttpPut("{id:int}&&{amount:double}", Name = "Deposit"), Tags("Deposit")]
    public async Task<ActionResult<PhysicalPerson>> Deposit(int id, double amount)
    {
        var person =await _dbContext.PhysicalPersons.FindAsync(id);
        if (person is null)
        {
            return BadRequest("Conta não encontrada");
        }
        person.Balance += amount;
        await _dbContext.SaveChangesAsync();
        return Ok(person);
    }
}

