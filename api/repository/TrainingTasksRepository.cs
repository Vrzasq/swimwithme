using System;
using System.Collections.Generic;
using System.Linq;
using api.commons;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.repository
{
    public class TrainignTasksRepository : ITrainingTaskRepository
    {
        //@repository @implementation
        private TrainingContext _contexct;
        private Random random = new Random((int)(DateTime.Now.Ticks >> 10));

        public TrainignTasksRepository(TrainingContext context)
        {
            _contexct = context;
        }

        public IList<TrainingTask> GetMain(TrainingDifficulty difficulty, int volume)
        {
            throw new System.NotImplementedException();
        }

        public TrainingTask GetPostSwim(TrainingDifficulty difficulty, int volume)
        {
            throw new System.NotImplementedException();
        }

        public TrainingTask GetPreswim(TrainingDifficulty difficulty, int volume)
        {
            if (volume < 100)
                volume = 100;

            var basicQuery = DifficultyTranslator.GetQueryBasedOnDifficulty(difficulty, _contexct);
            List<TrainingTask> tasks = basicQuery.Where(task => task.Volume == volume).ToList();

            if (tasks.Count == 0)
                return new TrainingTask();

            int taskIndex = random.Next(0, tasks.Count);

            return tasks[taskIndex];
        }

        public TrainingTask GetWarmaup(TrainingDifficulty difficulty, int volume)
        {
            throw new System.NotImplementedException();
        }
    }
}