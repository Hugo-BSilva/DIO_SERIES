using DIO.Series.Domain.Entities;
using DIO.Series.Interfaces;

namespace DIO.Series.Infrastructure.Repository;

public sealed class SerieRepository : ISerieRepository
{
    private readonly Dictionary<int, Serie> _serieDictionary = new();
    private int _nextId = 1;

    public IReadOnlyList<Serie> GetAll() => _serieDictionary.Values.OrderBy(s => s.Id).ToList();

    public Serie? GetById(int id) => _serieDictionary.GetValueOrDefault(id);

    public Serie Add(Serie entity)
    {
        var id = _nextId++;
        var nova = new Serie
        (
            id, 
            entity.Genre, 
            entity.Title, 
            entity.Description, 
            entity.Year
        );

        _serieDictionary[id] = nova;

        return nova;
    }

    public void Update(Serie entity)
    {
        if (!_serieDictionary.ContainsKey(entity.Id))
            throw new KeyNotFoundException($"Serie {entity.Id} not found.");

        _serieDictionary[entity.Id] = entity;
    }

    public void SoftDelete(int id)
    {
        if (_serieDictionary.TryGetValue(id, out var serie))
            serie.Delete();
    }

    public int NextId() => _nextId;
}