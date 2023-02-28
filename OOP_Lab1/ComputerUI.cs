using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab1
{
    class ComputerUI
    {
        /// <summary>
        /// Список компьютеров
        /// </summary>
        private List<Computer> computers = new List<Computer>();

        public ComputerUI() //запуск визуальной оболочки
        {
            Console.WriteLine("ООП_Лабораторная №1. Бригада 15: М.Анохин, М.Медведев \n");

            Console.WriteLine("У вас пока что не создан ни один экземляр класса Computer");
            Console.Write("Создать объект класса Computer? (+ и -): ");

            String var = Console.ReadLine();
            if (var == "+") ComputerCreate();
            else if (var == "-") Console.WriteLine("Экземпляр класса Computer создан не будет");
            else { Console.WriteLine("Неизвестная команда"); return; }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nТеперь у вас есть несколько вариантов использования данной оболочки: ");
            Console.ResetColor();

            bool exit = true;
            while (exit) //сессия оболочки
            {
                Console.Write(
                    "\n(1) - Вывести список всех компьютеров в базе по ID \n" +
                    "(2) - Добавить компьютер в базу \n" +
                    "(3) - Выбрать компьютер по ID и произвести с ним определенные действия \n" +
                    "(4) - Удалить компьютер из базы\n" +
                    "(5) - Выйти из оболочки \n" +
                    "Выберите вариант: ");


                String userVariant = Console.ReadLine();

                switch (userVariant)
                {
                    case "1": //Вывести список компьютеров
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("Список компьютеров по ID: | ");

                        foreach (Computer computer in computers)
                        {
                            Console.Write(computer.ComputerID + " | "); //геттер
                        }
                        Console.WriteLine();
                        Console.ResetColor();
                        break;

                    case "2": //добавить компьютер
                        ComputerCreate();
                        break;

                    case "3": //действия с компьютером
                        Console.Write("Введи ID: ");
                        String userID = Console.ReadLine();
                        
                        bool isFindID = false;
                        foreach (Computer computer in computers)
                        {
                            if (computer.ComputerID == userID)
                            {
                               
                                //удалить экземляр по id
                                //выйти из оболочки
                                isFindID = true;
                                Console.WriteLine($"Компьютер с данным ID:{userID} найден!");
                                while (true)
                                {
                                    Console.WriteLine($"\nСписок возможных действий с компьютером ID:{userID} ");
                                    Console.Write(
                                           "(1) - Вывести доступную информацию о компьютере (ToString) \n" +
                                           "(2) - Обращение к конкретному полю\n" +
                                           "(3) - Преобразовать ID в 16сс \n" +
                                           "(4) - Прервать редактирование компьютера\n" +
                                           "Выберите вариант: ");
                                    String editVariant = Console.ReadLine();

                                    switch (editVariant)
                                    {   
                                        case "1": //Вывод всех полей
                                            Console.WriteLine(computer.ToString());
                                            break;

                                        case "2": //Работа с конкретным полем
                                            Console.WriteLine($"\nСписок полей компьютера ID:{computer.ComputerID} "); ;
                                            Console.Write("(1) - Тип процессора\n" +
                                           "(2) - Частота процессора\n" +
                                           "(3) - Объём ОЗУ\n" +
                                           "(4) - Тип видеокарты\n" +
                                           "(5) - Объём видеопамяти\n" +
                                           "(6) - Мощность блока питания\n" +
                                           "(7) - Цена компьтера\n" +
                                           "Введите нужное поле: ");
                                            String computerField = Console.ReadLine();
                                            Console.WriteLine("\nКакое действие нужно сделать с этим полем?");
                                            Console.Write("(1) - Показать информацию о поле\n" +
                                           "(2) - Редактировать поле\n" +
                                           "Введите действие: ");
                                            String fieldAction = Console.ReadLine();
                                            if(fieldAction == "1")
                                                getComputerField(computerField, computer);
                                            else if(fieldAction == "2")
                                                editComputerField(computerField, computer);
                                            else
                                                Console.WriteLine("Неизвестное действие!");
                                            break;

                                        case "3": //Преобразование поля в 16сс
                                            Console.Write($"ID:{computer.ComputerID} преобразовано в ");
                                            computer.idConvertor();
                                            Console.WriteLine(computer.ComputerID);
                                            break;

                                        case "4": //Прервать редактирование компьютера
                                            return;

                                        default:
                                            Console.WriteLine("Неизвестная команда!");
                                            return;
                                    }
                                }

                            }
                        }

                        if (!isFindID)
                        {
                            Console.WriteLine("Компьютера по данному ID нет!");
                        }

                        break;

                    case "4": //удалить компьютер 
                        Console.Write("Введи ID компьютера, который нужно удалить: ");
                        String deleteID = Console.ReadLine();

                        bool isFindDeleteID = false;

                        foreach (Computer computer in computers)
                        {
                            if (computer.ComputerID == deleteID)
                            {
                                isFindDeleteID = true;
                                computers.Remove(computer);
                                Console.WriteLine($"Компьютер с ID:{computer.ComputerID} успешно удалён из базы");
                                break;
                            }
                        }
                        if (!isFindDeleteID)
                        {
                            Console.WriteLine("Невозможно удалить компьютер, которого нет в базе!");
                        }
                        break;

                    case "5": //Выход из оболочки
                        Console.WriteLine("Выход из оболочки...");
                        exit = false;
                        return;
                    default:
                        Console.WriteLine("Неизвестная команда!");
                        return;
                }
            }
        }

        private void ComputerCreate()
        {
            Computer computer = null;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nЕсть 4 варианта добавления компьютера: \n");
            Console.ResetColor();

            Console.Write("(1) - Пустой компьютер (без параметров) \n" +
                "(2) - Пустой компьютер с предварительной ценой (цена компьютера) \n" +
                "(3) - Компьютер с процессором (тип процессора, тактовая частота процессора) \n" +
                "(4) - Полностью укомплектованный компьютер \n" +
                "(5) - Отменить добавление компьютера\n" +
                "Выберите вариант: ");

            String userVariant = Console.ReadLine();

            switch (userVariant)
            {
                case "1": //пустой компьютер
                    computer = new Computer();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Добавлен пустой компьютер ID:{computer.ComputerID} ");
                    Console.ResetColor();
                    break;

                case "2": //пустой с ценой
                    Console.Write("Необходимо указать цену ($): ");
                    int computerCost = Convert.ToInt32(Console.ReadLine());
                    computer = new Computer(computerCost);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Добавлен компьютер ID:{computer.ComputerID} с ценой: {computerCost}$");
                    Console.ResetColor();
                    break;

                case "3": //с процессором
                    Console.Write("Необходимо указать тип процессора: ");
                    String processorType = Console.ReadLine();
                    Console.Write("Необходимо указать частоту процессора (MHz): ");
                    double processorFrequency = Convert.ToDouble(Console.ReadLine());
                    computer = new Computer(processorType, processorFrequency);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Добавлен компьютер ID:{computer.ComputerID} с процессором {processorType} на частоте {processorFrequency} MHz");
                    Console.ResetColor();
                    break;

                case "4": //полный
                    Console.Write("Необходимо указать тип процессора: ");
                    String processorType2 = Console.ReadLine();
                    Console.Write("Необходимо указать частоту процессора (MHz): ");
                    double processorFrequency2 = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Необходимо указать цену ($): ");
                    int computerCost2 = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Необходимо указать объём ОЗУ (MB): ");
                    int memoryCapacity = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Необходимо указать тип видеокарты: ");
                    String videoCard = Console.ReadLine();
                    Console.Write("Необходимо указать объём видеопамяти (MB): ");
                    int videoCapacity = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Необходимо указать мощность блока питания (W): ");
                    int powerUnit = Convert.ToInt32(Console.ReadLine());
                    computer = new Computer(processorType2, processorFrequency2, memoryCapacity, computerCost2,
                        videoCard, videoCapacity, powerUnit);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Добавлен полный компьютер ID:{computer.ComputerID} ");
                    Console.ResetColor();
                    break;
                case "5":
                    return;

                default:
                    Console.WriteLine("Неизвестная команда!");
                    return;
            }
            computers.Add(computer);
        }

        private void getComputerField(String computerField, Computer computer)
        {
            switch (computerField)
            {
                case "1": //тип процессора
                    Console.WriteLine($"Тип процессора - {computer.ProcessorType}");
                    break;

                case "2": //частота процессора
                    Console.WriteLine($"Частота процессора - {computer.ProcessorFrequency} MHz");
                    break;

                case "3": //объём озу
                    Console.WriteLine($"Объём ОЗУ - {computer.MemoryCapacity} MB");
                    break;

                case "4": // тип видеокарты
                    Console.WriteLine($"Тип видеокарты - {computer.VideoCard} ");
                    break;

                case "5": // объём видеопамяти
                    Console.WriteLine($"Объём видеопамяти - {computer.VideoCapacity} MB");
                    break;

                case "6": // мощность БП
                    Console.WriteLine($"Мощность БП - {computer.PowerUnit} W");
                    break;

                case "7": // цена
                    Console.WriteLine($"Цена - {computer.ComputerCost} $");
                    break;

                default:
                    Console.WriteLine("Неизвестное поле!");
                    return;
            }

        }

        private void editComputerField(String computerField, Computer computer)
        {
            switch (computerField)
            {
                case "1": //тип процессора
                    Console.Write($"Введите новый тип процессора: ");
                    String processorType = Console.ReadLine();
                    computer.ProcessorType = processorType;
                    Console.WriteLine("Тип процессора изменен!");
                    break;

                case "2": //частота процессора
                    Console.Write($"Введите новую частоту процессора: ");
                    double processorFrequency = Convert.ToDouble(Console.ReadLine());
                    computer.ProcessorFrequency = processorFrequency;
                    Console.WriteLine("Частота процессора изменена!");
                    break;

                case "3":
                    Console.Write($"Введите новый объём ОЗУ: ");
                    int memoryCapacity = Convert.ToInt32(Console.ReadLine());
                    computer.MemoryCapacity = memoryCapacity;
                    Console.WriteLine("Объём ОЗУ изменен!");
                    break;

                case "4": // тип видеокарты
                    Console.Write($"Введите новый тип видеокарты: ");
                    String videoCard = Console.ReadLine();
                    computer.VideoCard = videoCard;
                    Console.WriteLine("Тип видеокарты изменен!");
                    break;

                case "5": // объём видеопамяти
                    Console.Write($"Введите новый объём видеопамяти: ");
                    int videoCapacity = Convert.ToInt32(Console.ReadLine());
                    computer.VideoCapacity = videoCapacity;
                    Console.WriteLine("Объём видеопамяти изменен!");
                    break;

                case "6": // мощность БП
                    Console.Write($"Введите новую мощность БП: ");
                    int powerUnit = Convert.ToInt32(Console.ReadLine());
                    computer.PowerUnit = powerUnit;
                    Console.WriteLine("Мощность БП изменена!");
                    break;

                case "7": // цена
                    Console.Write($"Введите новую цену компьютера: ");
                    int computerCost = Convert.ToInt32(Console.ReadLine());
                    computer.ComputerCost = computerCost;
                    Console.WriteLine("Цена компьютера изменена!");
                    break;

                default:
                    Console.WriteLine("Неизвестное поле!");
                    return;
            }
        }
    }
}
