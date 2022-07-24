using DIO.Series.Models;

class Program 
{
    static Repository repository = new Repository();
    static void Main()
    {
        string userOption = GetUserOption();

        while(userOption.ToUpper() != "X")
        {
            switch(userOption)
            {
                case "1":
                    listSeries();
                    break;
                case "2":
                    insertSeries();
                    break;
                case "3":
                    updateSeries();
                    break;
                case "4":
                    deleteSeries();
                    break;
                case "5":
                    showSeries();
                    break;
                case "C":
                    Console.Clear();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            userOption = GetUserOption();
        }

        Console.WriteLine("Obrigado por usar nossos serviços");
        Console.ReadLine();
    }

    private static void listSeries()
    {
        Console.WriteLine("Listar Séries");
        var list = repository.ToList();

        if(list.Count == 0)
        {
            Console.WriteLine("Lista de séries vazia");
            return;
        }

        foreach (var series in list)
        {
            var deleted = series.returnDeleted();
            Console.WriteLine($"ID: {series.returnId()} - {series.returnTitle()} {(deleted ? "- Excluído" : "")}"); 
        }
    }

    private static void insertSeries()
    {
        Console.WriteLine("Inserir Série");

        foreach (int i in Enum.GetValues(typeof(Genre)))
        {
            Console.WriteLine($"{i} - {Enum.GetName(typeof(Genre), i)}");
        }

        Console.Write("Digite o genêro entre as opções acima: ");
        int _genre = int.Parse(Console.ReadLine());

        Console.Write("Digite o título da série: ");
        string _title = (Console.ReadLine());

        Console.Write("Digite o ano de ínicio da série: ");
        int _year = int.Parse(Console.ReadLine());

        Console.Write("Digite a descrição da série: ");
        string _description = (Console.ReadLine());

        Serie newSerie = new Serie(Id: repository.nextId(), Genre: (Genre)_genre, Title: _title, Year: _year, Description: _description);
        repository.Insert(newSerie);                        
    }

    private static void updateSeries()
    {
        Console.WriteLine("Atualizar Série");
        Console.Write("Informe o Id da série: ");
        int idSerie = int.Parse(Console.ReadLine());

        foreach (int i in Enum.GetValues(typeof(Genre)))
        {
            Console.WriteLine($"{i} - {Enum.GetName(typeof(Genre), i)}");
        }

        Console.Write("Digite o genêro entre as opções acima: ");
        int _genre = int.Parse(Console.ReadLine());

        Console.Write("Digite o título da série: ");
        string _title = (Console.ReadLine());

        Console.Write("Digite o ano de ínicio da série: ");
        int _year = int.Parse(Console.ReadLine());

        Console.Write("Digite a descrição da série: ");
        string _description = (Console.ReadLine());

        Serie newSerie = new Serie(Id: idSerie, Genre: (Genre)_genre, Title: _title, Year: _year, Description: _description);
        repository.Update(idSerie, newSerie);    
    }

    private static void deleteSeries()
    {
        Console.Write("Informe o Id da série: ");
        int idSerie = int.Parse(Console.ReadLine());
        repository.Delete(idSerie);
    }

    private static void showSeries()
    {
        Console.Write("Informe o Id da série: ");
        int idSerie = int.Parse(Console.ReadLine());
        var series = repository.returnForId(idSerie);
        Console.WriteLine(series);
    }

    private static string GetUserOption()
    {
        Console.WriteLine("*****DIO SÉRIES*****");
        Console.WriteLine("--------------------");
        Console.WriteLine("Informe a opção desejada:");
        Console.WriteLine("1 - Listar séries");
        Console.WriteLine("2 - Inserir nova série");
        Console.WriteLine("3 - Atualizar série");
        Console.WriteLine("4 - Excluir uma série");
        Console.WriteLine("5 - Visualzar série");
        Console.WriteLine("C = Limpar tela");
        Console.WriteLine("X - Sair");
        Console.WriteLine();
        string userOption = Console.ReadLine().ToUpper();
        Console.WriteLine();
        return userOption;
    }
}


