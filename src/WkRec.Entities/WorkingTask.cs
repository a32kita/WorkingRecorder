using System;
using System.Collections.Generic;
using System.Text;

namespace WkRec.Entities
{
    public class WorkingTask : IWorkingEntity
    {
        // 公開プロパティ

        public string Name
        {
            get;
            set;
        }

        public Guid TaskSourceIdentifier
        {
            get;
            set;
        }

        public WorkingTaskCollection ChildTasks
        {
            get;
            private set;
        }

        public Guid Identifier
        {
            get;
            set;
        }


        // コンストラクタ

        public WorkingTask(string name, Guid taskSourceIdentifier, IEnumerable<WorkingTask> childTasks)
        {
            this.Name = name;
            this.TaskSourceIdentifier = taskSourceIdentifier;
            this.Identifier = Guid.NewGuid();
            
            this.ChildTasks = new WorkingTaskCollection();
            this.ChildTasks.AddRange(childTasks);
        }

        public WorkingTask(string name, Guid taskSourceIdentifier)
            : this(name, taskSourceIdentifier, new WorkingTask[0])
        {
            // NOP
        }

        public WorkingTask()
            : this(null, Guid.Empty)
        {
            // NOP
        }


        // 公開メソッド

        public bool IdentifierEquals(IWorkingEntity other)
        {
            return this.GetType().Equals(other.GetType()) && this.Identifier.Equals(other.Identifier);
        }
    }
}
