using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using api.Models;
using api.repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace api.commons
{
    public class TrainingCreator
    {
        private Training training;
        private List<TrainingTask> tasksList = new List<TrainingTask>();
        private ITrainingTaskRepository _ttr;

        public TrainingCreator()
        {
            training = new Training();
        }

        public TrainingCreator(ITrainingTaskRepository ttr) : this()
        {
            _ttr = ttr;
        }

        public void SetVolume(TrainingDifficulty difficulty, int volume)
        {
            training.CalculatedVolume = GetVolume(difficulty, volume);
        }


        public Training GetTraining()
        {
            //added two empty trainingtasks for testing
            tasksList.Add(new TrainingTask());
            tasksList.Add(new TrainingTask());
            training.TrainingTasks = tasksList;
            return training;
        }

        private int GetVolume(TrainingDifficulty difficulty, int volume)
        {
            TrainingBasicVolume basicVolume;
            if (volume != 0)
                basicVolume = new TrainingBasicVolume(volume);
            else
                basicVolume = DifficultyTranslator.GetBasicVolume(difficulty);

            Random rand = new Random((int)(DateTime.Now.Ticks >> 10));
            int minVolume = (basicVolume.BasicVolume - basicVolume.VolumeVariation);
            int maxVolume = basicVolume.BasicVolume + basicVolume.VolumeVariation;
            int randVolume = rand.Next(minVolume, maxVolume);
            int multi = randVolume / 100;
            return multi * 100;
        }
    }
}

