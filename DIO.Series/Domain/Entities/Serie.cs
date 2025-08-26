using DIO.Series.Domain.Enum;

namespace DIO.Series.Domain.Entities;

public class Serie : BaseEntity
{
    public Genre Genre { get; private set; }
    public string Title { get; private set; } = "";
    public string Description { get; private set; } = "";
    public int Year { get; private set; }
    public bool Deleted { get; private set; }

    public Serie(int id, Genre genre, string title, string description, int year)
    {
        Id = id;
        Genre = genre;
        Title = title;
        Description = description;
        Year = year;
        Deleted = false;
    }

    public void Update(Genre genre, string title, string description, int year)
    {
        Genre = genre;
        Title = title;
        Description = description;
        Year = year;
    }

    public void Delete() => Deleted = true;

    public override string ToString() => $"""
        ---------------------------------------
        Id: {Id}
        Gênero: {Genre}
        Título: {Title}
        Descrição: {Description}
        Ano de início: {Year}
        Excluído: {Deleted}
        ---------------------------------------
        """;
}