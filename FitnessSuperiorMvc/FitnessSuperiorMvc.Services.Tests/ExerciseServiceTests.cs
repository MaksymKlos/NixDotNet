using System.Collections.Generic;
using FitnessSuperiorMvc.DA.Entities.Sport;
using FitnessSuperiorMvc.DA.Interfaces;
using FitnessSuperiorMvc.Services.Programs;
using Moq;
using NUnit.Framework;

namespace FitnessSuperiorMvc.Services.Tests
{
    [TestFixture]
    public class ExerciseServiceTests
    {
        private const int Id = 1;

        private Mock<IRepository<Exercise>> _exerciseRepository;
        private Mock<IStaffRepository> _staffRepository;
        private ExerciseService _exerciseService;

        [SetUp]
        public void SetUp()
        {
            _exerciseRepository = new Mock<IRepository<Exercise>>();
            _staffRepository = new Mock<IStaffRepository>();
            _exerciseService = new ExerciseService(_exerciseRepository.Object, _staffRepository.Object);
        }

        [Test]
        public void GetAll_WhenCalled_ReturnsListOfExercises()
        {
            _exerciseRepository.Setup(er => er.GetAll())
                .Returns(new List<Exercise>());
            var list = _exerciseService.GetAll();
            _exerciseRepository.Verify(er=>er.GetAll());
            Assert.That(list,Is.TypeOf<List<Exercise>>());
        }

        [Test]
        public void GetAll_ListIsNull_ReturnsEmptyList()
        {
            _exerciseRepository.Setup(er => er.GetAll())
                .Returns(()=>null);
            var list = _exerciseService.GetAll();
            Assert.That(list, Is.TypeOf<List<Exercise>>());
        }
        [Test]
        public void GetById_WhenCalled_ReturnsExercise()
        {
            var exercise = new Exercise();
            _exerciseRepository.Setup(er => er.GetById(Id)).Returns(exercise);
            var receivedExercise = _exerciseService.GetById(Id);

            _exerciseRepository.Verify(er => er.GetById(Id));
            Assert.That(receivedExercise, Is.EqualTo(exercise));
        }
        [Test]
        public void GetById_ExerciseIsNull_ReturnsNull()
        {
            _exerciseRepository.Setup(er => er.GetById(Id)).Returns(()=>null);
            var receivedExercise = _exerciseService.GetById(Id);

            _exerciseRepository.Verify(er => er.GetById(Id));
            Assert.That(receivedExercise, Is.Null);
        }

        [Test]
        public void GetAddingExercises_TrainerIsNull_ThrowArgumentNullException()
        {
            Assert.That(()=>
                _exerciseService.GetAddingExercises(null),
                Throws.ArgumentNullException);
        }

    }
}
