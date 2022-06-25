using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

using WkRec.Entities;

namespace WkRec.Core
{
    public class AppStorage
    {
        // 公開プロパティ

        public string RootPath
        {
            get;
            private set;
        }

        public string RegisteredTasksDir
        {
            get;
            private set;
        }

        public string RegisteredTaskSourcesDir
        {
            get;
            private set;
        }

        public string RegisteredCostSourcesDir
        {
            get;
            private set;
        }

        public string RecordedResultDir
        {
            get;
            private set;
        }



        /// <summary>
        /// <see cref="AppStorage"/> クラスの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="rootPath"></param>
        public AppStorage(string rootPath)
        {
            this.RootPath = rootPath;
            this.RegisteredTasksDir = Path.Combine(rootPath, "regtasks");
            this.RegisteredTaskSourcesDir = Path.Combine(rootPath, "regtasksources");
            this.RegisteredCostSourcesDir = Path.Combine(rootPath, "regcostsources");
            this.RecordedResultDir = Path.Combine(rootPath, "recresults");

            foreach (var p in new string[]
            {
                this.RootPath,
                this.RegisteredTasksDir,
                this.RegisteredTaskSourcesDir,
                this.RegisteredCostSourcesDir,
                this.RecordedResultDir
            })
            {
                if (Directory.Exists(p) == false)
                    Directory.CreateDirectory(p);
            }
        }

        public async Task<IEnumerable<WorkingTask>> LoadWorkingTasks()
        {
            return await WorkingTaskSerializer.Singleton.DeserializeAllFrom(this.RegisteredTasksDir);
        }

        public async Task SaveWorkingTasks(IEnumerable<WorkingTask> tasks)
        {
            await WorkingTaskSerializer.Singleton.SerializeAllTo(this.RegisteredTasksDir, tasks);
        }

        public async Task<IEnumerable<WorkingTaskSource>> LoadWorkingTaskSources()
        {
            return await WorkingTaskSourceSerializer.Singleton.DeserializeAllFrom(this.RegisteredTaskSourcesDir);
        }

        public async Task SaveWorkingTaskSources(IEnumerable<WorkingTaskSource> taskSources)
        {
            await WorkingTaskSourceSerializer.Singleton.SerializeAllTo(this.RegisteredTaskSourcesDir, taskSources);
        }
    }
}
