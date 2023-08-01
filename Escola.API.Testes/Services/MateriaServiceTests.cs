using Escola.API.Exceptions;
using Escola.API.Interfaces.Repositories;
using Escola.API.Interfaces.Services;
using Escola.API.Model;
using Escola.API.Services;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.API.Testes.Services
{
    internal class MateriaServiceTests
    {
        [Test]
        public void MateriaNaoEhDuplicada()
        {
            //Arrange
            var materiaRepositoryMock = new Mock<IMateriaRepository>();
            materiaRepositoryMock.Setup(x => x.Inserir(It.IsAny<Materia>())).Returns<Materia>(x => x);

            var materiaService = new MateriaService(materiaRepositoryMock.Object);

            var materia = new Materia() { Nome = "SCRUM"};
            var expectedMateria = new Materia() { Nome = "SCRUM" };

            //Act
            var result = materiaService.Criar(materia);

            //Assert
            Assert.AreEqual(JsonConvert.SerializeObject(expectedMateria), JsonConvert.SerializeObject(result));
        }

        [Test]
        public void MateriaDuplicada_retornaError()
        {
            //Arrange
            var materiaRepositoryMock = new Mock<IMateriaRepository>();
            materiaRepositoryMock.Setup(x => x.MateriaJaCadastrada(It.IsAny<string>())).Returns<string>(x => true);

            var materiaService = new MateriaService(materiaRepositoryMock.Object);

            var materia = new Materia() { Nome = "SCRUM" };

            //Act & Assert
            var ex = Assert.Throws<RegistroDuplicadoException>(() =>
            {
                materiaService.Criar(materia);
            });

        }
    }   
}
