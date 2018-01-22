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
        public IEnumerable<TrainingTask> TrainingTasks { get; set; }
    }
}