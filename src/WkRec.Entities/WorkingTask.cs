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

        public Guid WbsIdentifier
        {
            get;
            set;
        }

        public WorkingTask[] ChildTasks
        {
            get;
            set;
        }

        public Guid Identifier
        {
            get;
            set;
        }
    }
}
