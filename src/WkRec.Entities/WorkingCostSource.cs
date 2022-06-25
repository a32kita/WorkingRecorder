﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WkRec.Entities
{
    public class WorkingCostSource : IWorkingEntity
    {
        public string Name
        {
            get;
            set;
        }

        public string Description
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
