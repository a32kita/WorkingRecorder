using System;
using System.Collections.Generic;
using System.Text;

namespace WkRec.Entities
{
    public class WorkingResult : IWorkingEntity
    {
        public WorkingTask Task
        {
            get;
            set;
        }

        public DateTime StartAt
        {
            get;
            set;
        }

        public DateTime CompleteAt
        {
            get;
            set;
        }

        public Guid Identifier
        {
            get;
            set;
        }


        // 公開メソッド

        public bool IdentifierEquals(IWorkingEntity other)
        {
            return this.GetType().Equals(other.GetType()) && this.Identifier.Equals(other.Identifier);
        }
    }
}
