using System;
using System.Collections.Generic;
using System.Text;

namespace WkRec.Entities
{
    public class WorkingTask
    {
        // 公開プロパティ

        public WorkingTaskSource TaskSource
        {
            get;
            set;
        }

        public WorkingTaskCollection ChildTasks
        {
            get;
            private set;
        }


        // コンストラクタ

        public WorkingTask(WorkingTaskSource taskSource, IEnumerable<WorkingTask> childTasks)
        {
            this.TaskSource = taskSource;
            
            this.ChildTasks = new WorkingTaskCollection();
            this.ChildTasks.AddRange(childTasks);
        }

        public WorkingTask(WorkingTaskSource taskSource)
            : this(taskSource, new WorkingTask[0])
        {
            // NOP
        }
    }
}
