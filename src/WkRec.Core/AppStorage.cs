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

        public string RegisteredTaskCostSourcesDir
        {
            get;
            private set;
        }

        public string RegistetredTaskWbssDir
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
            this.RegisteredTaskCostSourcesDir = Path.Combine(rootPath, "regtaskcostsources");
            this.RegistetredTaskWbssDir = Path.Combine(rootPath, "regtaskwbss");
            this.RecordedResultDir = Path.Combine(rootPath, "recresults");

            foreach (var p in new string[]
            {
                this.RootPath,
                this.RegisteredTasksDir,
                this.RegisteredTaskSourcesDir,
                this.RegisteredTaskCostSourcesDir,
                this.RecordedResultDir
            })
            {
                if (Directory.Exists(p) == false)
                    Directory.CreateDirectory(p);
            }
        }

        public async Task<IEnumerable<WorkingTask>> LoadWorkingTasks()
        {
            return await WorkingTaskSerializer.Instance.DeserializeAllFrom(this.RegisteredTasksDir);
        }

        public async Task SaveWorkingTasks(IEnumerable<WorkingTask> tasks)
        {
            await WorkingTaskSerializer.Instance.SerializeAllTo(this.RegisteredTasksDir, tasks);
        }

        public async Task<IEnumerable<WorkingTaskSource>> LoadWorkingTaskSources()
        {
            return await WorkingTaskSourceSerializer.Instance.DeserializeAllFrom(this.RegisteredTaskSourcesDir);
        }

        public async Task SaveWorkingTaskSources(IEnumerable<WorkingTaskSource> taskSources)
        {
            await WorkingTaskSourceSerializer.Instance.SerializeAllTo(this.RegisteredTaskSourcesDir, taskSources);
        }

        public async Task<IEnumerable<WorkingTaskCostSource>> LoadWorkingTaskCostSources()
        {
            return await WorkingTaskCostSourceSerializer.Instance.DeserializeAllFrom(this.RegisteredTaskCostSourcesDir);
        }

        public async Task SaveWorkingTaskCostSources(IEnumerable<WorkingTaskCostSource> taskCostSources)
        {
            await WorkingTaskCostSourceSerializer.Instance.SerializeAllTo(this.RegisteredTaskCostSourcesDir, taskCostSources);
        }

        public async Task<IEnumerable<WorkingWbs>> LoadWorkingWbss()
        {
            return await WorkingWbsSerializer.Instance.DeserializeAllFrom(this.RegistetredTaskWbssDir);
        }

        public async Task SaveWorkingWbss(IEnumerable<WorkingWbs> taskWbss)
        {
            await WorkingWbsSerializer.Instance.SerializeAllTo(this.RegistetredTaskWbssDir, taskWbss);
        }
    }
}
