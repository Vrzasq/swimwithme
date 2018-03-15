using api.Models;
using api.repository;


namespace api.commons
{
    public class Trainer
    {
        private readonly ITrainingTaskRepository _ttr;
        private readonly string lang;

        public Trainer() { }

        public Trainer(ITrainingTaskRepository ttr)
        {
            _ttr = ttr;
        }

        public Trainer(ITrainingTaskRepository ttr, string lang = "pl") : this(ttr)
        {
            this.lang = lang;
        }

        public Training MakeTraining(TrainingDifficulty difficulty, int volume = 0)
        {
            var creator = new TrainingCreator(_ttr);
            creator.SetDifficulty(difficulty);
            creator.SetVolume(difficulty, volume);
            creator.SetPreswim(difficulty);

            return creator.GetTraining();
        }

        public Training MakeSpecyficTraining(TrainingDifficulty difficulty, int[] id)
        {
            var creator = new TrainingCreator(_ttr);
            return creator.GetSpecyficTraining(difficulty, id);
        }
    }
}
