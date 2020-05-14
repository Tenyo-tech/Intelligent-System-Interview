namespace TaskManagement.Web.ViewModels.ISTasks
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TaskManagement.Data.Models;
    using TaskManagement.Services.Mapping;

    public class AllFinishedTasksViewModel : IMapFrom<ISTask>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Status Status { get; set; }
    }
}
