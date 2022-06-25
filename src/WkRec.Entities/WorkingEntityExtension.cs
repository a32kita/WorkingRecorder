using System;
using System.Collections.Generic;
using System.Text;

namespace WkRec.Entities
{
    public static class WorkingEntityExtension
    {
        public static bool EntityEquals(this IWorkingEntity obj1, IWorkingEntity obj2)
        {
            if (obj1 == null)
                throw new ArgumentNullException(nameof(obj1));

            return
                obj1.GetType().Equals(obj2.GetType()) &&
                obj1.Identifier.Equals(obj2.Identifier);
        }
    }
}
