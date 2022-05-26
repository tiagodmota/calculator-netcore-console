using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            short chosenOption;
            do
            {
                chosenOption = ChooseOperationMenu();
                switch (chosenOption)
                {
                    case (short)EMathOperations.Sum:
                        {
                            Calculator(EMathOperations.Sum).OperationResultToString();
                            PressAnyKeyToContinue();
                            break;
                        }
                    case (short)EMathOperations.Subtraction:
                        {
                            Calculator(EMathOperations.Subtraction).OperationResultToString();
                            PressAnyKeyToContinue();
                            break;
                        }
                    case (short)EMathOperations.Multiplication:
                        {
                            Calculator(EMathOperations.Multiplication).OperationResultToString();
                            PressAnyKeyToContinue();
                            break;
                        }
                    case (short)EMathOperations.Division:
                        {
                            Calculator(EMathOperations.Division).OperationResultToString();
                            PressAnyKeyToContinue();
                            break;
                        }
                    case (short)EExitStatus.EXIT_SUCCESS:
                        {
                            Console.WriteLine("\nPROGRAMA ENCERRADO.");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("\nOPERAÇÃO INVÁLIDA! TENTE NOVAMENTE:");
                            PressAnyKeyToContinue();
                            break;
                        }
                }
            } while (chosenOption != (short)EExitStatus.EXIT_SUCCESS);
            Console.WriteLine("FIM DA LINHA.");
        }

        static short ChooseOperationMenu()
        {
            Console.WriteLine("¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨");
            Console.WriteLine("CALCULADORA PRIMITIVA");
            Console.WriteLine("[1] - Somar");
            Console.WriteLine("[2] - Subtrair");
            Console.WriteLine("[3] - Multiplicar");
            Console.WriteLine("[4] - Dividir");
            Console.WriteLine("[0] - Sair");
            Console.Write("\n·Digite a opção e pressione Enter » ");
            return short.Parse(Console.ReadLine());
        }

        static OperationData ReadOperands(EMathOperations operationType)
        {
            double valueOne, valueTwo;
            Console.WriteLine();
            Console.Write("Insira o primeiro valor: ");
            valueOne = double.Parse(Console.ReadLine());
            Console.Write("Insira o segundo valor: ");
            valueTwo = double.Parse(Console.ReadLine());
            OperationData operationData = new OperationData(valueOne, valueTwo, operationType);
            return operationData;
        }

        static void PressAnyKeyToContinue()
        {
            Console.Write("Press Enter to Continue...");
            Console.ReadKey();
            Console.Clear();
        }

        static OperationData Calculator(EMathOperations operation)
        {
            OperationData operationData = ReadOperands(operation);
            switch (operation)
            {
                case EMathOperations.Sum:
                    operationData.Sum();
                    break;
                case EMathOperations.Subtraction:
                    operationData.Subtract();
                    break;
                case EMathOperations.Multiplication:
                    operationData.Multiply();
                    break;
                case EMathOperations.Division:
                    operationData.Divide();
                    break;
                default:
                    System.Environment.Exit((int)EExitStatus.EXIT_FAILURE);
                    break;
            }
            return operationData;
        }

    }

    enum EMathOperations : short
    {
        Sum = 1,
        Subtraction = 2,
        Multiplication = 3,
        Division = 4
    }

    enum EExitStatus : sbyte
    {
        EXIT_FAILURE = -1,
        EXIT_SUCCESS = 0
    }

    struct OperationData
    {
        public EMathOperations OperationType;
        public double OperandOne;
        public double OperandTwo;
        public double Result;

        public OperationData(
            double operandOne,
            double operandTwo,
            EMathOperations operationType
        )
        {
            OperationType = operationType;
            OperandOne = operandOne;
            OperandTwo = operandTwo;
            Result = 0;
        }

        public void Sum()
        {
            Result = OperandOne + OperandTwo;
        }

        public void Subtract()
        {
            Result = OperandOne - OperandTwo;
        }

        public void Multiply()
        {
            Result = OperandOne * OperandTwo;
        }

        public void Divide()
        {
            Result = OperandOne / OperandTwo;
        }

        public void OperationResultToString()
        {
            char operation = '\0';
            switch (OperationType)
            {
                case EMathOperations.Sum: operation = '+'; break;
                case EMathOperations.Subtraction: operation = '-'; break;
                case EMathOperations.Multiplication: operation = '*'; break;
                case EMathOperations.Division: operation = '/'; break;
            }
            Console.WriteLine();
            Console.WriteLine($"{OperandOne} {operation} {OperandTwo} = {Result}");
            Console.WriteLine();
        }
    }

}
