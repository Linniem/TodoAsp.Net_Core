using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TaskCore.Models
{
    public class TaskUnit
    {
        public int TaskUnitId { get; set; }
        public string TaskName { get; set; }
        public bool IsComplete { get; set; }
        public bool IsImportant { get; set; }
        public DateTime? ExpiredTime { get; set; }
        public string Steps { get; set; }
        public DateTime? ExpiredTodayTime { get; set; }
        public string UserMemoText { get; set; }

        public int UserId { get; set; }

        [ForeignKey("TaskListId")]
        public TaskList TaskList { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
