using api.commons;
using api.Models;
using api.repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace api.tests
{
    [TestClass]
    public class RepositoryTest
    {
        [TestMethod]
        public void TestPreSwim()
        {
            var context = new TrainingContext();
            TrainignTasksRepository rep = new TrainignTasksRepository(context);
            TrainingTask task = rep.GetPreswim(TrainingDifficulty.Pro, 100);
            Assert.AreEqual<TrainingTask>(new TrainingTask(), task);
        }
        // @testPreswim
        // https://blog.learningtree.com/mock-entity-frameworks-dbcontext-unit-testing/
    }
}