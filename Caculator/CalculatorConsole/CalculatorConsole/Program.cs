using CalculatorDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new Calculator();
            var operationCode = 0;
            var values = new List<string>();
            var operation = 0;
            var result = 0;

            while (operationCode != 3)
            {
                operationCode = GetOperationCode();

                if (operationCode == 1)
                {
                    values = GetValues();
                    operation = GetOperation();
                    result = calculator.Calculate(int.Parse(values[0]), int.Parse(values[1]), (EnumOperationToCalc)operation);
                    calculator.Salve(int.Parse(values[0]), int.Parse(values[1]), (EnumOperationToCalc)operation, result);
                    Console.WriteLine("Resultado: " + result);
                    Console.ReadKey();
                    Console.Clear();
                }

                if(operationCode == 2)
                {
                    Console.Clear();
                    foreach (var log in calculator.Log)
                    {
                        Console.WriteLine("------------------------------------------------");
                        Console.WriteLine("Id      : " + log.Id);
                        Console.WriteLine("Valor 1 : " + log.Value1);
                        Console.WriteLine("Operação: " + log.VisibleOperation);
                        Console.WriteLine("Valor 2 : " + log.Value2);
                        Console.WriteLine("Result  : " + log.Result);
                        Console.WriteLine("------------------------------------------------");
                    }
                    Console.ReadKey();
                    Console.Clear();
                }

            }
        }

        private static int GetOperation()
        {
            int operation;
            GetOperationToCalc();

            while (!int.TryParse(Console.ReadLine(), out operation) || operation < 1 || operation > 4)
            {
                Console.WriteLine("Operação Invalida!");
                Console.WriteLine("Por favor digitar novamente!");

                GetOperationToCalc();
            }

            return operation;
        }

        private static void GetOperationToCalc()
        {
            Console.WriteLine("Digite o código da operação desejada:");
            Console.WriteLine("1 - Soma");
            Console.WriteLine("2 - Subtração");
            Console.WriteLine("3 - Multiplicação");
            Console.WriteLine("4 - Divisão");
        }

        private static List<string> GetValues()
        {
            string stringValues = GetStringValues();
            while (GetValidationToValues(stringValues))
            {
                Console.WriteLine("Formato invalido dos valores");
                stringValues = GetStringValues();
            }

            var values = stringValues.Split(',').ToList();

            return values;

        }

        private static bool GetValidationToValues(string stringValues)
        {
            var temp = 0;
            return !stringValues.Contains(',')
                || !int.TryParse(stringValues.Split(',')[0], out temp)
                || !int.TryParse(stringValues.Split(',')[1], out temp);
        }

        private static string GetStringValues()
        {
            Console.WriteLine("Digite os dois valores que serão calculados separados por virugula:");
            Console.WriteLine("Examplo: 2,3");

            var stringValues = Console.ReadLine();
            return stringValues;
        }

        private static int GetOperationCode()
        {
            var operationCode = 0;
            ShowOperations();

            while (!int.TryParse(Console.ReadLine(), out operationCode) || operationCode < 1 || operationCode > 3)
            {
                if (operationCode < 1 && operationCode != 0)
                    Console.WriteLine("O valor digitado não está em um formato correto!");
                else
                    Console.WriteLine("Operação digitada é inválida!");

                Console.WriteLine("Por favor, digite a operação novamente!");
                ShowOperations();
            }

            return operationCode;
        }

        private static void ShowOperations()
        {
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1 - Calcular");
            Console.WriteLine("2 - Exibir Histórico");
            Console.WriteLine("3 - Sair");
        }
    }
}
