using Escola.API.Services;
using Escola.API.Interfaces.Repositories;
using Moq;
using Escola.API.Model;
using Escola.API.Interfaces.Services;
using Escola.API.Exceptions;
using NUnit.Framework.Internal;

namespace Escola.API.Testes.Services
{
    internal class NotasMediaServiceTests
    {
        [Test]
        public void CadastrarNotaMenorqueZero_returnError()
        {
            
            var notasMateriaRepositoryMock = new Mock<INotasMateriaRepository>();
            var boletimServiceMock = new Mock<IBoletimService>();
            var materiaServiceMock = new Mock<IMateriaService>();

            var notasMateriaService = new NotasMateriaService(notasMateriaRepositoryMock.Object, boletimServiceMock.Object, materiaServiceMock.Object);

            // Mockando o retorno dos serviços relacionados para evitar exceções de NotFound no teste
            boletimServiceMock.Setup(s => s.ObterPorId(It.IsAny<int>())).Returns(new Boletim());
            materiaServiceMock.Setup(s => s.ObterPorId(It.IsAny<int>())).Returns(new Materia());

            // Criação de uma nota com nota menor que -1
            var notasMateria = new NotasMateria
            {
                BoletimId = 1,
                MateriaId = 1,
                Nota = -5
            };

            // Assert
            // Verifica se o método Criar foi chamado com uma nota que atende à condição (nota >= 0)
            var ex = Assert.Throws<NotaInvalidaException>(() =>
            {
                notasMateriaService.Criar(notasMateria);
            });

        }

        [Test]
        public void CadastrarMaiorQueDez_returnError()
        {

            var notasMateriaRepositoryMock = new Mock<INotasMateriaRepository>();
            var boletimServiceMock = new Mock<IBoletimService>();
            var materiaServiceMock = new Mock<IMateriaService>();

            var notasMateriaService = new NotasMateriaService(notasMateriaRepositoryMock.Object, boletimServiceMock.Object, materiaServiceMock.Object);

            // Mockando o retorno dos serviços relacionados para evitar exceções de NotFound no teste
            boletimServiceMock.Setup(s => s.ObterPorId(It.IsAny<int>())).Returns(new Boletim());
            materiaServiceMock.Setup(s => s.ObterPorId(It.IsAny<int>())).Returns(new Materia());

            // Criação de uma nota com nota menor que -1
            var notasMateria = new NotasMateria
            {
                BoletimId = 1,
                MateriaId = 1,
                Nota = 15
            };

            // Assert
            // Verifica se o método Criar foi chamado com uma nota que atende à condição (nota <= 10)
            var ex = Assert.Throws<NotaInvalidaException>(() =>
            {
                notasMateriaService.Criar(notasMateria);
            });
        }
    } 
}
