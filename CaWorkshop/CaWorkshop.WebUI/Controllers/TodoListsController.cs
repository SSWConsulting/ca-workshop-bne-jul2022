using CaWorkshop.Application.TodoLists.Commands.CreateTodoList;
using CaWorkshop.Application.TodoLists.Commands.DeleteTodoList;
using CaWorkshop.Application.TodoLists.Commands.UpdateTodoList;
using CaWorkshop.Application.TodoLists.Queries.GetTodoLists;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CaWorkshop.WebUI.Controllers;

[Authorize]
public class TodoListsController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<TodosVm>> GetTodoLists()
    {
        return await Mediator.Send(new GetTodoListsQuery());
    }

    // POST: api/TodoLists
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    [ProducesResponseType(typeof(int),StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    
    public async Task<ActionResult<int>> PostTodoList(CreateTodoListCommand command)
    {
        return await Mediator.Send(command);
    }

    // PUT: api/TodoLists/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTodoList(int id, UpdateTodoListCommand command)
    {
        if (command.Id != id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }

    // DELETE: api/TodoLists/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTodoList(int id)
    {
        await Mediator.Send(new DeleteTodoListCommand { Id = id });

        return NoContent();
    }
}
