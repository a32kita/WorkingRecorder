using System;
using System.Collections.Generic;
using System.Text;

namespace WkRec.Entities
{
    public class WorkingTaskCostSource : IWorkingEntity
    {
        public string Name
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
