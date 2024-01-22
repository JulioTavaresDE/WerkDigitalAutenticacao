using PrjWerkdigital.Context;
using PrjWerkdigital.Models;
using Microsoft.EntityFrameworkCore;

namespace PrjWerkdigital.Services
{
    public class TasksService : ITaskService
    {
        private readonly AppDbContext _context;

        public TasksService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TaskModel>> GetTasks()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<IEnumerable<TaskModel>> GetTaskByName(string name)
        {
            IEnumerable<TaskModel> tasks;
            if (!String.IsNullOrWhiteSpace(name))
            {
                tasks = await _context.Tasks.Where(n => n.Name.Contains(name)).ToListAsync();
            }

            else
            {
                tasks = await GetTasks();
            }
            return tasks;
        }


        public async Task<TaskModel> GetTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            return task;
        }

        public async Task CreateTask(TaskModel task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

        }

        public async Task UpdateTask(TaskModel task)
        {
            _context.Entry(task).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTask(TaskModel task)
        {
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
        }
    }
}