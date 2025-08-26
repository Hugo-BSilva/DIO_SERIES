using Xunit;
using Moq;
using DIO.Series.Entities.Models;
using DIO.Series.Enum;
using DIO.Series.Interfaces;
using DIO.Series.Services;

namespace DIO.Series.Tests;

public class SerieManagerTests
{
    private readonly Mock<ISerieRepository> _repoMock;
    private readonly SerieManager _manager;

    public SerieManagerTests()
    {
        _repoMock = new Mock<ISerieRepository>();
        _manager = new SerieManager(_repoMock.Object);
    }

    [Fact]
    public void Listar_RetornaTodasSeries()
    {
        var lista = new List<Serie> { new Serie(1, Genero.Acao, "Titulo", "Desc", 2020) };
        _repoMock.Setup(r => r.GetAll()).Returns(lista);

        var result = _manager.Listar();

        Assert.Single(result);
        _repoMock.Verify(r => r.GetAll(), Times.Once);
    }

    [Fact]
    public void Inserir_DeveAdicionarSerie()
    {
        var nova = new Serie(1, Genero.Acao, "Titulo", "Desc", 2020);
        _repoMock.Setup(r => r.Add(It.IsAny<Serie>())).Returns(nova);

        var result = _manager.Inserir(nova);

        Assert.Equal(nova.Id, result.Id);
        _repoMock.Verify(r => r.Add(It.IsAny<Serie>()), Times.Once);
    }

    [Fact]
    public void Atualizar_SerieExistente_DeveRetornarTrue()
    {
        var serie = new Serie(1, Genero.Acao, "Old", "Old", 2000);
        _repoMock.Setup(r => r.GetById(1)).Returns(serie);

        var sucesso = _manager.Atualizar(1, Genero.Comedia, "Novo", "Nova Desc", 2021, false);

        Assert.True(sucesso);
        _repoMock.Verify(r => r.Update(serie), Times.Once);
        Assert.Equal("Novo", serie.Titulo);
    }

    [Fact]
    public void Atualizar_SerieNaoExistente_DeveRetornarFalse()
    {
        _repoMock.Setup(r => r.GetById(1)).Returns((Serie)null);

        var sucesso = _manager.Atualizar(1, Genero.Comedia, "Novo", "Desc", 2021, false);

        Assert.False(sucesso);
        _repoMock.Verify(r => r.Update(It.IsAny<Serie>()), Times.Never);
    }

    [Fact]
    public void Excluir_DeveChamarSoftDelete()
    {
        _manager.Excluir(1);
        _repoMock.Verify(r => r.SoftDelete(1), Times.Once);
    }
}
