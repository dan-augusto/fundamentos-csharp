using System.Text;

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
        }
    }

    private static void exercicio1()
    {
        Console.Write("> Digite o seu nome: ");
        string name = Console.ReadLine().Trim();
        Console.WriteLine();
        bool isNameValid = checkName(name);

        while (!isNameValid) 
        {
            Console.Write("[!] Digite um nome válido: ");
            name = Console.ReadLine().Trim();
            Console.WriteLine();
            isNameValid = checkName(name);
        }

        StringBuilder sb = new StringBuilder();
        sb.Append("=D Olá, ").Append(name).Append("! Seja muito bem-vindo!");

        Console.WriteLine(sb.ToString());
        Console.WriteLine();
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