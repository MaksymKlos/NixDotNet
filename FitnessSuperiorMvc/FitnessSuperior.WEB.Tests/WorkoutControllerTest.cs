using System;
using System.Collections.Generic;
using System.Xml;
using FitnessSuperiorMvc.DA.Entities.Sport;
using FitnessSuperiorMvc.Services.Programs;
using FitnessSuperiorMvc.WEB.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NSubstitute;
using Xunit;

namespace FitnessSuperior.WEB.Tests
{
    public class WorkoutControllerTest
    {
        [Fact]
        public void Test()
        {
            //Arrange
            //Act
            //Assert
        }
        //[Fact]
        //public void Exercises_ReturnsViewResult_WithListOfExercises()
        //{
        //    //Arrange
        //    var exerciseServiceMock = Substitute.For<ExerciseService>();
        //    exerciseServiceMock.GetAll().Returns(GetExerciseList());
        //    var controller = new WorkoutController(null, null,exerciseServiceMock,null,null,null,null);
        //    var homeController = new HomeController(null);
        //    // Act
        //    //var result = controller.ExerciseView(1, null) as View;
        //    var result = homeController.Index() as ViewResult;
            

        //    // Assert
        //    var exercise = new Exercise("aaasd", "asfasf", "asfasf");
        //    var viewResult = Assert.Equal(exercise.Name,"aaasd");
        //    //Assert.IsAssignableFrom<Exercise>(viewResult.ViewData.Model);
        //}
        //private List<Exercise> GetExerciseList()
        //{
        //    return new List<Exercise>() { new Exercise("sds","dsd","sdsd"), new Exercise("sssds", "dffasd", "sds2fad"), new Exercise("sdffss", "dsd2e", "sdwf2sd") };
        //}
    }
}
