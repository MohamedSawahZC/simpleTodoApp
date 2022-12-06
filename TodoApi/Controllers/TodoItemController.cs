using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/todo")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class TodoItemController : ControllerBase
    {
        List<TodoItem> items = new List<TodoItem>();
        public TodoItemController()
        {
            items.Add(new TodoItem { 
            Id=1,
            IsComplete=true,
            Name="Study"
            });
            items.Add(new TodoItem
            {
                Id = 2,
                IsComplete = false,
                Name = "Study 2"
            });
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(items);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = items.FirstOrDefault(a => a.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(item);
            }
        }
        [HttpPost]
        public IActionResult Post([FromBody]TodoItem todoItem)
        {
            items.Add(todoItem);
            return CreatedAtAction("GetById", new { id = todoItem.Id }, items);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id,[FromBody]TodoItem newItem)
        {
            var NewItem = items.Find(a => a.Id == id);
            if (NewItem == null)
            {
                return NotFound();
            }
            foreach(var item in items)
            {
                if(item.Id == id)
                {
                    item.Name = newItem.Name;
                }
            }
            return Ok(items);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var NewItem = items.Find(a => a.Id == id);
            if (NewItem == null)
            {
                return NotFound();
            }
            items.Remove(NewItem);
            return NoContent();

        }
    }
}
