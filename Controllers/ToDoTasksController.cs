﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Laborator1.Data;
using Laborator1.Models;

namespace Laborator1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoTasksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ToDoTasksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ToDoTasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoTask>>> GetToDoTasks()
        {
            return await _context.ToDoTasks.ToListAsync();
        }

        // GET: api/ToDoTasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoTask>> GetToDoTask(int id)
        {
            var toDoTask = await _context.ToDoTasks.FindAsync(id);

            if (toDoTask == null)
            {
                return NotFound();
            }

            return toDoTask;
        }

        // PUT: api/ToDoTasks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutToDoTask(int id, ToDoTask toDoTask)
        {
            if (id != toDoTask.Id)
            {
                return BadRequest();
            }

            _context.Entry(toDoTask).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToDoTaskExists(id))
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

        // POST: api/ToDoTasks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ToDoTask>> PostToDoTask(ToDoTask toDoTask)
        {
            _context.ToDoTasks.Add(toDoTask);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetToDoTask", new { id = toDoTask.Id }, toDoTask);
        }

        // DELETE: api/ToDoTasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToDoTask(int id)
        {
            var toDoTask = await _context.ToDoTasks.FindAsync(id);
            if (toDoTask == null)
            {
                return NotFound();
            }

            _context.ToDoTasks.Remove(toDoTask);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ToDoTaskExists(int id)
        {
            return _context.ToDoTasks.Any(e => e.Id == id);
        }
    }
}
