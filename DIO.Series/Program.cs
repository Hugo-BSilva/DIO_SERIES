using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();                        
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        System.Console.Clear();
                        break;
                    case "X":
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static void ListarSeries()
        {
            System.Console.WriteLine("-> Listar Séries <-");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                System.Console.WriteLine(" - Nenhuma Série Cadastrada. ");
                return;
            }

            foreach (var serie in lista)
            {
                var serieExcluido = serie.RetornaExcluido();
                System.Console.WriteLine("#ID {0}: {1} - {2}", serie.RetornaId(), serie.RetornaTitulo(), 
                serieExcluido? "X Série Excluida X" : "");
            }
        }

        private static void InserirSerie()
        {
            //GetValues percorre toda classe Genero buscando os valores de cada genero
            //GetName percorre pegando todos os nomes de genero
            System.Console.WriteLine("-> Inserir Nova Série <-");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine("{0} - {1} ", i, Enum.GetName(typeof(Genero), i));
            }

            System.Console.WriteLine();
            System.Console.Write("Gênero(digite o número): ");
            int inputGenero = int.Parse(Console.ReadLine());

            System.Console.Write("Titulo: ");
            string inputTitulo = Console.ReadLine();

            System.Console.Write("Ano: ");
            int inputAno = int.Parse(Console.ReadLine());

            System.Console.Write("Descrição: ");
            string inputDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(), 
                                        genero: (Genero)inputGenero,
                                        titulo: inputTitulo,
                                        ano: inputAno,
                                        descricao: inputDescricao);
            repositorio.Insere(novaSerie);
        }

        private static void AtualizarSerie()
        {
            System.Console.WriteLine("-> Atualizar uma Série <-");
            System.Console.Write("Digite o ID da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }

            System.Console.WriteLine();
            System.Console.Write("Gênero(digite o número): ");
            int inputGenero = int.Parse(Console.ReadLine());

            System.Console.Write("Titulo: ");
            string inputTitulo = Console.ReadLine();

            System.Console.Write("Ano: ");
            int inputAno = int.Parse(Console.ReadLine());

            System.Console.Write("Descrição: ");
            string inputDescricao = Console.ReadLine();

            Serie atualizarSerie = new Serie(id: indiceSerie, 
                                        genero: (Genero)inputGenero,
                                        titulo: inputTitulo,
                                        ano: inputAno,
                                        descricao: inputDescricao);
            repositorio.Atualiza(indiceSerie, atualizarSerie);
        }
        private static void ExcluirSerie()
        {
            System.Console.WriteLine("-> Excluir uma Série <-");
            ListarSeries();
            System.Console.WriteLine();
            System.Console.Write("> Digite o id da série que deseja excluir: ");
            int idSerie = int.Parse(Console.ReadLine());

            System.Console.WriteLine("> Deseja mesmo excluir essa série? S/N");
            var repost = Console.ReadLine();

            if (repost.ToUpper() == "S")
            {
                repositorio.Exclui(idSerie);
            }
            else
            {
                return;
            }
        }

        private static void VisualizarSerie()
        {
            System.Console.WriteLine("-> Visualizar Série <-");
            ListarSeries();
            System.Console.WriteLine();
            System.Console.Write("> Digite o ID da série que deseja visualizar: ");
            int idSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(idSerie);
            System.Console.WriteLine(serie);
            System.Console.WriteLine();
        }
        private static string ObterOpcaoUsuario() 
        {
            System.Console.WriteLine();
            System.Console.WriteLine(">>> DIO SÉRIES A SEU DISPOR <<<");
            System.Console.WriteLine("-- Informe a opção desejada: ---");
            System.Console.WriteLine();
            System.Console.WriteLine("1- Listar séries");
            System.Console.WriteLine("2- Inserir Nova Série");
            System.Console.WriteLine("3- Atualizar Série");
            System.Console.WriteLine("4- Excluir Série");
            System.Console.WriteLine("5- Visualizar Série");
            System.Console.WriteLine("C- Limpar Tela");
            System.Console.WriteLine("X- Sair");
            System.Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            System.Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
