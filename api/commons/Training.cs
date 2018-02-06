using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace api.commons
{
    public class Training
    {
        private IEnumerable<TrainingTask> tasks;
        public IEnumerable<TrainingTask> TrainingTasks
        {
            get => tasks;
            set
            {
                tasks = value;
                TotalVolume = tasks.Sum(x => x.Volume);
            }
        }

        public int CalculatedVolume { get; set; }
        public int TotalVolume { get; set; }
        public TrainingDifficulty Difficulty { get; set; }
    }
}
