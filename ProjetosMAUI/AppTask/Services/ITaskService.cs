using AppTask.Models;

namespace AppTask.Services
{
    public interface ITaskService
    {
        Task Add(TaskModel task);
        Task BatchPush(List<TaskModel> tasks);
        Task Delete(Guid id);
        Task<List<TaskModel>> GetAll(Guid userId);
        Task Update(TaskModel task);
    }
}