using System;
using System.Text.RegularExpressions;

namespace ConsoleApp119
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding=System.Text.Encoding.UTF8;
            Console.InputEncoding=System.Text.Encoding.UTF8;


            string email;
            string password;
            string cardInfo;
            string city;
            int numberOfMonths;

            Console.WriteLine("Добре дошли в програмата за закупуване на билети!");

            // Въвеждане на имейл и парола
            Console.WriteLine("Моля, въведете вашия имейл: ");
            email = Console.ReadLine();

            while (!IsValidEmail(email))
            {
                Console.WriteLine("Невалиден имейл. Моля, въведете валиден имейл: ");
                email = Console.ReadLine();
            }

            Console.WriteLine("Моля, въведете вашия парола (минимум 8 знака): ");
            password = Console.ReadLine();

            while (!IsValidPassword(password))
            {
                Console.WriteLine("Невалидна парола. Паролата трябва да бъде поне 8 знака и да съдържа поне една цифра: ");
                password = Console.ReadLine();
            }

            // Въвеждане на информация за дебитната карта
            Console.WriteLine("Моля, въведете информацията за вашата дебитна карта (16 цифри разделени на групи по четири, дата на изтичане, трицифрено число): ");
            cardInfo = Console.ReadLine();

            while (!IsValidCardInfo(cardInfo))
            {
                Console.WriteLine("Невалидна информация за дебитната карта. Моля, въведете отново (16 цифри разделени на групи по четири, дата на изтичане, трицифрено число): ");
                cardInfo = Console.ReadLine();
            }

            // Избор на град
            Console.WriteLine("Моля, изберете град (Varna, Burgas, Plovdiv, Sofia): ");
            city = Console.ReadLine();

            while (!IsValidCity(city))
            {
                Console.WriteLine("Невалиден град. Моля, изберете от следните: Варна, Бургас, Пловдив, София");
                city = Console.ReadLine();
            }

            // Избор на спирка
            Console.WriteLine("Моля, изберете спирка (1, 2, 3): ");
            string busStopOption = Console.ReadLine();
            while (busStopOption != "1" && busStopOption != "2" && busStopOption != "3")
            {
                Console.WriteLine("Невалидна спирка. Моля, изберете спирка от 1 до 3: ");
                busStopOption = Console.ReadLine();
            }

            // Генериране на автобуси и минути
            string[] busOptions = GenerateRandomBuses(busStopOption);
            int[] arrivalMinutes = GenerateRandomArrivalMinutes();

            Console.WriteLine($"Автобуси на спирка {busStopOption}:");
            for (int i = 0; i < busOptions.Length; i++)
            {
                Console.WriteLine($"Автобус {busOptions[i]} - Очаквано пристигане след {arrivalMinutes[i]} минути.");
            }

            // Избор на билет или карта
            string option;
            do
            {
                Console.WriteLine("Моля, изберете опция:\n1. Закупуване на билет\n2. Закупуване на карта за 10 дни\n3. Закупуване на месечна карта\n4. Изход");
                option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.WriteLine("Избрахте опция 1 - закупуване на билет.");
                        // Реализирайте логиката за закупуване на билет тук
                        Console.WriteLine("Цена на билета за 1 час: 1 лев.");
                        break;
                    case "2":
                        Console.WriteLine("Избрахте опция 2 - закупуване на карта за 10 дни.");
                        // Реализирайте логиката за закупуване на карта за 10 дни тук
                        Console.WriteLine("Цена на карта за 10 дни: 10 лева.");
                        break;
                    case "3":
                        Console.WriteLine("Избрахте опция 3 - закупуване на месечна карта.");
                        // Реализирайте логиката за закупуване на месечна карта тук
                        Console.WriteLine("Цена на месечна карта: 15 лева.");
                        Console.WriteLine("За колко месеца искате да закупите картата?");
                        int.TryParse(Console.ReadLine(), out numberOfMonths);
                        while (numberOfMonths <= 0)
                        {
                            Console.WriteLine("Невалиден брой месеци. Моля, въведете положително число: ");
                            int.TryParse(Console.ReadLine(), out numberOfMonths);
                        }
                        Console.WriteLine($"Цена на месечната карта за {numberOfMonths} месеца: {numberOfMonths * 15} лева.");
                        break;
                    case "4":
                        Console.WriteLine("Избрахте опция 4 - изход. До свидане!");
                        break;
                    default:
                        Console.WriteLine("Невалидна опция. Моля, опитайте отново.");
                        break;
                }
            } while (option != "4");
        }

        static bool IsValidEmail(string email)
        {
            // Проверка на валидността на имейла с регулярен израз
            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            return Regex.IsMatch(email, pattern);
        }

        static bool IsValidPassword(string password)
        {
            // Проверка на валидността на паролата с регулярен израз
            string pattern = @"^(?=.*\d).{8,}$";
            return Regex.IsMatch(password, pattern);
        }

        static bool IsValidCity(string city)
        {
            // Проверка на валидността на града
            string[] validCities = { "Varna", "Burgas", "Plovdiv", "Sofia" };
            return Array.Exists(validCities, c => c.Equals(city, StringComparison.OrdinalIgnoreCase));
        }

        static bool IsValidCardInfo(string cardInfo)
        {
            // Проверка на валидността на информацията за дебитната карта
            string pattern = @"^\d{4} \d{4} \d{4} \d{4} \d{2}\/\d{2} \d{3}$";
            return Regex.IsMatch(cardInfo, pattern);
        }

        static string[] GenerateRandomBuses(string busStopOption)
        {
            // Генериране на различни автобуси за всяка спирка
            string[] buses;
            switch (busStopOption)
            {
                case "1":
                    buses = new string[] { "Автобус 1", "Автобус 2", "Автобус 3" };
                    break;
                case "2":
                    buses = new string[] { "Автобус 4", "Автобус 5", "Автобус 6" };
                    break;
                case "3":
                    buses = new string[] { "Автобус 7", "Автобус 8", "Автобус 9" };
                    break;
                default:
                    buses = new string[0];
                    break;
            }
            return buses;
        }

        static int[] GenerateRandomArrivalMinutes()
        {
            // Генериране на случайни минути за пристигане на автобусите
            Random random = new Random();
            int[] arrivalMinutes = new int[3];
            for (int i = 0; i < arrivalMinutes.Length; i++)
            {
                arrivalMinutes[i] = random.Next(1, 31); // Генериране на число от 1 до 30
            }
            return arrivalMinutes;
        }
    }
}
