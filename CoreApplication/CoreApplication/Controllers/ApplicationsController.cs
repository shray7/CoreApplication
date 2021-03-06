﻿using System;
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
  [Route("api/[controller]")]
  public class ApplicationsController : Controller
  {
    private readonly CoreContext _context;

    public ApplicationsController(CoreContext context)
    {
      _context = context;
    }

    // GET: api/Applications
    [HttpGet]
    public IEnumerable<ClientApplication> GetApplication()
    {
      var acceptedApps = _context.Application.Where(x => x.IsAcceptable);
      var result = new List<ClientApplication>();
      foreach(var item in acceptedApps)
      {
        var questions = new List<ClientQuestion>();
        foreach(var answer in _context.Answer.Where(x=>x.Name == item.Name))
        {
          questions.Add(new ClientQuestion() { AnswerId = answer.AnswerId, UserAnswer = answer.Answer });
        }
        var clientApp = new ClientApplication() { Name = item.Name, Questions = questions };
        result.Add(clientApp);
      }
      return result;
    }
 
    // GET: api/Applications/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetApplication([FromRoute] int id)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var application = await _context.Application.SingleOrDefaultAsync(m => m.ApplicationId == id);

      if (application == null)
      {
        return NotFound();
      }

      return Ok(application);
    }

    // PUT: api/Applications/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutApplication([FromRoute] int id, [FromBody] Application application)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      if (id != application.ApplicationId)
      {
        return BadRequest();
      }

      _context.Entry(application).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ApplicationExists(id))
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

    // POST: api/Applications
    [HttpPost]
    public async Task<IActionResult> PostApplication([FromBody] Application application)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      _context.Application.Add(application);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetApplication", new { id = application.ApplicationId }, application);
    }

    // DELETE: api/Applications/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteApplication([FromRoute] int id)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var application = await _context.Application.SingleOrDefaultAsync(m => m.ApplicationId == id);
      if (application == null)
      {
        return NotFound();
      }

      _context.Application.Remove(application);
      await _context.SaveChangesAsync();

      return Ok(application);
    }

    private bool ApplicationExists(int id)
    {
      return _context.Application.Any(e => e.ApplicationId == id);
    }
  }
}