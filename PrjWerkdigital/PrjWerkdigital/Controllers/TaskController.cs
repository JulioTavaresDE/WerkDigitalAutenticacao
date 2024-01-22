using Microsoft.AspNetCore.Mvc;
using PrjWerkdigital.Context;
using PrjWerkdigital.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using PrjWerkdigital.Services;
using System.Collections.Generic;

namespace PrjWerkdigital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private Context.AppDbContext _context;
        
        public TaskController(AppDbContext context)
        {
            _context = context;
        }

        //private ITaskService _taskService;

        //public TaskController(ITaskService taskService)
        //{
        //    _taskService = taskService;
        //}

        //[HttpGet]
        //public async Task<ActionResult<IAsyncEnumerable<TaskModel>>> GetTasks()
        //{
        //    try
        //    {
        //        var tasks = await _taskService.GetTasks();
        //        return Ok(tasks);
        //    }
        //    catch
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, "Erro tasks");
        //    }
        //}


        //[HttpGet("TaskByName")]
        //public async Task<ActionResult<IAsyncEnumerable<TaskModel>>> GetTaskByName([FromQuery] string name)
        //{
        //    try
        //    {
        //        var tasks = await _taskService.GetTaskByName(name);
        //        if (tasks == null)
        //        {
        //            return NotFound($"nao existem alunos om o criterio {name}");
        //        }

        //        return Ok(tasks);
        //    }
        //    catch
        //    {
        //        return BadRequest("Request Inavlido");
        //    }
        //}


        //[HttpGet("{id:int}", Name = "GetTask")]
        //public async Task<ActionResult<TaskModel>> GetTask(int id)
        //{
        //    try
        //    {
        //        var task = await _taskService.GetTask(id);
        //        if (task == null)
        //            return NotFound($"Nao foram enconrtaos tasks com o Id={id}");

        //        return Ok(task);
        //    }
        //    catch
        //    {

        //        return BadRequest("Request Invalido");
        //    }
        //}

        //[HttpPost]
        //public async Task<ActionResult> Create(TaskModel task)
        //{
        //    try
        //    {
        //        await _taskService.CreateTask(task);
        //        return CreatedAtRoute(nameof(GetTask), new { id = task.TaskId }, task);

        //    }
        //    catch
        //    {

        //        return BadRequest("Request Invalido");
        //    }
        //}


        //[HttpPut("{id:int}")]
        //public async Task<ActionResult> Edit(int id, [FromBody] TaskModel task)
        //{
        //    try
        //    {
        //        if (task.TaskId == id)
        //        {
        //            await _taskService.UpdateTask(task);
        //            return Ok($"Task com id = {id}  foi atulizacom com sucesso");

        //        }
        //        else
        //        {
        //            return BadRequest("Daos inconsistentes");
        //        }
        //    }
        //    catch
        //    {

        //        return BadRequest("Request Invalido");
        //    }
        //}


        //[HttpDelete("{id:int}")]
        //public async Task<ActionResult> Delete(int id)
        //{
        //    try
        //    {
        //        var task = await _taskService.GetTask(id);
        //        if (task != null)
        //        {
        //            await _taskService.DeleteTask(task);
        //            return Ok($"Task com id={id} excluido");
        //        }

        //        else
        //        {
        //            return Ok($"Task com id={id} nao encontrado");
        //        }
        //    }
        //    catch
        //    {

        //        return BadRequest("Request Invalido");
        //    }
        //}


        [HttpGet]
        public ActionResult<IEnumerable<TaskModel>> Get()
        {
            var tasks = _context.Tasks.ToList();
            if(tasks is null)
            {
                return NotFound();
            }
            return tasks;
        }

        [HttpGet("{id:int}",Name = "ReturnTask")]
        public ActionResult<TaskModel> Get(int id)
        {
            var tasks = _context.Tasks.FirstOrDefault(p => p.TaskId == id);
            if (tasks is null)
            {
                return NotFound();
            }
            return tasks;
        }

        [HttpPost]
        public ActionResult Post(TaskModel taskModel)
        {
            taskModel.UserId = 1;

            if (taskModel is null)
            {
                return BadRequest();
            }

            _context.Tasks.Add(taskModel);
            _context.SaveChanges();
            return new CreatedAtRouteResult("ReturnTask", new { id = taskModel.TaskId }, taskModel);            
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id,TaskModel taskModel)
        {
            if (id != taskModel.TaskId)
            {
                return BadRequest();
            }

            _context.Entry(taskModel).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok(taskModel);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var task = _context.Tasks.FirstOrDefault(t => t.TaskId == id);

            if(task is null)
            {
                return NotFound("Task not found");
            }
            _context.Tasks.Remove(task);
            _context.SaveChanges();

            return Ok(task);

        }


    }
}
