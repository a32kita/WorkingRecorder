using System;
using System.Collections.Generic;
using System.Text;

namespace WkRec.Entities
{
    public interface IWorkingEntity
    {
        Guid Identifier { get; set; }

        bool IdentifierEquals(IWorkingEntity other);
    }
}
