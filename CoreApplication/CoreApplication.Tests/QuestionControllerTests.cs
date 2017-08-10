using System;
using Xunit;
using CoreApplication;
using Microsoft.EntityFrameworkCore;
using CoreApplication.Data;
using CoreApplication.Models;
using CoreApplication.Controllers;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace CoreApplication.Tests
{
    public class QuestionControllerTests
    {
        private CoreContext _dbContext;
        [Fact]
        public void GetAll()
        {
            var obuilder = new DbContextOptionsBuilder<CoreContext>();
            obuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            _dbContext = new CoreContext(obuilder.Options);
            _dbContext.Question.Add(new Questions() { QuestionId = 1, Question = "WHat is your age", Answer = "21" });
            _dbContext.SaveChanges();
            var controller = new QuestionsController(_dbContext);
            var result = controller.GetQuestion();
            Assert.True(result.ToList().Count == 1);
        }
        [Fact]
        public void GetSingle()
        {
            var obuilder = new DbContextOptionsBuilder<CoreContext>();
            obuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            _dbContext = new CoreContext(obuilder.Options);
            _dbContext.Question.Add(new Questions() { QuestionId = 1, Question = "WHat is your age", Answer = "21" });
            _dbContext.Question.Add(new Questions() { QuestionId = 2, Question = "Why are you here", Answer = "help" });
            _dbContext.Question.Add(new Questions() { QuestionId = 3, Question = "DO you need help", Answer = "yes" });
            _dbContext.SaveChanges();
            var controller = new QuestionsController(_dbContext);
            var result = controller.GetQuestion(2);
            var ok = result.Result as OkObjectResult;
            Assert.NotNull(ok);
            var resultQuestion = (result.Result as OkObjectResult).Value as Questions;
            Assert.NotNull(resultQuestion);
            Assert.True(resultQuestion.QuestionId == 2);
        }
    }
}
