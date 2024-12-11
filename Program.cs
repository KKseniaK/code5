namespace Lab5to6
{
    using System;

    class Program
    {
        static void Main()
        {
            string[] mainMenu = {
            "1. Работа с двумерными массивами",
            "2. Работа с рваными массивами",
            "3. Работа со строками",
            "4. Выход"
        };

            bool exit = false;
            int[,] twoDimensionalArray = null;
            int[][] jaggedArray = null;
            string currentString = null;

            while (!exit)
            {
                int option = ShowSelectionMenu(mainMenu, "Главное меню");
                switch (option)
                {
                    case 1: // Работа с двумерными массивами
                        {
                            string[] twoDimensionalMenu = {
                            "1. Создать массив",
                            "2. Напечатать массив",
                            "3. Удалить столбцы от К1 до К2",
                            "4. Назад"
                        };

                            bool back = false;
                            while (!back)
                            {
                                int subOption = ShowSelectionMenu(twoDimensionalMenu, "--> Двумерный массив");
                                switch (subOption)
                                {
                                    case 1: // cоздать массив
                                        twoDimensionalArray = CreateTwoDimensionalArray();
                                        break;
                                    case 2: // напечатать массив
                                        PrintTwoDimensionalArray(twoDimensionalArray);
                                        Console.ReadKey(); 
                                        break;
                                    case 3: // удалить столбцы
                                        RemoveColumns(ref twoDimensionalArray);
                                        Console.ReadKey();
                                        break;
                                    case 4: // назад
                                        back = true;
                                        break;
                                }
                            }
                        }
                        break;

                    case 2: // Работа с рваными массивами
                        {
                            string[] jaggedMenu = {
                            "1. Создать массив",
                            "2. Напечатать массив",
                            "3. Добавить строку в начало массива",
                            "4. Назад"
                        };

                            bool back = false;
                            while (!back)
                            {
                                int subOption = ShowSelectionMenu(jaggedMenu, "--> Рваный массив");
                                switch (subOption)
                                {
                                    case 1: // Создать массив
                                        jaggedArray = CreateJaggedArray();
                                        break;
                                    case 2: // Напечатать массив
                                        PrintJaggedArray(jaggedArray);
                                        Console.ReadKey(); 
                                        break;
                                    case 3: // Добавить строку
                                        AddRowAtStart(ref jaggedArray);
                                        Console.ReadKey();
                                        break;
                                    case 4: // Назад
                                        back = true;
                                        break;
                                }
                            }
                        }
                        break;

                    case 3: // Работа со строками
                        {
                            string[] stringMenu = {
                                 "1. Ввести строку",
                                 "2. Печать строки",
                                 "3. Перевернуть и отсортировать слова по длине",
                                 "4. Выбрать строку для тестирования",
                                 "5. Назад" };

                            bool back = false;
                            while (!back)
                            {
                                int subOption = ShowSelectionMenu(stringMenu, "--> Строки");
                                switch (subOption)
                                {
                                    case 1: // Ввести строку
                                        Console.Write("Введите строку: ");
                                        currentString = Console.ReadLine();
                                        break;
                                    case 2: // Печать строки
                                        if (string.IsNullOrEmpty(currentString))
                                        {
                                            Console.WriteLine("Ошибка: строка не введена. Пожалуйста, сначала введите строку.");
                                        }
                                        else
                                        {
                                            Console.WriteLine($"Текущая строка: {currentString}");
                                        }
                                        Console.ReadKey(); // Пауза после вывода строки
                                        break;
                                    case 3: // Перевернуть и отсортировать слова по длине
                                        if (string.IsNullOrEmpty(currentString))
                                        {
                                            Console.WriteLine("Ошибка: строка не введена. Пожалуйста, сначала введите строку.");
                                        }
                                        else
                                        {
                                            currentString = ReverseAndSortWords(currentString);
                                            Console.WriteLine($"Результат: {currentString}");
                                        }
                                        Console.ReadKey();
                                        break;
                                    case 4: // Выбрать строку для тестирования
                                        currentString = ChooseTestString(); // Передаем выбранную строку
                                        Console.WriteLine($"Вы выбрали строку: {currentString}");
                                        break;
                                    case 5: // Назад
                                        back = true;
                                        break;
                                }
                            }
                        }
                        break;

                    case 4: // Выход
                        Console.WriteLine("Выход...");
                        Console.ReadKey();
                        exit = true;
                        break;
                }
            }
        }

        /// <summary>
        /// функция для вывода меню на консоль и обработки введенной позиции меню
        /// </summary>
        /// <param name="menuOptions"></param>
        /// <returns>одна введенная позиция меню</returns>
        static int ShowSelectionMenu(string[] menuOptions, string sectionName)
        {
            Console.Clear();
            Console.WriteLine(sectionName); // название текущего раздела
            foreach (string option in menuOptions)
            {
                Console.WriteLine(option);
            }

            int choice;
            do
            {
                choice = ReadInt("Введите номер пункта: ");
            } while (!CheckDiapason(choice, 1, menuOptions.Length));//макс диапазона вычисляется от длины меню

            return choice;
        }

        /// <summary>
        /// функция для ввода числа типа int
        /// </summary>
        /// <param name="msg"></param>
        /// <returns>целое число типа int</returns>
        static int ReadInt(string msg)
        {
            int result;
            Console.Write(msg);
            while (!int.TryParse(Console.ReadLine(), out result))
            {
                Console.Write("Ошибка ввода. Попробуйте снова: ");
            }
            return result;
        }
        /// <summary>
        /// функция для ввода положительного числа типа int
        /// </summary>
        /// <param name="msg">сообщение</param>
        /// <returns>положительное целое число nbgf int</returns>
        static int ReadIntPositive(string msg)
        {
            int result;
            bool isValid;

            do
            {
                Console.Write(msg);
                string input = Console.ReadLine();
                isValid = int.TryParse(input, out result) && result > 0;

                if (!isValid)
                {
                    Console.WriteLine("Ошибка. Введите целое положительное число.");
                }
            } while (!isValid);

            return result;
        }


        /// <summary>
        /// функция для проверки, находится ли вводимное число в диапазоне
        /// </summary>
        /// <param name="number">вводимое число</param>
        /// <param name="start">начало диапазона(включительно)</param>
        /// <param name="end">конец диапазона(включистельно)</param>
        /// <returns>true/false</returns>
        static bool CheckDiapason(int number, int start, int end)
        {
            if (start <= number && number <= end)
                return true;
            else
            {
                Console.WriteLine($"Ошибка! Введённое число должно быть в диапазоне от {start} до {end}.");
                return false;
            }
        }

        //перегруженная функция IsEmpty
        /// <summary>
        /// функция проверяющая рваный массив на пустоту
        /// </summary>
        /// <param name="mas">массив</param>
        /// <returns>true/false</returns>
        static bool IsEmpty(int[][] mas) =>
            mas == null || mas.Length == 0;

        /// <summary>
        /// функция, проверяющая двумерный массив на пустоту
        /// </summary>
        /// <param name="mas"></param>
        /// <returns></returns>
        static bool IsEmpty(int[,] mas) =>
            mas == null || mas.GetLength(0) == 0 || mas.GetLength(1) == 0;

        /// <summary>
        /// создает двумерный массив, внутри предлагает два вида создания
        /// </summary>
        /// <returns>массив</returns>
        static int[,] CreateTwoDimensionalArray()
        {
            string[] creationMenu = {
            "1. Создать массив вручную",
            "2. Создать массив с использованием датчика случайных чисел",
            "3. Назад"};

            int[,] array = null;
            bool back = false;

            while (!back)
            {
                int choice = ShowSelectionMenu(creationMenu, "Выберите способ создания двумерного массива:");
                switch (choice)
                {
                    case 1: // Создать массив вручную
                        int rows = ReadIntPositive("\nВведите количество строк: ");
                        int cols = ReadIntPositive("Введите количество столбцов: ");
                        array = new int[rows, cols];

                        Console.WriteLine("\nЗаполнение массива вручную: ");
                        for (int i = 0; i < rows; i++)
                        {
                            for (int j = 0; j < cols; j++)
                            {
                                array[i, j] = ReadInt($"Элемент {i+1} строки, {j+1} столбца: ");
                            }
                        }
                        Console.WriteLine("\nМассив создан.");
                        Console.ReadKey();
                        back = true;//автоматический возврат в меню работы с массивом после создания
                        break;

                    case 2: // Создать массив случайным образом
                        rows = ReadIntPositive("\nВведите количество строк: ");
                        cols = ReadIntPositive("Введите количество столбцов: ");
                        int minValue = ReadInt("\nВведите минимальное значение: ");
                        int maxValue = ReadMaxValue("Введите максимальное значение: ", minValue, "Максимальное значение не может быть меньше минимального!");


                        Random random = new Random();
                        array = new int[rows, cols];

                        for (int i = 0; i < rows; i++)
                        {
                            for (int j = 0; j < cols; j++)
                            {
                                array[i, j] = random.Next(minValue, maxValue + 1);
                            }
                        }
                        Console.WriteLine("\nМассив создан случайным образом.");
                        Console.ReadKey();
                        back = true;
                        break;

                    case 3: // Назад
                        back = true;
                        break;
                }
            }

            return array;
        }

        /// <summary>
        /// создает рваный массив, внутри предлагает два вида создания
        /// </summary>
        /// <returns>массив</returns>
        static int[][] CreateJaggedArray()
        {
            string[] creationMenu = {
            "1. Создать массив вручную",
            "2. Создать массив с использованием датчика случайных чисел",
            "3. Назад"
        };

            int[][] array = null;
            bool back = false;

            while (!back)
            {
                int choice = ShowSelectionMenu(creationMenu, "Выберите способ создания рваного массива:");
                switch (choice)
                {
                    case 1: // Создать массив вручную
                        int rows = ReadIntPositive("\nВведите количество строк: ");
                        array = new int[rows][];

                        for (int i = 0; i < rows; i++)
                        {
                            int cols = ReadIntPositive($"\nВведите количество элементов в строке {i+1}: ");
                            array[i] = new int[cols];
                            Console.WriteLine();
                            for (int j = 0; j < cols; j++)
                            {
                                array[i][j] = ReadInt($"Строка {i+1}, элемент номер {j+1}: ");
                            }
                        }
                        Console.WriteLine("\nМассив создан.");
                        Console.ReadKey();
                        break;

                    case 2: // Создать массив случайным образом
                        rows = ReadIntPositive("\nВведите количество строк: ");
                        array = new int[rows][];

                        Random random = new Random();
                        for (int i = 0; i < rows; i++)
                        {
                            int cols = ReadIntPositive($"\nВведите количество элементов в строке {i + 1}: ");
                            int minValue = ReadInt("Введите минимальное значение: ");
                            int maxValue = ReadMaxValue("Введите максимальное значение: ", minValue, "Максимальное значение не может быть меньше минимального!");

                            array[i] = new int[cols];
                            for (int j = 0; j < cols; j++)
                            {
                                array[i][j] = random.Next(minValue, maxValue + 1);
                            }
                        }
                        Console.WriteLine("\nМассив создан случайным образом.");
                        Console.ReadKey();
                        break;

                    case 3: // Назад
                        back = true;
                        break;
                }
            }

            return array;
        }

        /// <summary>
        /// функция для проверки и получения максимального значения, зависит от минимального значения
        /// </summary>
        /// <param name="msg">сообщение</param>
        /// <param name="minValue">минимальное значение</param>
        /// <returns>максимальное значение</returns> 
        static int ReadMaxValue(string msg, int minValue, string errorMessage)
        {
            int maxValue;
            do
            {
                maxValue = ReadInt(msg);
                if (maxValue < minValue)
                {
                    Console.WriteLine(errorMessage); // Выводим сообщение об ошибке
                }
            } while (maxValue < minValue);

            return maxValue;
        }

        /// <summary>
        /// вывод двумерного массива на экран
        /// </summary>
        /// <param name="array">массив</param>
        static void PrintTwoDimensionalArray(int[,] array)
        {
            if (IsEmpty(array))
            {
                Console.WriteLine("\nМассив не создан.");
                return;
            }

            Console.WriteLine("\nДвумерный массив:");
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write($"{array[i, j], -10} ");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// функция вывода на экран рваного массива
        /// </summary>
        /// <param name="array"></param>
        static void PrintJaggedArray(int[][] array)
        {
            if (IsEmpty(array))
            {
                Console.WriteLine("Массив не создан.");
                return;
            }
            Console.WriteLine("\nРваный массив:");
            for (int i = 0;  i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array[i].GetLength(0); j++)
                {
                    Console.Write($"{array[i][j], -10}");
                }
                Console.WriteLine();
            }
            
        }

        /// <summary>
        /// функция удаления столбцов с K1 по K2 в двумерном массиве
        /// </summary>
        /// <param name="array">массив</param>
        static void RemoveColumns(ref int[,] array)
        {
            if (IsEmpty(array))
            {
                Console.WriteLine("Массив не создан.");
            }
            else
            {
                int maxIndex = array.GetLength(1) - 1;
                int k1 = ReadInt($"\nВведите начальный индекс столбца (K1) (от 0 до {maxIndex}): ");

                if (!CheckDiapason(k1, 0, maxIndex))
                {
                    Console.WriteLine("Ошибка: начальный индекс столбца (K1) должен быть в пределах существующих столбцов.");
                    return;
                }

                int k2 = ReadMaxValue($"Введите конечный индекс столбца (K2) (от {k1} до {maxIndex}): ", k1, "\nКонечный индекс столбца не может быть меньше начального.");

                if (!CheckDiapason(k2, 0, maxIndex))
                {
                    Console.WriteLine("Ошибка: конечный индекс столбца (K2) должен быть в пределах существующих столбцов.");
                    return;
                }

                int colsToRemove = k2 - k1 + 1;
                int[,] newArray = new int[array.GetLength(0), array.GetLength(1) - colsToRemove];

                for (int i = 0; i < array.GetLength(0); i++)
                {
                    int newColIndex = 0;
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        if (j < k1 || j > k2)
                        {
                            newArray[i, newColIndex++] = array[i, j];
                        }
                    }
                }

                // если после удаления столбцов массив станет пустым 
                int newColumnCount = array.GetLength(1) - colsToRemove;
                if (newColumnCount <= 0)
                    Console.WriteLine("\nПосле удаления столбцов массив стал пустым.");
                else
                    Console.WriteLine("\nСтолбцы удалены.");
                array = newArray;
            }
            
        }


        /// <summary>
        /// функция добавления строки в начало рваного массива
        /// </summary>
        /// <param name="array">рваный массив</param>
        static void AddRowAtStart(ref int[][] array)
        {
            if (IsEmpty(array))
            {
                Console.WriteLine("Массив не создан.");
            }
            else
            {
                Console.WriteLine("\nДобавление строки в начало массива.");
                int cols = ReadIntPositive("\nВведите количество элементов в новой строке: ");
                int[] newRow = new int[cols];
                Console.WriteLine();
                for (int i = 0; i < cols; i++)
                {
                    newRow[i] = ReadInt($"Элемент номер {i + 1}: ");
                }

                int[][] newArray = new int[array.Length + 1][];
                newArray[0] = newRow;

                for (int i = 0; i < array.Length; i++)
                {
                    newArray[i + 1] = array[i];
                }

                array = newArray;
                Console.WriteLine("\nСтрока добавлена.");
            } 
        }

        
        /// <summary>
        /// Метод для выбора тестовой строки
        /// </summary>
        /// <returns>выбыбранную строку</returns>
        static string ChooseTestString()
        {
            string[] testStrings = new string[]
            {
            "Весь мир живет по Бруксу! Читайте Брукса!!!", 
            "Мама мыла раму", 
            "Пу пу пу. Пупупу пупу пу пупупу пуп!", 
            "", 
            };

            int selectedOption = ShowSelectionMenu(testStrings, "Выбор строки для тестирования");

            return testStrings[selectedOption - 1]; // Возвращаем выбранную строку
        }


        // Переворачиваем все слова в строке и сортируем их по длине
        static string ReverseAndSortWords(string input)
        {
            var words = input.Split(' ') // Разделяем строку на слова
                             .Select(word => new string(word.Reverse().ToArray())) // Переворачиваем каждое слово
                             .OrderByDescending(word => word.Length) // Сортируем по длине слов
                             .ToArray();

            return string.Join(" ", words); // Собираем строку обратно
        }



    }


}
