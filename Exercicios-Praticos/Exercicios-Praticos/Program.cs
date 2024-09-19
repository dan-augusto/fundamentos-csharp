using System.Resources;
using System.Text;
using System.Linq;

public class Program
{
    public static void Main()
    {
        string[] choices = ["1", "2", "3", "4", "5", "6", "7"];
        string userChoice = "";

        while (userChoice != "7")
        {
            Console.WriteLine("ESCOLHA ALGUM DOS EXERCÍCIOS ABAIXO");
            Console.WriteLine("1 - Mensagem de boas-vindas");
            Console.WriteLine("2 - Concatenação de strings");
            Console.WriteLine("3 - Operações matemáticas");
            Console.WriteLine("4 - Contagem de caracteres");
            Console.WriteLine("5 - Verificar placa de veículo");
            Console.WriteLine("6 - Exibição de data e hora em diferentes formatos");
            Console.WriteLine("7 - Finalizar");
            Console.Write("> Sua opção: ");
            userChoice = Console.ReadLine();
            Console.WriteLine();

            while(!choices.Contains(userChoice))
            {
                Console.Write("[!] Opção inválida. Digite novamente: ");
                userChoice = Console.ReadLine();
                Console.WriteLine();
            }

           decision(userChoice);
        }
    }

    private static void decision(string userChoise)
    {
        switch (userChoise)
        {
            case "1":
                {
                    exercicio1();
                    break;
                }
            case "2":
                {
                    exercicio2();
                    break;
                }
        }
    }

    private static void exercicio1()
    {
        string name = readName();

        StringBuilder sb = new StringBuilder();
        sb.Append("=D Olá, ").Append(name).Append("! Seja muito bem-vindo!");

        Console.WriteLine(sb.ToString());
        Console.WriteLine();
    }

    private static void exercicio2()
    {
        string name = readName();
        string surname = readSurname();

        StringBuilder sb = new StringBuilder();
        sb.Append("=D Olá, ").Append(name).Append(" ").Append(surname).Append("!");

        Console.WriteLine(sb.ToString());
        Console.WriteLine();
    }

    private static string readName()
    {
        Console.Write("> Digite o seu nome: ");
        string name = Console.ReadLine().Trim();
        Console.WriteLine();
        bool isNameValid = checkName(name);

        while (!isNameValid)
        {
            name = readInvalidName(name);
            isNameValid = checkName(name);
        }

        string nameResult = string.Concat(name.Where(c => !char.IsWhiteSpace(c)));

        return nameResult;
    }

    private static string readInvalidName(string name)
    {
        Console.Write("[!] Digite um nome válido: ");
        name = Console.ReadLine().Trim();
        Console.WriteLine();
        return name;
    }

    private static string readSurname()
    {
        Console.Write("> Digite o seu sobrenome: ");
        string surname = Console.ReadLine().Trim();
        Console.WriteLine();
        bool isNameValid = checkName(surname);

        while (!isNameValid)
        {
            surname = readInvalidSurname(surname);
            isNameValid = checkName(surname);
        }

        string surnameResult = string.Concat(surname.Where(c => !char.IsWhiteSpace(c)));

        return surnameResult;
    }

    private static string readInvalidSurname(string surname)
    {
        Console.Write("[!] Digite um sobrenome válido: ");
        surname = Console.ReadLine().Trim();
        Console.WriteLine();
        return surname;
    }

    private static bool checkName(string name) 
    {
        if (name != "" || name != null)
        {
            return true;
        }
        else return false;
    }
}