using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoreApplication.Data;
using CoreApplication.Models;

namespace CoreApplication.Controllers
{
  [Produces("application/json")]
  [Route("api/Answers")]
  public class AnswersController : Controller
  {
    private readonly CoreContext _context;

    public AnswersController(CoreContext context)
    {
      _context = context;
    }

    // GET: api/Answers
    [HttpGet]
    public IEnumerable<Answers> GetAnswer()
    {
      return _context.Answer;
    }

    // GET: api/Answers/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAnswer([FromRoute] int id)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var answer = await _context.Answer.SingleOrDefaultAsync(m => m.AnswerId == id);

      if (answer == null)
      {
        return NotFound();
      }

      return Ok(answer);
    }

    // PUT: api/Answers/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAnswer([FromRoute] int id, [FromBody] Answers answer)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      if (id != answer.AnswerId)
      {
        return BadRequest();
      }

      _context.Entry(answer).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!AnswerExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    // POST: api/Answers
    [HttpPost]
    public async Task<IActionResult> PostAnswer([FromBody] Answers[] answers)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      await _context.Answer.AddRangeAsync(answers);
      if (answers.All(x => x.AnsweredCorrectly))
      {
        _context.Application.Add(new Application() { IsAcceptable = true, Name = answers.FirstOrDefault().Name });
      }
      else
      {
        _context.Application.Add(new Application() { IsAcceptable = false, Name = answers.FirstOrDefault().Name });
      }
      await _context.SaveChangesAsync();

      return Ok("Success!");
    }

    // DELETE: api/Answers/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAnswer([FromRoute] int id)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var answer = await _context.Answer.SingleOrDefaultAsync(m => m.AnswerId == id);
      if (answer == null)
      {
        return NotFound();
      }

      _context.Answer.Remove(answer);
      await _context.SaveChangesAsync();

      return Ok(answer);
    }

    private bool AnswerExists(int id)
    {
      return _context.Answer.Any(e => e.AnswerId == id);
    }
  }
}