using AppTask.API.Libraries.Constants;
using AppTask.Database.Repositories;
using AppTask.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AppTask.API.Libraries.Text;
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
                user = new UserModel()
                {
                    Email = email,
                    AccessToken = String.Empty.GenerateHash(4),
                    AccessTokenCreated = DateTimeOffset.Now,
                    Created = DateTimeOffset.Now,
                };

                _repository.Add(user);
            }
            else
            {
                user.AccessToken = String.Empty.GenerateHash(4);
                user.AccessTokenCreated = DateTimeOffset.Now;

                _repository.Update(user);
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
