using AppTask.Database.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppTask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public IUserModelRepository _repository;

        public UsersController(IUserModelRepository repository)
        {
            _repository = repository;
        }

        public IActionResult GetUser(string email)
        {
            var user = _repository.GetByEmail(email);
            if (user == null)
            {
                //TODO - Usuário não existe, faça o cadastro, Gerar o AccessToken
            }
            else
            {
                //TODO - Usuário existe, gerar um novo AccessToken
            }

            //TODO - Enviar o e-mail

            return Ok(user);
        }
    }
}
