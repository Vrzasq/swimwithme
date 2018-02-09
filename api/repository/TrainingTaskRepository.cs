using System;
using System.Collections.Generic;
using System.Linq;
using api.commons;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.repository
{
    public class TrainingTaskRepository : ITrainingTaskRepository
    {
        //@repository @implementation
        private readonly TrainingContext _contexct;
        private Random random = new Random((int)(DateTime.Now.Ticks >> 10));

        public TrainingTaskRepository(TrainingContext context)
        {
            _contexct = context;
        }

        public TrainingTask GetTaskById(int id)
        {
            return _contexct.TrainingTasks.Find(id);
        }

        public void AddTask(TrainingTask task)
        {
            _contexct.TrainingTasks.Add(task);
            _contexct.SaveChanges();
        }

        public void AddTasks(IEnumerable<TrainingTask> tasks)
        {
            _contexct.TrainingTasks.AddRange(tasks);
            _contexct.SaveChanges();
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
            List<TrainingTask> tasks = basicQuery.Where(task => task.Volume == volume && task.IsPreswim).ToList();

            if (tasks.Count == 0)
            {
                basicQuery = DifficultyTranslator.GetQueryBasedOnDifficulty(difficulty, _contexct);
                tasks = basicQuery.Where(task => task.IsPreswim).ToList();
            }

            if (tasks.Count == 0)
                throw new Exception($"No preswim tasks available for diffculty : {difficulty}, volume : {volume}");

            int taskIndex = random.Next(0, tasks.Count);

            return tasks[taskIndex];
        }

        public TrainingTask GetWarmaup(TrainingDifficulty difficulty, int volume)
        {
            throw new System.NotImplementedException();
        }

    }
}
