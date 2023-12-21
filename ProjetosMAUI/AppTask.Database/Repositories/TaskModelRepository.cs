using AppTask.Database;
using AppTask.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTask.Database.Repositories
{
    public class TaskModelRepository : ITaskModelRepository
    {
        private AppTaskContext _db;
        public TaskModelRepository()
        {
            _db = new AppTaskContext();            
        }
        public IList<TaskModel> GetAll(Guid userId)
        {
            return _db.Tasks.Include(a => a.SubTasks).Where(a=>a.UserId == userId).OrderByDescending(a => a.PrevisionDate.ToString()).ToList();
        }
        public TaskModel GetById(Guid id)
        {
            return _db.Tasks.Include(a => a.SubTasks).FirstOrDefault(a=>a.Id == id);
        }
        public void Add(TaskModel task)
        {
            _db.Tasks.Add(task);
            _db.SaveChanges();
        }
        public void Update(TaskModel task)
        {
            _db.ChangeTracker.Clear();
            _db.Tasks.Update(task);
            _db.SaveChanges();
        }
        public void Delete(TaskModel task)
        {
            task = GetById(task.Id);
            foreach(var subtask in task.SubTasks)
            {
                _db.ChangeTracker.Clear();
                subtask.Deleted = DateTimeOffset.Now;
                _db.SubTasks.Update(subtask);
            }
            task.Updated = DateTimeOffset.Now;
            task.Deleted = DateTimeOffset.Now;

            _db.Tasks.Update(task);
            _db.SaveChanges();
        }

        public void Add(List<TaskModel> tasks)
        {
            _db.AddRange(tasks);
            _db.SaveChanges();
        }

        public void Update(List<TaskModel> tasks)
        {
            _db.UpdateRange(tasks);
            _db.SaveChanges();
        }
    }
}
