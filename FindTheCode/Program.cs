using System;

namespace FindTheCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n\t\t\t\tДобро пожаловать в игру Find the Code!\n");
            Console.WriteLine("Её правила просты:\nИгра генерирует 4-х значное число, которое вам необходимо угадать.");
            Console.WriteLine("Если в введённом вами числе есть верные цифры на верном месте, либо же верные цифры на неверном месте, игра сообщит.");
            Console.WriteLine("\nВыберите режим игры:");
            Console.WriteLine("\t1. Неограниченный: 1000 попыток");
            Console.WriteLine("\t2. Лёгкий: 12 попыток");
            Console.WriteLine("\t3. Средний: 7 попыток");
            Console.WriteLine("\t4. Сложный: 4 попытки");
            Console.WriteLine("\t5. Фортуна: 1 попытка");
            Console.Write("\nВведите номер режима >> ");

            int AttemptAmount = 0, allRightCount = 0, notRightPlaceCount = 0, AttemptCount = 0;
            string border = "----------------------------------------------------------------------";
            int[] attempts = { 1000, 12, 7, 4, 1 };

            if (!byte.TryParse(Console.ReadLine(), out byte mode) || mode < 1 || mode > 5)
            {
                Console.WriteLine("Ошибка! Режим выбран неверно!\nПопробуйте заново");
                return;
            } 

            AttemptAmount = attempts[mode - 1];
            Console.WriteLine($"Режим выбран\nПопыток: {AttemptAmount}\n\t\t\t\tУдачи!");

            Random rand = new Random();
            string code = rand.Next(1000, 10000).ToString();

            Console.Write("\nНажмите любую клавишу чтобы играть...");
            Console.ReadKey();
            Console.Clear();

            while (AttemptAmount > 0)
            {
                AttemptCount++;
                AttemptAmount--;

                Console.Write("\nВведите код >> ");
                var userAttempt = Console.ReadLine().ToCharArray();
                char[] codeArray = code.ToCharArray();

                if(userAttempt.Length != 4 || !int.TryParse(userAttempt, out int var))
                {
                    Console.WriteLine("Что-то пошло не так! Кажется, вы ввели неверное число\nВ следующий раз будте внимательнее");
                    Console.WriteLine($"\nПопыток потрачено: {AttemptCount}\nПопыток осталось: {AttemptAmount}");
                    continue;
                }

                if (userAttempt.ToString() == code)
                {
                    Console.Clear();
                    Console.WriteLine("Вам удалось угадать код!");
                    Console.WriteLine($"\nПопыток потрачено: {AttemptCount}\nПопыток осталось: {AttemptAmount}");
                    return;
                }

                for (int i = 0; i < 4; i++) //Сравнение чисел на правильное значение и правильное место
                    if (userAttempt[i] == codeArray[i])
                    {
                        allRightCount++;
                        codeArray[i] = 'n'; //Замена на буквы нужна на случай, если цифры повторяются
                        userAttempt[i] = 'm';
                    }
                
                for(int x = 0; x < 4; x++) //Сравнение чисел на правильное значение но неправильно место
                    for(int i = 0; i < 4; i++)
                        if(userAttempt[x] == codeArray[i])
                        {
                            notRightPlaceCount++;
                            codeArray[i] = 'n';
                            userAttempt[x] = 'm';
                        }

                Console.WriteLine("\nУвы, вам не удалось угадать код. Не отчаивайтесь, попробуйте ещё\n");
                Console.WriteLine($"Количество правильных цифр на правильном месте = {allRightCount}");
                Console.WriteLine($"Количество правильных цифр на неправильном месте = {notRightPlaceCount}\n");
                Console.WriteLine($"{border}\n");

                allRightCount = 0;
                notRightPlaceCount = 0;
            }

            Console.Clear();
            Console.WriteLine($"Сожалею, но вы так и не смогли угадать. Кодом было число {code}");
            Console.WriteLine("Но вы всегда можете попробовать ещё раз, просто начав заново!");
        }
    }
}