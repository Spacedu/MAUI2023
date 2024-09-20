using AppTask.Models;

namespace AppTask.Services
{
    public interface ITaskService
    {
        Task Add(TaskModel task);
        Task<List<TaskModel>> BatchPush(Guid userId, List<TaskModel> tasks);
        Task Delete(Guid id);
        Task<List<TaskModel>> GetAll(Guid userId);
        Task Update(TaskModel task);
    }
}