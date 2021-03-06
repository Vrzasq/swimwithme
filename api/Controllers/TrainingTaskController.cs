using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using api.commons;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using api.repository;

namespace api.Controllers
{
    public class TrainingTaskController : Controller
    {
        private readonly ITrainingTaskRepository _ttr;

        public TrainingTaskController(ITrainingTaskRepository ttr)
        {
            _ttr = ttr;
        }

        [HttpGet]
        public string TestRouting()
        {
            return "hello xD";
        }

        [HttpGet]
        public JsonResult GetTraining(TrainingDifficulty diff, int vol = 0, string l = "pl")
        {
            Trainer trainer = new Trainer(_ttr);
            Training training = trainer.MakeTraining(diff, vol);
            return Json(training);
        }

        [HttpGet]
        public JsonResult GetSpecyficTraining(TrainingDifficulty diff, int[] id)
        {
            Trainer trainer = new Trainer(_ttr);
            Training training = trainer.MakeSpecyficTraining(diff, id);
            return Json(training);
        }
    }
}
