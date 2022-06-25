using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WkRec.Core;
using WkRec.Entities;

namespace WkRec.Tests.CoreCheck
{
    internal class TestProgram
    {
        static void Main(string[] args)
        {
            var appDir = Path.GetDirectoryName(typeof(TestProgram).Assembly.Location);
            var appStorage = new AppStorage(Path.Combine(appDir, "storage"));

            var workingTaskSourceIdentifier = Guid.NewGuid();
            var workingTask = new WorkingTask()
            {
                Name = "親タスク",
                Identifier = Guid.NewGuid(),
                TaskSourceIdentifier = workingTaskSourceIdentifier,
                ChildTasks = new WorkingTask[]
                {
                    new WorkingTask() { Name = "子タスク 1", Identifier = workingTaskSourceIdentifier },
                    new WorkingTask() { Name = "子タスク 2", Identifier = workingTaskSourceIdentifier },
                    new WorkingTask() { Name = "子タスク 3", Identifier = workingTaskSourceIdentifier },
                    new WorkingTask() {
                        Name = "子タスク 4",
                        Identifier = workingTaskSourceIdentifier,
                        ChildTasks = new WorkingTask[]
                        {
                            new WorkingTask() { Name = "孫タスク 1", Identifier = workingTaskSourceIdentifier }
                        }
                    },
                    new WorkingTask() { Name = "子タスク 5", Identifier = workingTaskSourceIdentifier },
                    new WorkingTask() { Name = "子タスク 6", Identifier = workingTaskSourceIdentifier },
                }
            };

            appStorage.SaveWorkingTasks(new WorkingTask[] { workingTask }).Wait();
            var loadResult = appStorage.LoadWorkingTasks().Result;

            foreach (var task in loadResult)
            {
                PrintWorkingTask(task);
            }

            Console.WriteLine();
            Console.WriteLine("Completed !!");
            Console.ReadLine();
        }

        static void PrintWorkingTask(WorkingTask workingTask, int depth = 0)
        {
            for (var i = 0; i < depth; i++)
                Console.Write("  ");
            Console.WriteLine("{0} ({1})", workingTask.Name, workingTask.ChildTasks?.Length == null ? 0 : workingTask.ChildTasks.Length);

            if (workingTask.ChildTasks == null)
                return;

            foreach (var subWorkingTask in workingTask.ChildTasks)
            {
                PrintWorkingTask(subWorkingTask, depth + 1);
            }
        }
    }
}
