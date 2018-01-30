using Microsoft.VisualStudio.TestTools.UnitTesting;
using api.Controllers;
using api.commons;
using api.repository;
using Newtonsoft.Json;

namespace api.tests
{
    [TestClass]
    public class TrainerTest
    {
        [DataTestMethod]
        [DataRow(TrainingDifficulty.Pro, 0)]
        [DataRow(TrainingDifficulty.SemiPro, 0)]
        [DataRow(TrainingDifficulty.Amateur, 0)]
        [DataRow(TrainingDifficulty.Amateur, 6000)]
        [DataRow(TrainingDifficulty.Amateur, 3500)]
        [DataRow(TrainingDifficulty.Amateur, 1000)]
        public void TestCalculatedVolume(TrainingDifficulty difficulty, int volume = 0)
        {
            Trainer t = new Trainer();
            Training training = t.MakeTraining(difficulty, volume);
            int modulo100 = training.CalculatedVolume % 100;
            Assert.AreEqual(0, modulo100);
        }
    }
}
