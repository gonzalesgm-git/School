using Moq;
using School.Application.Queries;
using School.Application.Queries.Students;
using School.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace School.Tests
{
    public class StudentListQueryHandlerTests
    {
        [Fact]
        public async Task Handle_Should_Return_Student_List()
        {
            //Arrange
            MockData mockData = new MockData();
            var mockStudentRepo = new Mock<IStudentRepository>();
            mockStudentRepo
                .Setup(x => x.GetAllAsync())
                .ReturnsAsync(mockData.GetStudents());
            

            // Act
            var repo = new StudentListQueryHandler(mockStudentRepo.Object);
            var request = new StudentListQuery();
            var results = await repo.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(results);
            Assert.Equal(mockData.GetStudents().Count(), results.Count());
            mockStudentRepo.Verify(x => x.GetAllAsync(), Times.Once());
        }
    }
}
