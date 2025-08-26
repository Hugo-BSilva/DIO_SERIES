using DIO.Series.Domain.Enum;
using DIO.Series.Domain.Entities;
using DIO.Series.Interfaces;

namespace DIO.Series.Application.Services;

public class SerieAppService
{
    private readonly ISerieRepository _repo;

    public SerieAppService(ISerieRepository repo)
    {
        _repo = repo;
    }

    public List<Serie> List() => (List<Serie>)_repo.GetAll();

    public Serie Insert(Serie serie)
    {
        var nova = new Serie(0, serie.Genre, serie.Title, serie.Description, serie.Year);
        if (serie.Deleted) nova.Delete();

        return _repo.Add(nova);
    }

    public bool Update(int id, Genre genre, string title, string description, int year, bool deleted)
    {
        var serie = _repo.GetById(id);
        if (serie == null) return false;

        serie.Update(genre, title, description, year);
        if (deleted) serie.Delete();

        _repo.Update(serie);
        return true;
    }

    public void Delete(int id) => _repo.SoftDelete(id);

    public Serie? GetById(int id) => _repo.GetById(id);
}