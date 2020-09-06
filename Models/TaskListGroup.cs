using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TaskCore.Models
{
    public class TaskListGroup
    {
        public int TaskListGroupId { get; set; }
        public string TaskListGroupName { get; set; }

        public IList<TaskList> TaskLists { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
