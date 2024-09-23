using System.Resources;
using System.Text;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;
using System.Globalization;

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
            case "3":
                {
                    exercicio3();
                    break;
                }
            case "4":
                {
                    exercicio4();
                    break;
                }
            case "5":
                {
                    exercicio5();
                    break;
                }
            case "6":
                {
                    exercicio6();
                    break;
                }
        }
    }

    private static void exercicio1()
    {
        Console.Write("> Digite o seu nome: ");
        string name = readText();

        StringBuilder sb = new StringBuilder();
        sb.Append(">>>  Olá, ").Append(name).Append("! Seja muito bem-vindo!");

        Console.WriteLine(sb.ToString());
        Console.WriteLine();
    }

    private static void exercicio2()
    {
        Console.Write("> Digite o seu nome: ");
        string name = readText();
        Console.Write("> Digite o seu sobrenome: ");
        string surname = readText();

        StringBuilder sb = new StringBuilder();
        sb.Append(">>>  Olá, ").Append(name).Append(" ").Append(surname).Append("!");

        Console.WriteLine(sb.ToString());
        Console.WriteLine();
    }

    private static void exercicio3()
    {
        double firstNumber = readDouble();

        double secondNumber = readDouble();

        Console.WriteLine(">>> Soma: " + (firstNumber + secondNumber));
        Console.WriteLine(">>> Subtração: " + (firstNumber - secondNumber));
        Console.WriteLine(">>> Multiplicação: " + (firstNumber * secondNumber));
        if(secondNumber == 0)
        {
            Console.WriteLine(">>> A divisão não pode ser realizada pois o segundo número é igual a zero.");
        } else
        {
            Console.WriteLine(">>> Divisão: " + (firstNumber / secondNumber).ToString("0.00"));
        }
        Console.WriteLine(">>> Média: " + (firstNumber + secondNumber) / 2);
        Console.WriteLine();
    }

    private static void exercicio4()
    {
        Console.Write("> Digite uma frase ou alguma palavra: ");
        string text = readText();

        Console.WriteLine(">>> Total de caracteres: " + text.Count());
        Console.WriteLine();
    }

    private static void exercicio5()
    {
        Console.Write("> Digite a placa do veículo: ");
        string vehiclePlate = readText();

        bool isPlateValid = checkPlate(vehiclePlate);

        if(!isPlateValid)
        {
            Console.WriteLine("[!] Placa inválida!");
            Console.WriteLine();
        }
    }

    private static void exercicio6()
    {
        CultureInfo ptBR = new CultureInfo("pt-BR");
        Console.WriteLine(">>> " + DateTime.Now.ToString("G", ptBR));
        Console.WriteLine(">>> " + DateTime.Now.ToString("d", ptBR));
        Console.WriteLine(">>> " + DateTime.Now.Hour + " horas");
        Console.WriteLine(">>> " + DateTime.Now.ToString("D", ptBR));
        Console.WriteLine();
    }

    private static string readText()
    {
        string name = Console.ReadLine().Trim();
        Console.WriteLine();
        bool isNameValid = checkText(name);

        while (!isNameValid)
        {
            name = readInvalidName(name);
            isNameValid = checkText(name);
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

    private static string readInvalidSurname(string surname)
    {
        Console.Write("[!] Digite um sobrenome válido: ");
        surname = Console.ReadLine().Trim();
        Console.WriteLine();
        return surname;
    }

    private static bool checkText(string name) 
    {
        if (name != "" || name != null)
        {
            return true;
        }
        else return false;
    }

    private static double readDouble()
    {
        Console.Write("> Digite um número: ");
        string s = Console.ReadLine();
        Console.WriteLine();

        bool isNumberValid = checkIfStringIsConvertibleToDouble(s);

        if (isNumberValid)
        {
            return Convert.ToDouble(s);
        }
        else
        {
            do
            {
                Console.Write("[!] Digite um número válido: ");
                s = Console.ReadLine();
                Console.WriteLine();
                isNumberValid = checkIfStringIsConvertibleToDouble(s);
            } while (!isNumberValid);

            return Convert.ToDouble(s);
        }
    }

    private static bool checkIfStringIsConvertibleToDouble(string s)
    {
        try
        {
            Convert.ToDouble(s);
            return true;
        } catch (Exception e)
        {
            return false;
        }
    }

    private static bool checkPlate(string vehiclePlate)
    {
        if (vehiclePlate.Count() == 7)
        {
            string plateLetters = vehiclePlate.Substring(0, 3);
            string plateNumbers = vehiclePlate.Substring(3, 4);

            bool isPlateLettersValid = Regex.IsMatch(plateLetters, @"^[a-zA-Z]+$");
            bool isPlateNumbersValid = Regex.IsMatch(plateNumbers, @"^[0-9]+$");

            if (isPlateLettersValid && isPlateNumbersValid)
            {
                Console.WriteLine(">>> Placa válida: " + plateLetters.ToUpper() + " " + plateNumbers.ToUpper());
                Console.WriteLine();
                return true;
            }
            else return false;
        }
        else return false;
    }
}