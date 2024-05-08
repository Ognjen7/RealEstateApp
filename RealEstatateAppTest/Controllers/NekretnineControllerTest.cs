using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RealEstateApp.Controllers;
using RealEstateApp.Interfaces;
using RealEstateApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RealEstatateAppTest.Controllers
{
    public class NekretnineControllerTest
    {
        [Fact]
        public void GetNekretnina_ValidId_ReturnsObject()
        {
            // Arrange
            Nekretnina nekrenina = new Nekretnina()
            {
                Id = 1,
                Mesto = "MestoTest",
                AgencijskaOznaka = "Test",
                GodinaIzgradnje = 2000,
                Kvadratura = 200,
                Cena = 200000,
                AgentId = 1,
                Agent = new Agent { Id = 1, ImeIPrezime = "ImeIPrezimeTest", Licenca = "Test", GodinaRodjenja = 1980, BrojProdatihNekretnina = 10 }
            };

            NekretninaDTO nekretninaDTO = new NekretninaDTO()
            {
                Id = 1,
                Mesto = "MestoTest",
                AgencijskaOznaka = "Test",
                GodinaIzgradnje = 2000,
                Kvadratura = 200,
                Cena = 200000,
                AgentId = 1,
                AgentImeIPrezime = "ImeIPrezimeTest"
            };

            var mockRepository = new Mock<INekretninaRepository>();
            mockRepository.Setup(x => x.GetById(1)).Returns(nekrenina);

            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new NekretninaProfile()));
            IMapper mapper = new Mapper(mapperConfiguration);

            var controller = new NekretnineController(mockRepository.Object, mapper);

            // Act
            var actionResult = controller.GetNekretnina(1) as OkObjectResult;

            // Assert
            Assert.NotNull(actionResult);
            Assert.NotNull(actionResult.Value);

            NekretninaDTO dtoResult = (NekretninaDTO)actionResult.Value;
            Assert.Equal(nekrenina.Id, dtoResult.Id);
            Assert.Equal(nekrenina.Mesto, dtoResult.Mesto);
            Assert.Equal(nekrenina.AgencijskaOznaka, dtoResult.AgencijskaOznaka);
            Assert.Equal(nekrenina.GodinaIzgradnje, dtoResult.GodinaIzgradnje);
            Assert.Equal(nekrenina.Kvadratura, dtoResult.Kvadratura);
            Assert.Equal(nekrenina.Cena, dtoResult.Cena);
            Assert.Equal(nekrenina.AgentId, dtoResult.AgentId);
            Assert.Equal(nekrenina.Agent.ImeIPrezime, dtoResult.AgentImeIPrezime);
        }

        [Fact]
        public void DeleteNekretnina_InvalidId_ReturnsNotFound()
        {
            // Arrange
            var mockRepository = new Mock<INekretninaRepository>();

            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new NekretninaProfile()));
            IMapper mapper = new Mapper(mapperConfiguration);

            var controller = new NekretnineController(mockRepository.Object, mapper);

            // Act
            var actionResult = controller.DeleteNekretnina(12) as NotFoundResult;

            // Assert
            Assert.NotNull(actionResult);
        }

        [Fact]
        public void PutNekretnina_InvalidId_ReturnsBadRequest()
        {
            // Arrange
            Nekretnina nekrenina = new Nekretnina()
            {
                Id = 1,
                Mesto = "MestoTest",
                AgencijskaOznaka = "Test",
                GodinaIzgradnje = 2000,
                Kvadratura = 200,
                Cena = 200000,
                AgentId = 1,
                Agent = new Agent { Id = 1, ImeIPrezime = "ImeIPrezimeTest", Licenca = "Test", GodinaRodjenja = 1980, BrojProdatihNekretnina = 10 }
            };

            var mockRepository = new Mock<INekretninaRepository>();

            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new NekretninaProfile()));
            IMapper mapper = new Mapper(mapperConfiguration);

            var controller = new NekretnineController(mockRepository.Object, mapper);

            // Act
            var actionResult = controller.PutNekretnina(24, nekrenina) as BadRequestResult;

            // Assert
            Assert.NotNull(actionResult);
        }

    }
}
