using api.Models;
using System.Collections.Generic;

namespace api.repository
{
    public interface ITrainingTaskRepository
    {
        TrainingTask GetPreswim(TrainingDifficulty difficulty, int volume, string lang);
        TrainingTask GetWarmaup(TrainingDifficulty difficulty, int volume, string lang);
        IList<TrainingTask> GetMain(TrainingDifficulty difficulty, int volume, string lang);
        TrainingTask GetPostSwim(TrainingDifficulty difficulty, int volume, string lang);
        TrainingTask GetTaskById(int id);
        void AddTask(TrainingTask task);
        void AddTasks(IEnumerable<TrainingTask> tasks);
    }
}
