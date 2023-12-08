using AppTask.Database.Repositories;
using AppTask.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppTask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private ITaskModelRepository _repository;

        public TasksController(ITaskModelRepository repository)
        {
            _repository = repository;
        }

        //TODO - Obter todas as tarefas... (Celular Atualiza)
        [HttpGet]
        public IActionResult GetAll(Guid userId)
        {
            var users = _repository.GetAll(userId);

            if (users == null)
                return NotFound();

            return Ok(users);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var task = _repository.GetById(id);
            if (task == null)
                return NotFound();

            return Ok(task);
        }
        [HttpPost]
        public IActionResult Add(TaskModel task)
        {
            _repository.Add(task);
            return Ok(task);
        }

        [HttpPut]
        public IActionResult Update(TaskModel task)
        {
            _repository.Update(task);
            return Ok(task);
        }

        [HttpDelete]
        public IActionResult Delete(TaskModel task)
        {
            _repository.Delete(task);
            return Ok();
        }


        

        //Tablet e Celular
        //TODO - Enviar todas as tarefas localmente para o servidor... (Servidor Atualiza - Add, Update, Delete)
    }
}
