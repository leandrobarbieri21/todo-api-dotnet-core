using System.Threading.Tasks;
using Xunit;
using Moq;
using Autofac.Extras.Moq;
using Todo.Data.Interfaces;
using Todo.Services;
using System.Collections.Generic;

namespace Todo.Services.Test.Unit
{
    public class TodoServiceTest
    {
        [Fact]
        public async Task ShouldCreateTask()
        {
            // Arrange
            var task = new Todo.Domain.Business.Todo
            {
                Title = "Task test",
                Completed = false
            };

            // Mock
            var mock = AutoMock.GetLoose();
            mock.Mock<ITodoRepository>()
            .Setup(
                x => x.Create(task)
            )
            .ReturnsAsync(
                task
            );

            var sut = mock.Create<TodoService>();

            // Act
            var newTask = await sut.Create(task);

            // Assert
            Assert.Equal(newTask, task);
        }

        [Fact]
        public async Task ShouldUpdateTask()
        {
            // Arrange
            var task = new Todo.Domain.Business.Todo
            {
                Id = "5d7d5d4ceb858f8944a3d2e0",
                Title = "Task test",
                Completed = true
            };

            // Mock
            var mock = AutoMock.GetLoose();
            mock.Mock<ITodoRepository>();

            var sut = mock.Create<TodoService>();

            // Act
            await sut.Update("5d7d5d4ceb858f8944a3d2e0", task);
        }

        [Fact]
        public async Task ShouldRemoveTask()
        {
            // Mock
            var mock = AutoMock.GetLoose();
            mock.Mock<ITodoRepository>();

            var sut = mock.Create<TodoService>();

            // Act
            await sut.Remove("5d7d5d4ceb858f8944a3d2e0");
        }

        [Fact]
        public async Task ShouldGetAllTask()
        {
            // Arrange
            var task1 = new Todo.Domain.Business.Todo
            {
                Id = "5d7d5d4ceb858f8944a3d2e0",
                Title = "Task test",
                Completed = true
            };

            var task2 = new Todo.Domain.Business.Todo
            {
                Id = "5d7d5d4ceb858f8944a3d2e0",
                Title = "Task test",
                Completed = true
            };

            var task3 = new Todo.Domain.Business.Todo
            {
                Id = "5d7d5d4ceb858f8944a3d2e0",
                Title = "Task test",
                Completed = true
            };

            // Mock
            var mock = AutoMock.GetLoose();
            mock.Mock<ITodoRepository>()
            .Setup(
                x => x.Get()
            )
            .ReturnsAsync(
                new List<Todo.Domain.Business.Todo>() { task1, task2, task3 }
            );

            var sut = mock.Create<TodoService>();

            // Act
            var listOfTasks = await sut.Get();

            // Assert
            Assert.Contains(task1, listOfTasks);
        }

        [Fact]
        public async Task ShouldGetOneTask()
        {
            // Arrange
            var task = new Todo.Domain.Business.Todo
            {
                Id = "5d7d5d4ceb858f8944a3d2e0",
                Title = "Task test",
                Completed = true
            };

            // Mock
            var mock = AutoMock.GetLoose();
            mock.Mock<ITodoRepository>()
            .Setup(
                x => x.Get("5d7d5d4ceb858f8944a3d2e0")
            )
            .ReturnsAsync(
                task
            );

            var sut = mock.Create<TodoService>();

            // Act
            var oneTask = await sut.Get("5d7d5d4ceb858f8944a3d2e0");

            // Assert
            Assert.Equal(task, oneTask);
        }
    }
}
