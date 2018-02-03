using System;
using System.Collections.Generic;
using System.Linq;
using api.commons;
using api.Models;
using api.repository;
using api.tools;
using Microsoft.EntityFrameworkCore;

namespace api.tests
{
    public class RepositoryTestHelper
    {
        private static TrainingTaskRepository repo;

        public static TrainingTaskRepository GetRepository()
        {
            if (repo != null)
                return repo;

            repo = new TrainingTaskRepository(CreateContexct());
            MemoryDataLoader.LoadTestDataViaRepo(repo);
            return repo;
        }

        private static TrainingContext CreateContexct()
        {
            var options = new DbContextOptionsBuilder<TrainingContext>()
                                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                .Options;
            var context = new TrainingContext(options);
            return context;
        }

    }
}