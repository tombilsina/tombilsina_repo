namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Введите первую строку (или 'exit' для выхода): ");
                string? firstString = Console.ReadLine();

                // Проверка на выход из программы
                if (firstString?.ToLower() == "exit")
                {
                    Console.WriteLine("Программа завершена.");
                    break;
                }

                Console.Write("Введите вторую строку: ");
                string? secondString = Console.ReadLine();

                // Проверка, что строки не null
                if (firstString == null || secondString == null)
                {
                    Console.WriteLine("Ошибка: строки не могут быть пустыми.");
                    continue;
                }

                // Вычисление расстояния
                int distance = DamerauLevenshteinDistance(firstString, secondString);

                // Вывод результата
                Console.WriteLine($"Расстояние Дамерау-Левенштейна между '{firstString}' и '{secondString}' = {distance}");
                Console.WriteLine(new string('-', 60));
            }

            /// <summary>
            /// Вычисление расстояния Дамерау-Левенштейна между двумя строками
            /// </summary>
            /// <param name="str1Param">Первая строка</param>
            /// <param name="str2Param">Вторая строка</param>
            /// <returns>Расстояние Дамерау-Левенштейна</returns>
            static int DamerauLevenshteinDistance(string str1Param, string str2Param)
            {
                // Проверка на null
                if (str1Param == null || str2Param == null)
                    return -1;

                int str1Len = str1Param.Length;
                int str2Len = str2Param.Length;

                // Если хотя бы одна строка пустая, возвращается длина другой строки
                if (str1Len == 0 && str2Len == 0) return 0;
                if (str1Len == 0) return str2Len;
                if (str2Len == 0) return str1Len;

                // Приведение строк к верхнему регистру для регистронезависимого сравнения
                string str1 = str1Param.ToUpper();
                string str2 = str2Param.ToUpper();

                // Объявление матрицы
                int[,] matrix = new int[str1Len + 1, str2Len + 1];

                // Инициализация нулевой строки и нулевого столбца матрицы
                for (int i = 0; i <= str1Len; i++)
                    matrix[i, 0] = i;

                for (int j = 0; j <= str2Len; j++)
                    matrix[0, j] = j;

                // Вычисление расстояния Дамерау-Левенштейна
                for (int i = 1; i <= str1Len; i++)
                {
                    for (int j = 1; j <= str2Len; j++)
                    {
                        // Эквивалентность символов (0 - совпадают, 1 - не совпадают)
                        int symbEqual = (str1[i - 1] == str2[j - 1]) ? 0 : 1;

                        // Три операции: удаление, вставка, замена
                        int del = matrix[i - 1, j] + 1;      // Удаление
                        int ins = matrix[i, j - 1] + 1;      // Вставка
                        int subst = matrix[i - 1, j - 1] + symbEqual; // Замена

                        // Элемент матрицы вычисляется как минимальный из трех случаев
                        matrix[i, j] = Math.Min(Math.Min(ins, del), subst);

                        // Дополнение Дамерау: проверка на транспозицию (перестановку соседних символов)
                        if (i > 1 && j > 1 &&
                            str1[i - 1] == str2[j - 2] &&
                            str1[i - 2] == str2[j - 1])
                        {
                            // Транспозиция: стоимость 1
                            matrix[i, j] = Math.Min(matrix[i, j], matrix[i - 2, j - 2] + 1);
                        }
                    }
                }

                // Возвращается нижний правый элемент матрицы
                return matrix[str1Len, str2Len];
            }

        }
    }
}
