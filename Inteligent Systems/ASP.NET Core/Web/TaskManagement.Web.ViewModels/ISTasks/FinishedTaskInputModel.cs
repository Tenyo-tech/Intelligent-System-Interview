using System;
using System.Collections.Generic;
using System.Text;
using TaskManagement.Data.Models;
using TaskManagement.Services.Mapping;

namespace TaskManagement.Web.ViewModels.ISTasks
{
    public class FinishedTaskInputModel : IMapFrom<ISTask>
    {
        public int Id { get; set; }
    }
}
