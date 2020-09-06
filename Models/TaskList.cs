using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TaskCore.Models
{
    public class TaskList
    {
        public int TaskListId { get; set; }
        public string TaskListName { get; set; }

        [ForeignKey("TaskListGroupId")]
        public TaskListGroup TaskListGroup { get; set; }
        public IList<TaskUnit> TaskUnits { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
