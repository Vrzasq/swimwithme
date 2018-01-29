using api.Models;


namespace api.commons
{
    public class Trainer
    {
        public Training MakeTraining(TrainingDifficulty difficulty, int volume = 0)
        {
            var creator = new TrainingCreator();
            creator.SetVolume(difficulty, volume);

            return creator.GetTraining();
        }
    }
}