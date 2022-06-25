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
    public class WorkingTaskSerializer : SerializerBase<WorkingTask>
    {
        public static WorkingTaskSerializer Singleton
        {
            get;
            private set;
        }


        private WorkingTaskSerializer()
        {
            // NOP
        }

        static WorkingTaskSerializer()
        {
            Singleton = new WorkingTaskSerializer();
        }


        public override async Task<WorkingTask> DeserializeFrom(Stream inputStream)
        {
            var result = await JsonSerializer.DeserializeAsync<WorkingTask>(inputStream);
            return result;
        }

        public override async Task SerializeTo(Stream outputStream, WorkingTask target)
        {
            await JsonSerializer.SerializeAsync(outputStream, target);
        }
    }
}
