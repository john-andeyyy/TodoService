using Microsoft.AspNetCore.Mvc;
using Todo_Service.Models.Manager;
using Todo_Service.Models.Request;

namespace Todo_Service.Controllers
{
    [Route("api/Todo")]
    [ApiController]
    public class TodoController : Controller
    {
        [HttpGet("UserTodo/{Id}")]
        public IActionResult GetUsers([FromRoute] int Id)
        {
            var manager = new TodoManager();
            var userTodo = manager.UserTodo(Id);
            return Ok(new { Message = "List of User Todo/s", Data = userTodo });
        }

        [HttpPost("NewTodo")]
        public IActionResult CreateTodo([FromBody] NewTodo newTodo)
        {
            var manager = new TodoManager();
            var isOkay = manager.CreateTodo(newTodo);
            if (!isOkay)
            {
                return BadRequest(new { Message = "An error occurred while creating the todo." });
            }

            return Ok(new { Message = "Todo created successfully." });

        }

        [HttpGet("TodoID/{Id}")]
        public IActionResult GetTodoById([FromRoute] int Id)
        {
            var manager = new TodoManager();
            var userTodo = manager.GetTodoById(Id);
            return Ok(new { Data = userTodo });
        }

        [HttpPut("Update")]
        public IActionResult UpdateTodo([FromBody] UpdateTodo newTodo)
        {
            var manager = new TodoManager();
            var isOkay = manager.UpdateTodo(newTodo);
            if (!isOkay)
            {
                return BadRequest(new { Message = "An error occurred while creating the todo." });
            }

            return Ok(new { Message = "Todo Updated successfully." });

        }
        [HttpDelete("Delete/{Id}")]
        public IActionResult DeleteTodo([FromRoute] int Id)
        {
            var manager = new TodoManager();
            var userTodo = manager.Delete(Id);
            return Ok(new { Message = "Todo Deleted successfully." });
        }

        [HttpPut("IsCompleted")]
        public IActionResult IsCompleted([FromBody] UpdateTodo Update)
        {
            var manager = new TodoManager();
            var isOkay = manager.IsCompleted(Update);
            if (!isOkay)
            {
                return BadRequest(new { Message = "An error occurred while creating the todo." });
            }

            return Ok(new { Message = "Todo Updated successfully." });

        }
    }
}
