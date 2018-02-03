using api.commons;
using api.Models;
using api.repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace api.tests
{
    [TestClass]
    public class RepositoryTest
    {
        [DataTestMethod]
        [DataRow(TrainingDifficulty.Pro, 100)]
        [DataRow(TrainingDifficulty.Pro, 200)]
        [DataRow(TrainingDifficulty.Pro, 300)]
        [DataRow(TrainingDifficulty.Pro, 400)]
        [DataRow(TrainingDifficulty.SemiPro, 100)]
        [DataRow(TrainingDifficulty.Amateur, 100)]
        public void TestPreSwim(TrainingDifficulty difficulty, int volume)
        {
            TrainingTaskRepository rep = RepositoryTestHelper.GetRepository();
            TrainingTask task = rep.GetPreswim(difficulty, volume);
            Assert.AreEqual(volume, task.Volume);
        }
    }
}