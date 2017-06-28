using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RecruitmentApp.Controllers;
using RecruitmentApp.DB.Repository;
using RecruitmentApp.Entities;
using Xunit;

namespace UnitTest
{
    public class ConsumerRepositoryUnitTest
    {
        [Fact]
        public async void CheckAddConsumerWithInvalidData()
        {
            //ARRANGE
            var mockedConsumerRepository = new Mock<IConsumerRepository>();

            var controller = new ConsumersController(mockedConsumerRepository.Object);
            //ACT
            var consumer = new Consumer();
            var result = await controller.Create(consumer);

            //ASSERT
            Assert.IsType<BadRequestResult>(result);
        }


        [Fact]
        public async void CheckAddConsumerWithValidData()
        {
            //ARRANGE
            var mockedConsumerRepository = new Mock<IConsumerRepository>();
            mockedConsumerRepository.Setup(mock => mock.Add(It.IsAny<Consumer>())).Returns(() => Task.FromResult(true));
            var controller = new ConsumersController(mockedConsumerRepository.Object);
            //ACT
            var consumer = new Consumer
            {
                Number = "123-123-123",
                Address = new Address {City = "Test", Street = "Test"}
            };
            var result = await controller.Create(consumer);

            //ASSERT
            mockedConsumerRepository.Verify(mock => mock.Add(It.IsAny<Consumer>()), Times.Once);
            Assert.IsType<RedirectToActionResult>(result);
        }


        [Fact]
        public void CheckReadAllConsumers()
        {
            //ARRANGE
            const int numberOfConsumers = 10;
            var mockedConsumerRepository = new Mock<IConsumerRepository>();
            mockedConsumerRepository.Setup(mock => mock.GetAll())
                .Returns(Enumerable.Repeat(new Consumer(), numberOfConsumers).ToList());
            var controller = new ConsumersController(mockedConsumerRepository.Object);
           
            //ACT
            var result = controller.Index();

            //ASSERT
            mockedConsumerRepository.Verify(mock => mock.GetAll(), Times.Once);
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Consumer>>(viewResult.ViewData.Model);
            Assert.Equal(numberOfConsumers, model.Count());
        }
    }
}