using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Polibiy polibiy = new Polibiy();

            bool active = true;

            while (active)
            {
                Console.Clear();

                var choise = ReadValueFromConsole<int>(@"Выбирете метод шифровки-дешефровки сообщения: 
                                                        1. Плейфер
                                                        2. Полибий
                                                        3. RSA");

                switch (choise)
                {
                    case 1:
                        Console.Clear();
                        ActivateMenu();
                        break;
                    case 2:
                        Console.Clear();
                        var choisePolibiy = ReadValueFromConsole<int>(@"Выбирете действие: 
                                                        1. Зашифровать указанную строку
                                                        2. Десшифровать указанную строку");
                        switch (choisePolibiy)
                        {
                            case 1:
                                Console.Clear();
                                polibiy.Coding();
                                break;
                            case 2:
                                Console.Clear();
                                polibiy.Decoding();
                                break;
                            default:
                                break;
                        }
                        break;
                    case 3:
                        Console.Clear();
                        RSA rsa = new RSA();

                        Console.WriteLine("Введите p и q");
                        string parameter_p = Console.ReadLine();
                        string parameter_q = Console.ReadLine();

                        Console.WriteLine("Введите значение e и d");
                        string parameter_e = Console.ReadLine();
                        string parameter_d = Console.ReadLine();

                        var choiseRSA = ReadValueFromConsole<int>(@"Выбирете действие: 
                                                        1. Зашифровать указанную строку
                                                        2. Десшифровать указанную строку");

                        switch (choiseRSA)
                        {
                            case 1:
                                Console.WriteLine("Введите сообщение для дальнейшей кодировки: ");
                                string message = Console.ReadLine();

                                rsa.Code(parameter_p, parameter_q, parameter_e, parameter_d, message);
                                break;
                            case 2:
                                Console.WriteLine("Введите части сообщения для дешефровки: ");
                                List<string> parameters = new List<string>();


                                for (int i = 0; i < 3; i++)
                                {
                                    parameters.Add(Console.ReadLine());
                                }

                                string parameter_n = (Convert.ToInt32(parameter_p) * Convert.ToInt32(parameter_q)).ToString();

                                rsa.Decode(parameter_d, parameter_n, parameters);
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }
            }

            ActivateMenu(); 

            //polibiy.Coding();
            //polibiy.Decoding();

            //RSA rsa = new RSA();

            //Console.WriteLine("Введите p и q");
            //string parameter_p = Console.ReadLine();
            //string parameter_q = Console.ReadLine();

            //Console.WriteLine("Введите значение e и d");
            //string parameter_e = Console.ReadLine();
            //string parameter_d = Console.ReadLine();

            //Console.WriteLine("Введите сообщение для дальнейшей кодировки");
            //string message = Console.ReadLine();

            //rsa.Code(parameter_p, parameter_q, parameter_e, parameter_d, message);

            //Console.WriteLine("Введите части сообщения");
            //List<string> parameters = new List<string>();

           
            //for (int i = 0; i < 3; i++)
            //{
            //    parameters.Add(Console.ReadLine());
            //}

            //string parameter_n = (Convert.ToInt32(parameter_p) * Convert.ToInt32(parameter_q)).ToString();

            //rsa.Decode(parameter_d, parameter_n, parameters);


        }

        public static T ReadValueFromConsole<T>(string message)
        {
            //Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            //Console.ForegroundColor = ConsoleColor.White;
            while (true)
            {
                try
                {
                    return (T)Convert.ChangeType(Console.ReadLine(), typeof(T));
                }
                catch (Exception)
                {
                    Console.WriteLine("Возникла ошибка. Повторите ввод");
                }
            }

        }

        private static void ActivateMenu()
        {
            var alph = /*ReadValueFromConsole<string>("Введите алфавит");*/
            // АБВГДЕЖЗИКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ
            "АБВГДЕЖЗИКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";

            var key = ReadValueFromConsole<string>("\nВведите ключевое слово");

            var pc = new PlayfairCipher(alph, key);
                Console.Clear();
                var choise = ReadValueFromConsole<int>(@"Выберите действие:
                                                        1. Зашифровать указанную строку
                                                        2. Десшифровать указанную строку");
                switch (choise)
                {
                    case 1:
                        Console.Clear();
                        Console.Write("Шифрование строки.");
                        var normalMessage = ReadValueFromConsole<string>("\nВведите строку для шифрования: ");
                        // КОД ПЛЕЙФЕЙЕРА ОСНОВАН НА ИСПОЛЬЗОВАНИИ МАТРИЦЫ БУКВ
                        // "КОД ПЛЕЙФЕЙЕРА ОСНОВАН НА ИСПОЛЬЗОВАНИИ МАТРИЦЫ БУКВ";
                        var crypted = pc.Crypt(normalMessage);
                        Console.WriteLine("\nResult: " + crypted);
                        Console.WriteLine("De-crypted back: " + pc.Uncrypt(crypted));
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        Console.Write("Дешифрование строки.");
                        var cryptedMessage = ReadValueFromConsole<string>("\nВведите строку для дешифровки: ");
                        // МОЩЕЯВЧЪЛТАПЯВМОМРЗФИЫПТБКВИХБЦБЩШЪЧШЩИВТЧОАДХОПАБТИВАРМЖИ
                        //"МОЩЕЯВЧЪЛТАПЯВМОМРЗФИЫПТБКВИХБЦБЩШЪЧШЩИВТЧОАДХОПАБТИВАРМЖИ";
                        var normal = pc.Uncrypt(cryptedMessage);
                        Console.WriteLine("\nResult: " + normal);
                        Console.WriteLine("Crypted back: " + pc.Crypt(normal));
                        Console.ReadKey();
                        break;
                    default:
                        break;
            }
        }
    }
}
