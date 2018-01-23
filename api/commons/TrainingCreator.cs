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
    public class TrainingCreator
    {
        private Training training;
        private List<TrainingTask> tasksList = new List<TrainingTask>();
        private DifficultyTranslator difficultyTranslator = new DifficultyTranslator();

        public TrainingCreator()
        {
            training = new Training();
        }

        public void SetVolume(TrainingDifficulties difficulty, int volume = 0)
        {
            training.CalculatedVolume = GetVolume(difficulty, volume);
        }


        public Training GetTraining()
        {
            training.TrainingTasks = tasksList;
            return training;
        }

        private int GetVolume(TrainingDifficulties difficulty, int volume)
        {
            TrainingBasicVolume basicVolume;
            if (volume != 0)
                basicVolume = new TrainingBasicVolume(volume);
            else
                basicVolume = difficultyTranslator.GetBasicVolume(difficulty);

            Random rand = new Random((int)DateTime.Now.Ticks);
            int minVolume = (basicVolume.BasicVolume - basicVolume.VolumeVariation);
            int maxVolume = basicVolume.BasicVolume + basicVolume.VolumeVariation;
            int randVolume = rand.Next(minVolume, maxVolume);
            int multi = randVolume / 100;
            return multi * 100;
        }
    }
}

