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
        Random rand = new Random((int)(DateTime.Now.Ticks >> 10));
        private Training training;
        private List<TrainingTask> tasksList = new List<TrainingTask>();
        private readonly ITrainingTaskRepository _ttr;

        public TrainingCreator()
        {
            training = new Training();
        }


        public TrainingCreator(ITrainingTaskRepository ttr) : this()
        {
            _ttr = ttr;
        }

        public void SetDifficulty(TrainingDifficulty difficulty)
        {
            training.Difficulty = difficulty;
        }


        public void SetVolume(TrainingDifficulty difficulty, int volume)
        {
            training.CalculatedVolume = GetVolume(difficulty, volume);
        }

        public void SetPreswim(TrainingDifficulty difficulty, int maxRange = 0)
        {
            int volume = GetPreswimVolume(difficulty, maxRange);
            var preswim = _ttr.GetPreswim(difficulty, volume);
            tasksList.Add(preswim);
        }

        public Training GetSpecyficTraining(TrainingDifficulty difficulty, int[] id)
        {
            for (int i = 0; i < id.Length; i++)
            {
                var task = _ttr.GetTaskById(id[i]);
                if (task != null)
                    tasksList.Add(task);
            }

            training.TotalVolume = tasksList.Sum(x => x.Volume);
            training.TrainingTasks = tasksList;
            training.Difficulty = difficulty;
            return training;
        }


        public Training GetTraining()
        {
            training.TrainingTasks = tasksList;
            return training;
        }

        private int GetPreswimVolume(TrainingDifficulty difficulty, int maxRange)
        {
            int[] range = DifficultyTranslator.GetPreswimRange(difficulty, (maxRange / 100));
            int volume = rand.Next(range[0], range[1] + 1);
            return volume * 100;
        }

        private int GetVolume(TrainingDifficulty difficulty, int volume)
        {
            TrainingBasicVolume basicVolume;
            if (volume != 0)
                basicVolume = new TrainingBasicVolume(volume);
            else
                basicVolume = DifficultyTranslator.GetBasicVolume(difficulty);

            int minVolume = (basicVolume.BasicVolume - basicVolume.VolumeVariation);
            int maxVolume = basicVolume.BasicVolume + basicVolume.VolumeVariation + 100;
            int randVolume = rand.Next(minVolume, maxVolume);
            int multi = randVolume / 100;
            return multi * 100;
        }
    }
}
