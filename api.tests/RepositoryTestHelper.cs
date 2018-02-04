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
        private static string connectionString = "Data Source=C:/Data/Development/swimwithme/api.tests/test_data/local.db;";

        public static TrainingTaskRepository GetRepository()
        {
            if (repo != null)
                return repo;

            repo = new TrainingTaskRepository(CreateContexct());
            return repo;
        }

        private static TrainingContext CreateContexct()
        {
            var options = new DbContextOptionsBuilder<TrainingContext>()
                                .UseSqlite(connectionString)
                                .Options;
            var context = new TrainingContext(options);
            return context;
        }

    }
}
