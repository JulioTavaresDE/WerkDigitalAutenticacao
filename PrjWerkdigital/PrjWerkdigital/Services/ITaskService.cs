using PrjWerkdigital.Models;

namespace PrjWerkdigital.Services
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskModel>> GetTasks();
        Task<TaskModel> GetTask(int id);

        Task<IEnumerable<TaskModel>> GetTaskByName(string name);

        Task CreateTask(TaskModel task);

        Task UpdateTask(TaskModel task);
        Task DeleteTask(TaskModel task);
    }
}
