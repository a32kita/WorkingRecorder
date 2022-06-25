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
    public class WorkingTaskSourceSerializer : SerializerBase<WorkingTaskSource>
    {
        public static WorkingTaskSourceSerializer Instance
        {
            get;
            private set;
        }


        private WorkingTaskSourceSerializer()
        {
            // NOP
        }

        static WorkingTaskSourceSerializer()
        {
            Instance = new WorkingTaskSourceSerializer();
        }


        public override async Task<WorkingTaskSource> DeserializeFrom(Stream inputStream)
        {
            var result = await JsonSerializer.DeserializeAsync<WorkingTaskSource>(inputStream);
            return result;
        }

        public override async Task SerializeTo(Stream outputStream, WorkingTaskSource target)
        {
            await JsonSerializer.SerializeAsync(outputStream, target);
        }
    }
}
