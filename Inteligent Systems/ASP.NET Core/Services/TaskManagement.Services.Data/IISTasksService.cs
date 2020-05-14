using TaskManagement.Web.ViewModels.ISTasks;

namespace TaskManagement.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IISTasksService
    {
        IEnumerable<T> GetAllUnfinishedTasks<T>(string userId);

        IEnumerable<T> GetAllFinishedTasks<T>(string userId);

        Task ArchiveTaskAsync(int id);

        Task AddTaskAsync(AddTaskInputModel model, string userId);

        Task EditTaskAsync(EditTaskInputModel model, string userId);

        T GetById<T>(int id);
    }
}
