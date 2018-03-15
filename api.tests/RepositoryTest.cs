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
        [DataRow(TrainingDifficulty.Pro, 100, "pl")]
        [DataRow(TrainingDifficulty.Pro, 200, "en")]
        [DataRow(TrainingDifficulty.Pro, 300, "pl")]
        [DataRow(TrainingDifficulty.Pro, 400, "en")]
        [DataRow(TrainingDifficulty.SemiPro, 100, "pl")]
        [DataRow(TrainingDifficulty.Amateur, 100, "en")]
        public void TestPreSwim(TrainingDifficulty difficulty, int volume, string lang)
        {
            TrainingTaskRepository rep = RepositoryTestHelper.GetRepository();
            TrainingTask task = rep.GetPreswim(difficulty, volume, lang);
            Assert.AreEqual(volume, task.Volume);
        }
    }
}
