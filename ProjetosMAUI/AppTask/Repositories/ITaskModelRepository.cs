using AppTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTask.Repositories
{
    public interface ITaskModelRepository
    {
        IList<TaskModel> GetAll();
        TaskModel GetById(int id);
        void Add(TaskModel task);
        void Update(TaskModel task);
        void Delete(TaskModel task);
    }
}
