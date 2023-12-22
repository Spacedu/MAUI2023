using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTask.Models
{
    public class UserModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        public string Email { get; set; } = String.Empty;
        public string AccessToken { get; set; } = String.Empty;
        public DateTimeOffset AccessTokenCreated { get; set; }
        public DateTimeOffset Created { get; set; }
        public ICollection<TaskModel> Tasks { get; set; } = new List<TaskModel>();
    }
}
