using System;
using api.Models;
using excelToolsCore.csvLoader;

namespace api.tools
{
    public class InMemoryTaskBuilder : ICsvDataBuilder<TrainingTask>
    {
        public TrainingTask Build(string[] data)
        {
            var task = new TrainingTask();
            task.ID = Convert.ToInt32(data[0]);
            task.Volume = Convert.ToInt32(data[2]);
            task.IsAmateur = data[4].ToBool();
            task.IsPro = data[5].ToBool();
            task.IsSemiPro = data[6].ToBool();
            task.IsPreswim = data[8].ToBool();

            return task;
        }
    }
}
