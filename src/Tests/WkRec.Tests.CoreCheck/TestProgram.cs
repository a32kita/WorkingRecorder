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
            var workingTask = new WorkingTask("親タスク", workingTaskSourceIdentifier, new WorkingTask[]
            {
                new WorkingTask("子タスク 1", workingTaskSourceIdentifier),
                new WorkingTask("子タスク 2", workingTaskSourceIdentifier),
                new WorkingTask("子タスク 3", workingTaskSourceIdentifier),
            });

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
            Console.WriteLine("{0} ({1})", workingTask.Name, workingTask.ChildTasks.Count);

            foreach (var subWorkingTask in workingTask.ChildTasks)
            {
                PrintWorkingTask(subWorkingTask, depth + 1);
            }
        }
    }
}
