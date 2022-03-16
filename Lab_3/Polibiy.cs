using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    public class Polibiy
    {

        char[,] alfrus = {     {'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И'},
                                   {'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т'},
                                   {'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь'},
                                   {'Э', 'Ю', 'Я', 'а', 'б', 'в', 'г', 'д', 'е', 'ё'},
                                   {'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п'},
                                   {'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ'},
                                   {'ъ', 'ы', 'ь', 'э', 'ю', 'я', '0', '1', '2', '3'},
                                   {'4', '5', '6', '7', '8', '9', ' ', '.', ',', '!'},
                                   {'?', ';', ':', '"', '-', '{', '}', '[', ']', '_'},
                               };



        public void Coding()
        {
            Console.WriteLine("Введите сообщение для шифровки: ");

            string message = Console.ReadLine();
            string new_message = "";

            for (int i = 0; i < message.Length; i++)
            {
                for (int j = 0; j < alfrus.GetLength(0); j++)
                {
                    for (int k = 0; k < alfrus.GetLength(1); k++)
                    {
                        if (alfrus[j, k] == message[i])
                        {
                            new_message += (Convert.ToString(j) + Convert.ToString(k));
                            break;
                        }
                    }
                }
            }

            Console.WriteLine(new_message);
            Console.ReadKey();
        }

        public void Decoding()
        {
            Console.WriteLine("Введите сообщение для дешифровки: ");

            string message = Console.ReadLine();

            int count = 0;

            while (count < message.Length)
            {
                //new_message += alfrus[message[count], message[count + 1]];

                Console.Write(alfrus[Convert.ToInt32(Convert.ToString(message[count])), Convert.ToInt32(Convert.ToString(message[count + 1]))]);

                //Console.WriteLine(Convert.ToInt32(Convert.ToString(message[count])));

                count += 2;
            }

            Console.ReadKey();
        }

    }
}
