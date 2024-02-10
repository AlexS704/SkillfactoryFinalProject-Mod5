using System;
using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;

namespace Final.Draft.Of.Module5
{

    internal class Program
    {
        static void Main(string[] args)
        {

            GetUserData();         
                                 

        }

        static (string userName, string userSurname, byte userAge, bool havingPet) GetUserData()
        {

            (string userName, string userSurname, byte userAge, bool havingPet) userAnketa;

            Console.Write("Введите свое имя: ");
            userAnketa.userName = Console.ReadLine();

            Console.Write("Введите свою фамилию: ");
            userAnketa.userSurname = Console.ReadLine();
                       
            userAnketa.userAge = ValidateTheData("Введите свой возраст: ");
            
            Console.WriteLine("Наличие питомца: введите да или нет");
            string petUser = Console.ReadLine();

            bool havingPet;

            if (petUser == "да")
            {
                userAnketa.havingPet = true;

                if (userAnketa.havingPet == true)
                {
                    byte pet_populat = ValidateTheData("Введите количество ваших питомцев: ");

                    var arrayNamesPet = GetPetNames(ref pet_populat);
                    byte userColorCount = ValidateTheData("Введите количество ваших любимых цветов: ");
                    GetUserColors(ref userColorCount, userAnketa.userName);
                    GetQuestionnaireData(userAnketa);

                    Console.WriteLine("Клички ваших животных:");
                    foreach (var item in arrayNamesPet)
                    {
                        Console.WriteLine(item);
                    }                                                         

                }
            }
            else
            {
                userAnketa.havingPet = false;
                byte userColorCount = ValidateTheData("Введите количество ваших любимых цветов: ");
                GetUserColors(ref userColorCount, userAnketa.userName);
                GetQuestionnaireData(userAnketa);

            }                      

            return userAnketa;

        }

        static string[] GetPetNames(ref byte pet_populat)
        {

            string[] petNameArray = new string[pet_populat];

            for (int i = 0; i < petNameArray.Length; i++)
            {
                Console.WriteLine("Введите имя питомца {0}:", i + 1);
                petNameArray[i] = Console.ReadLine();
                                                
            }
                        
            return petNameArray;
        }

        static string[] GetUserColors(ref byte countColor, string userName)        
        {

            Console.WriteLine("{0}," + $"{Environment.NewLine}Напишите свои любимые цвета", userName);

            string[] favcolors = new string[countColor];
                        
            for (int i = 0; i < countColor; i++)
            {

                Console.Write(i + 1 + " цвет: ");
                favcolors[i] = Console.ReadLine();
                              
            }

            
            Console.WriteLine("Ваши любимые цвета: ");
            foreach (var item in favcolors)
            {
                Console.WriteLine(item);
            }
           
            return favcolors;
        }

        static byte ValidateTheData(string prompt)
        {
            byte result;
            bool isValid;

            do
            {
                Console.Write(prompt);
                string userInput = Console.ReadLine();

                isValid = TryParseByte(userInput, out result) && result > 0;

                if (!isValid)
                {
                    Console.WriteLine("Некорректный ввод. Пожалуйста, введите корректное значение.");
                }

            } while (!isValid);

           

            return result;
        }

        static bool TryParseByte(string input, out byte result)
        {
            return byte.TryParse(input, out result);
        }

        static void GetQuestionnaireData((string userName, string userSurname, byte userAge, bool havingPet) userAnketa)
        {
            
            Console.WriteLine($"Имя: {userAnketa.userName}");
            Console.WriteLine($"Фамилия: {userAnketa.userSurname}");
            Console.WriteLine($"Возраст: {userAnketa.userAge}");
            Console.WriteLine($"Наличие питомца: {userAnketa.havingPet}");
        }



    }
}
