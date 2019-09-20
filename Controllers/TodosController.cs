using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using todos_full.Models;
using todos_full.Repositories;
using System.Security.Claims;


namespace todos_full.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly TodosRepository _tr;
        public TodosController(TodosRepository tr)
        {
            _tr = tr;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Todo>> Get()
        {
            return Ok(_tr.GetAll());

        }
        [HttpPost]
        public ActionResult<Todo> Create([FromBody]Todo newTodo)
        {

            return _tr.CreateTodo(newTodo);
        }
        [HttpDelete("{todoId}")]
        public ActionResult<Todo> Delete(string todoId)
        {
            bool success = _tr.DeleteTodo(todoId);
            if (success)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}