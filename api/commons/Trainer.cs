using api.Models;
using api.repository;


namespace api.commons
{
    public class Trainer
    {
        private readonly ITrainingTaskRepository _ttr;
        private readonly string lang;

        public Trainer() { }

        public Trainer(ITrainingTaskRepository ttr, string lang = "pl")
        {
            _ttr = ttr;
            this.lang = lang;
        }

        public Training MakeTraining(TrainingDifficulty difficulty, int volume = 0)
        {
            var creator = new TrainingCreator(_ttr, lang);
            creator.SetDifficulty(difficulty);
            creator.SetVolume(difficulty, volume);
            creator.SetPreswim(difficulty);
            creator.CreateShareUrl();

            return creator.GetTraining();
        }

        public Training MakeSpecyficTraining(TrainingDifficulty difficulty, int[] id)
        {
            var creator = new TrainingCreator(_ttr, lang);
            return creator.GetSpecyficTraining(difficulty, id);
        }
    }
}
