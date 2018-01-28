using api.Models;


namespace api.commons
{
    public class Trainer
    {
        private readonly TrainingContext _context;

        public Trainer(TrainingContext context)
        {
            _context = context;
        }

        public Training MakeTraining(TrainingDifficulties difficulty, int volume = 0)
        {
            var creator = new TrainingCreator(_context);
            creator.SetVolume(difficulty, volume);

            return creator.GetTraining();
        }
    }
}