using AppTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTask.Database.Repositories
{
    public interface ITaskModelRepository
    {
        IList<TaskModel> GetAll(Guid userId);
        TaskModel GetById(Guid id);
        void Add(TaskModel task);
        void Update(TaskModel task);
        void Add(List<TaskModel> tasks);
        void Update(List<TaskModel> tasks);
        void Delete(TaskModel task);
    }
}
