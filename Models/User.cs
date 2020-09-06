using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskCore.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public IList<TaskUnit> TaskUnits { get; set; }
        public IList<TaskList> TaskLists { get; set; }
        public IList<TaskListGroup> TaskListGroups { get; set; }
    }
}
