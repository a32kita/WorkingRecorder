using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

using WkRec.Entities;

namespace WkRec.Core
{
    public class WorkingTaskCostSourceSerializer : SerializerBase<WorkingTaskCostSource>
    {
        public static WorkingTaskCostSourceSerializer Instance
        {
            get;
            private set;
        }


        private WorkingTaskCostSourceSerializer()
        {
            // NOP
        }

        static WorkingTaskCostSourceSerializer()
        {
            Instance = new WorkingTaskCostSourceSerializer();
        }


        public override async Task<WorkingTaskCostSource> DeserializeFrom(Stream inputStream)
        {
            var result = await JsonSerializer.DeserializeAsync<WorkingTaskCostSource>(inputStream);
            return result;
        }

        public override async Task SerializeTo(Stream outputStream, WorkingTaskCostSource target)
        {
            await JsonSerializer.SerializeAsync(outputStream, target);
        }
    }
}
