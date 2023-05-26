using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TasksAPI.Core.Contracts;
using TasksAPI.Core.Models.Input;
using TasksAPI.Extensions;

namespace TasksAPI.Controllers;

[Authorize]
[Route("api/task")]
[ApiController]
public class TaskController : ControllerBase
{
    private ITaskService _taskService;
    private IUserService<string> _userService;


    public TaskController(ITaskService service, IUserService<string> userService)
    {
        _taskService = service;
        _userService = userService;
    }
    
    [HttpGet]
    [Route("all")]
    public IActionResult All()
    {
        return Ok();
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> Create([FromBody] TaskInputModel model)
    {
        if (!ModelState.IsValid)
        {
            return UnprocessableEntity(ModelState);
        }
        
        var itemId = await _taskService.Add(model, User.Id());
        
        if (itemId == -1)
        {
            return BadRequest();
        }

        return Ok($"Created with id: {itemId}");
    }

    [HttpGet]
    [Route("delete")]
    public async Task<IActionResult> Delete(int id)
    {
        if (!await _taskService.CheckIdExistence(id))
        {
            return NotFound();
        }

        var itemId = await _taskService.Delete(id, User.Id());
        if (itemId == -1)
        {
            return BadRequest();
        }
        
        return Ok($"Item with id {itemId} deleted.");
    }
}