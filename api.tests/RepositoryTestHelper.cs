using System;
using System.Collections.Generic;
using System.Linq;
using api.commons;
using api.Models;
using api.repository;
using Microsoft.EntityFrameworkCore;

namespace api.tests
{
    public class RepositoryTestHelper
    {
        private static TrainignTasksRepository repo;

        public static TrainignTasksRepository GetRepository()
        {
            if (repo != null)
                return repo;

            repo = new TrainignTasksRepository(CreateContexct());
            return repo;
        }

        private static TrainingContext CreateContexct()
        {
            var options = new DbContextOptionsBuilder<TrainingContext>()
                                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                .Options;
            var context = new TrainingContext(options);
            MemoryDataLoader.LoadTestData(context);
            return context;
        }

    }
}