using DIO.Series.Application.Services;
using DIO.Series.Domain.Entities;
using DIO.Series.Domain.Enum;
using DIO.Series.Interfaces;

namespace DIO.Series.ConsoleUI;

public class SerieConsoleApp
{
    private readonly SerieAppService _service;
    private readonly IConsole _console;

    public SerieConsoleApp(SerieAppService service, IConsole console)
    {
        _service = service;
        _console = console;
    }

    public void Run()
    {
        var actions = new Dictionary<MenuOption, Action>
            {
                { MenuOption.List, List},
                { MenuOption.Insert, Insert },
                { MenuOption.Update, Update },
                { MenuOption.Delete, Delete },
                { MenuOption.Leave, _console.Clear }
            };

        MenuOption option;
        do
        {            
            ShowMenu();
            var input = _console.ReadLine();
            _ = Enum.TryParse(input, out option);

            if (actions.TryGetValue(option, out var action))
            {
                _console.Clear();
                action();
            }
            else if (option != MenuOption.Leave)
            {
                _console.WriteLine("Opção inválida, tente novamente.");
            }

            
        } while (option != MenuOption.Leave);
    }

    private void List()
    {
        var listSeries = _service.List();

        if (listSeries.Count() == 0)
        {            
            _console.WriteLine("Ainda não há séries cadastradas.");
        }
        else
        {
            foreach (var serie in listSeries)
                _console.WriteLine(serie.ToString());
        }            
    }

    private void Insert()
    {        
        _console.WriteLine("> Insira uma nova série");
        _console.WriteLine("Título: ");
        string titulo = _console.ReadLine();

        _console.WriteLine("Descrição: ");
        string descricao = _console.ReadLine();

        _console.WriteLine("Ano: ");
        int ano = int.Parse(_console.ReadLine());

        ShowGenres();
        _console.WriteLine("Escolhe um gênero digitando o número: ");
        var genero = (Genre)int.Parse(_console.ReadLine());

        var novaSerie = new Serie(0, genero, titulo, descricao, ano);

        _service.Insert(novaSerie);
    }

    private void Update()
    {
        _console.WriteLine("Id da série: ");
        var id = int.Parse(_console.ReadLine());

        bool serieObtida = GetSerie(id);
        if (!serieObtida) return;        

        _console.WriteLine("Título: ");
        var titulo = _console.ReadLine();

        ShowGenres();
        _console.WriteLine("Escolhe um gênero digitando o número: ");
        var genero = (Genre)int.Parse(_console.ReadLine());

        _console.WriteLine("Descrição: ");
        var descricao = _console.ReadLine();

        _console.WriteLine("Ano: ");
        var ano = int.Parse(_console.ReadLine());

        _console.WriteLine("Excluída (true/false): ");
        bool excluida = bool.Parse(_console.ReadLine());

        _service.Update(id, genero, titulo, descricao, ano, excluida);
    }

    private void Delete()
    {
        _console.WriteLine("Id da série: ");
        var id = int.Parse(_console.ReadLine());

        bool serieObtida = GetSerie(id);
        if (!serieObtida) return;

        _service.Delete(id);
        _console.WriteLine("Série excluída com sucesso.");
    }

    private bool GetSerie(int id)
    {
        var serie = _service.GetById(id);
        if (serie == null)
        {
            _console.WriteLine("Série não encontrada.");
            return false;
        }

        return true;
    }
    
    private void ShowGenres()
    {
        foreach (var i in Enum.GetValues(typeof(Genre)))
        {
            _console.WriteLine($"{(int)i} - {i}");
        }
    }

    private void ShowMenu()
    {
        _console.WriteLine("Escolha uma opção:");
        _console.WriteLine("1 - Listar séries");
        _console.WriteLine("2 - Inserir nova série");
        _console.WriteLine("3 - Atualizar série");
        _console.WriteLine("4 - Excluir série");
        _console.WriteLine("5 - Limpar tela");
        _console.WriteLine("0 - Sair");
    }
}