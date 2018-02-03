using System;
using System.Collections.Generic;
using System.Linq;
using api.Models;

namespace api.commons
{


    public class DifficultyTranslator
    {
        public static TrainingBasicVolume GetBasicVolume(TrainingDifficulty difficulty)
        {
            switch (difficulty)
            {
                case TrainingDifficulty.Amateur:
                    return TrainingBasicVolume.Amateur;
                case TrainingDifficulty.SemiPro:
                    return TrainingBasicVolume.SemiPro;
                case TrainingDifficulty.Pro:
                    return TrainingBasicVolume.Pro;
                default:
                    return null;
            }
        }

        public static IQueryable<TrainingTask> GetQueryBasedOnDifficulty(TrainingDifficulty difficulty, TrainingContext context)
        {
            switch (difficulty)
            {
                case TrainingDifficulty.Amateur:
                    return context.TrainingTasks.Where(diff => diff.IsAmateur);
                case TrainingDifficulty.SemiPro:
                    return context.TrainingTasks.Where(diff => diff.IsSemiPro);
                case TrainingDifficulty.Pro:
                    return context.TrainingTasks.Where(diff => diff.IsPro);

                default:
                    throw new ArgumentException(difficulty.ToString());
            }
        }


    }
}
