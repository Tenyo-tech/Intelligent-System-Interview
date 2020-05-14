using Microsoft.AspNetCore.Authorization;

namespace TaskManagement.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Server.IIS.Core;
    using TaskManagement.Data.Models;
    using TaskManagement.Services.Data;
    using TaskManagement.Web.ViewModels.ISTasks;

    public class ISTasksController : BaseController
    {
        private readonly IISTasksService isTasksService;
        private readonly UserManager<ApplicationUser> userManager;

        public ISTasksController(IISTasksService isTasksService, UserManager<ApplicationUser> userManager)
        {
            this.isTasksService = isTasksService;
            this.userManager = userManager;
        }

        [Authorize]
        public IActionResult AddTask()
        {

            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddTask(AddTaskInputModel model)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            await this.isTasksService.AddTaskAsync(model, user.Id);

            return this.RedirectToAction("ToDoList", "ISTasks");
        }

        [Authorize]
        public IActionResult EditTask(int taskId)
        {

            var viewModel = this.isTasksService.GetById<EditTaskViewModel>(taskId);

            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> EditTask(EditTaskInputModel model)
        {
            var user = await this.userManager.GetUserAsync(this.User);


            await this.isTasksService.EditTaskAsync(model, user.Id);


            return this.RedirectToAction("ToDoList", "ISTasks");
        }


        [Authorize]
        public async Task<IActionResult> ToDoList()
        {
            var user = await this.userManager.GetUserAsync(this.User);
            var viewModel = this.isTasksService.GetAllUnfinishedTasks<AllUnFinishedTasksViewModel>(user.Id);

            return this.View(viewModel);
        }

        [Authorize]
        public async Task<IActionResult> ArchivedTasks()
        {
            var user = await this.userManager.GetUserAsync(this.User);
            var viewModel = this.isTasksService.GetAllFinishedTasks<AllUnFinishedTasksViewModel>(user.Id);

            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Archive(FinishedTaskInputModel model)
        {
            await this.isTasksService.ArchiveTaskAsync(model.Id);
            int id = model.Id;
            return this.RedirectToAction("ToDoList", "ISTasks");
        }
    }
}
