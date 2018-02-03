using api.Models;
using System.Collections.Generic;

namespace api.repository
{
    public interface ITrainingTaskRepository
    {
        TrainingTask GetPreswim(TrainingDifficulty difficulty, int volume);
        TrainingTask GetWarmaup(TrainingDifficulty difficulty, int volume);
        IList<TrainingTask> GetMain(TrainingDifficulty difficulty, int volume);
        TrainingTask GetPostSwim(TrainingDifficulty difficulty, int volume);
        void AddTask(TrainingTask task);
        void AddTasks(IEnumerable<TrainingTask> tasks);
    }
}
