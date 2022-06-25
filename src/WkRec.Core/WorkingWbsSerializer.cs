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
    public class WorkingWbsSerializer : SerializerBase<WorkingWbs>
    {
        public static WorkingWbsSerializer Instance
        {
            get;
            private set;
        }


        private WorkingWbsSerializer()
        {
            // NOP
        }

        static WorkingWbsSerializer()
        {
            Instance = new WorkingWbsSerializer();
        }


        public override async Task<WorkingWbs> DeserializeFrom(Stream inputStream)
        {
            var result = await JsonSerializer.DeserializeAsync<WorkingWbs>(inputStream);
            return result;
        }

        public override async Task SerializeTo(Stream outputStream, WorkingWbs target)
        {
            await JsonSerializer.SerializeAsync(outputStream, target);
        }
    }
}
