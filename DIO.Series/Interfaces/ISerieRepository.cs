using DIO.Series.Domain.Entities;

namespace DIO.Series.Interfaces;

public interface ISerieRepository
{
    IReadOnlyList<Serie> GetAll();
    Serie? GetById(int id);
    Serie Add(Serie entity);
    void Update(Serie entity);
    void SoftDelete(int id);
    int NextId();
}