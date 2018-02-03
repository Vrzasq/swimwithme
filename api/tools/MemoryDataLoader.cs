using System;
using System.Collections.Generic;
using api.commons;
using api.Models;
using excelToolsCore.csvLoader;
using api.repository;

namespace api.tools
{
    public class MemoryDataLoader
    {
        public static void LoadTestDataViaRepo(ITrainingTaskRepository repository)
        {
            CsvLoader loader = new CsvLoader();
            var l = loader.GetData<TrainingTask, InMemoryTaskBuilder>(@"C:\Data\Development\swimwithme\api.tests\test_data\test_task_data.csv");
            repository.AddTasks(l);
        }
    }
}
