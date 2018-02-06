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

        public static int[] GetPreswimRange(TrainingDifficulty difficulty, int maxRange)
        {
            if (maxRange != 0)
                return new int[] { 1, maxRange };

            switch (difficulty)
            {
                case TrainingDifficulty.Amateur:
                    return new int[] { 1, 2 };
                case TrainingDifficulty.SemiPro:
                    return new int[] { 1, 3 };
                case TrainingDifficulty.Pro:
                    return new int[] { 2, 4 };
                default:
                    throw new ArgumentException(difficulty.ToString());
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
