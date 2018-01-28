using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using api.commons;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace api.Controllers
{
    public class TrainingTaskController : Controller
    {
        private readonly TrainingContext _context;

        public TrainingTaskController(TrainingContext context)
        {
            _context = context;
        }

        public string TestRouting()
        {
            return "hello xD";
        }

        [HttpGet]
        public JsonResult GetTraining(TrainingDifficulties difficulty, int volume = 0)
        {
            Trainer trainer = new Trainer(_context);
            Training training = trainer.MakeTraining(difficulty, volume);
            return Json(training);
        }

        [HttpGet]
        public JsonResult GetSpecyficTraining(int[] taskId)
        {
            List<int> test = new List<int>();
            for (int i = 0; i < taskId.Length; i++)
            {
                test.Add(taskId[i]);
            }

            return Json(test);
        }
    }
}

