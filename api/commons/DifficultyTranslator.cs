namespace api.commons
{


    public class DifficultyTranslator
    {
        public TrainingBasicVolume GetBasicVolume(TrainingDifficulties difficulty)
        {
            switch (difficulty)
            {
                case TrainingDifficulties.Amateur:
                    return TrainingBasicVolume.Amateur;
                case TrainingDifficulties.SemiPro:
                    return TrainingBasicVolume.SemiPro;
                case TrainingDifficulties.Pro:
                    return TrainingBasicVolume.Pro;
                default:
                    return null;
            }
        }


    }
}