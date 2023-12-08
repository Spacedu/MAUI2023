using AppTask.API.Libraries.Constants;
using AppTask.Database.Repositories;
using AppTask.Models;
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

        public IActionResult ValidateAccessToken(UserModel userModel)
        {
            var user = _repository.GetByEmail(userModel.Email);
            
            if(user == null)
                return NotFound();

            if(user.AccessToken == userModel.AccessToken)
            {
                var tokenLimitHours = user.AccessTokenCreated.Add(Config.LimitAccessTokenCreated);
                var serverHours = DateTimeOffset.Now;

                if (tokenLimitHours <= serverHours) {
                    return Ok(user);
                }                
            }

            return BadRequest("AcessToken inválido ou vencido!");
        }
        
    }
}
