using api.Models;
using api.repository;


namespace api.commons
{
    public class Trainer
    {
        private readonly ITrainingTaskRepository _ttr;

        public Trainer() { }

        public Trainer(ITrainingTaskRepository ttr)
        {
            _ttr = ttr;
        }

        public Training MakeTraining(TrainingDifficulty difficulty, int volume = 0)
        {
            var creator = new TrainingCreator();
            creator.SetVolume(difficulty, volume);

            return creator.GetTraining();
        }
    }
}