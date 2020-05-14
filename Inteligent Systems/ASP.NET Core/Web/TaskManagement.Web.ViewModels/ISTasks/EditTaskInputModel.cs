using System;
using System.Collections.Generic;
using System.Text;
using TaskManagement.Data.Models;
using TaskManagement.Services.Mapping;

namespace TaskManagement.Web.ViewModels.ISTasks
{
    public class EditTaskInputModel : IMapTo<ISTask>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
