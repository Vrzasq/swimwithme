using Microsoft.VisualStudio.TestTools.UnitTesting;
using api.Controllers;
using api.commons;
using Newtonsoft.Json;

namespace api.tests
{
    [TestClass]
    public class TrainingTaskControllerTest
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
            TrainingTaskController t = new TrainingTaskController();
            Training training = (Training)t.GetTraining(difficulty, volume).Value;
            int modulo100 = training.CalculatedVolume % 100;
            Assert.AreEqual(0, modulo100);
        }
    }
}
