using TaskManagement.Web.ViewModels.ISTasks;

namespace TaskManagement.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using TaskManagement.Data.Common.Repositories;
    using TaskManagement.Data.Models;
    using TaskManagement.Services.Mapping;

    public class ISTasksService : IISTasksService
    {
        private readonly IDeletableEntityRepository<ISTask> tasksRepository;

        public ISTasksService(IDeletableEntityRepository<ISTask> tasksRepository)
        {
            this.tasksRepository = tasksRepository;
        }

        public IEnumerable<T> GetAllUnfinishedTasks<T>(string userId) =>
            this.tasksRepository.All()
                .Where(x => x.UserId == userId && x.Status == Status.NotFinished)
                .To<T>()
                .ToList();

        public IEnumerable<T> GetAllFinishedTasks<T>(string userId) =>
            this.tasksRepository.All()
                .Where(x => x.UserId == userId && x.Status == Status.Finished)
                .To<T>()
                .ToList();

        public async Task ArchiveTaskAsync(int id)
        {
            this.tasksRepository
                .All()
                .FirstOrDefault(x => x.Id == id)
                .Status = Status.Finished;

            await this.tasksRepository.SaveChangesAsync();
        }

        public async Task AddTaskAsync(AddTaskInputModel model,string userId)
        {
            var task = new ISTask
            {
                Name = model.Name,
                Description = model.Description,
                Status = Status.NotFinished,
                UserId = userId,
            };

            await this.tasksRepository.AddAsync(task);
            await this.tasksRepository.SaveChangesAsync();
        }

        public async Task EditTaskAsync(EditTaskInputModel model, string userId)
        {
            this.tasksRepository.All().FirstOrDefault(x => x.Id == model.Id).Name = model.Name;
            this.tasksRepository.All().FirstOrDefault(x => x.Id == model.Id).Description = model.Description;

            await this.tasksRepository.SaveChangesAsync();
        }

        public T GetById<T>(int id)
        {
            var task = this.tasksRepository.All().Where(x => x.Id == id)
                .To<T>().FirstOrDefault();
            return task;
        }
    }
}
