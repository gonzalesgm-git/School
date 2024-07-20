using Moq;
using School.Application.Commands.Students;
using School.Domain.Models;
using School.Infrastructure.Repositories;
using Xunit;

namespace School.Tests
{
    public class SaveStudentCommandHandlerTests
    {      
        [Fact]
        public async Task Handle_Should_Save_ValidStudent()
        {
            //Arrange
            var student = new Student()
            {
                PhoneNumber = "123",
                Email = "test@test.com",
                LastName = "testLastName",
                BirthDate = DateTime.Now.AddYears(20),
                FirstName = "testFirstName",
            };

            var mockStudentRepo = new Mock<IStudentRepository>();
            mockStudentRepo
                .Setup(x => x.SaveAsync(student))
                .ReturnsAsync(true);


            // Act
            var repo = new SaveStudentCommandHandler(mockStudentRepo.Object);
            var command = new SaveStudentCommand(student);
            var results = await repo.Handle(command, CancellationToken.None);

            // Assert
            Assert.NotNull(results);
            Assert.True(results.Success);
            Assert.False(results.IsFailed());
            Assert.Empty(results.Errors);
            mockStudentRepo.Verify(x => x.SaveAsync(student), Times.Once());
        }

        [Theory]
        [MemberData(nameof(InvalidStudents))]
        public async Task Handle_Should_NotSave_InvalidStudent(Student student, bool result)
        {
            //Arrange            
            var mockStudentRepo = new Mock<IStudentRepository>();
            mockStudentRepo
                .Setup(x => x.SaveAsync(student))
                .ReturnsAsync(result);


            // Act
            var repo = new SaveStudentCommandHandler(mockStudentRepo.Object);
            var command = new SaveStudentCommand(student);
            var results = await repo.Handle(command, CancellationToken.None);

            // Assert
            Assert.NotNull(results);
            Assert.Equal(results.Success, result);
            Assert.True(results.Errors.Count() > 0);
            mockStudentRepo.Verify(x => x.SaveAsync(student), Times.Never());
        }

        public static IEnumerable<object[]> InvalidStudents() =>
            new List<object[]>
            {
                    new object[] {
                        new Student { FirstName = "", LastName="qq", BirthDate=DateTime.Now, Email="q@test.com", Id=1, PhoneNumber="1"},
                        false
                    },
                    new object[] {
                        new Student { FirstName = "q", LastName="qq", BirthDate=DateTime.Now, Email="q@test.com", Id=1, PhoneNumber="1"},
                        false,
                    },
                    new object[] {
                        new Student { FirstName = "qqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqq", LastName="qq", BirthDate=DateTime.Now, Email="q@test.com", Id=1, PhoneNumber="1"},
                        false
                    },
            };


    }

   
}
