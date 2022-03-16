using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    internal class RSA
    {
        //char[] characters = new char[] {'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И',
        //                           'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т',
        //                           'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь',
        //                           'Э', 'Ю', 'Я', 'а', 'б', 'в', 'г', 'д', 'е', 'ё',
        //                           'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п',
        //                           'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ',
        //                           'ъ', 'ы', 'ь', 'э', 'ю', 'я', '0', '1', '2', '3',
        //                           '4', '5', '6', '7', '8', '9', ' ', '.', ',', '!',
        //                           '?', ';', ':', '"', '-', '{', '}', '[', ']', '_',
        //                       };

        char[] characters = new char[] { '#', 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И',
                                                'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С',
                                                'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ь', 'Ы', 'Ъ',
                                                'Э', 'Ю', 'Я', ' ', '1', '2', '3', '4', '5', '6', '7',
                                                '8', '9', '0' };

        public void Code(string parameter_p, string parameter_q, string parameter_e, string parameter_d, string message)
        {
            if ((parameter_p.Length > 0) && (parameter_q.Length > 0))
            {
                long p = Convert.ToInt64(parameter_p);
                long q = Convert.ToInt64(parameter_q);

                if (IsTheNumberSimple(p) && IsTheNumberSimple(q))
                {
                    //message.ToUpper();

                    long n = p * q;
                    long m = (p - 1) * (q - 1);
                    long d = Convert.ToInt32(parameter_d);
                    long e = Convert.ToInt32(parameter_e);
                    //long d = CalculateParameterD(m);
                    //long e = CalculateParameterE(d, m);

                    Console.WriteLine($"Полученный секретный ключ d = {d} и n = {n}");

                    List<string> result = Rsa_Code(message, e, n);

                    foreach (string s in result)
                    {
                        Console.WriteLine(s);
                    }
                    Console.ReadKey();
                }
                else
                    Console.WriteLine("p или q - не простые числа!");
            }
            else
                Console.WriteLine("Введите p и q!");
        }

        public void Decode(string parameter_d, string parameter_n, List<string> message)
        {
            if ((parameter_d.Length > 0) && (parameter_n.Length > 0))
            {
                long d = Convert.ToInt64(parameter_d);
                long n = Convert.ToInt64(parameter_n);

                string result = RSA_Decode(message, d, n);

                Console.WriteLine(result);
                Console.ReadKey();
            }
            else
                Console.WriteLine("Введите секретный ключ!");
        }

        private List<string> Rsa_Code (string message, long e, long n)
        {
            List<string> result = new List<string>();

            BigInteger bi;

            for (int i = 0; i < message.Length; i++)
            {
                int index = Array.IndexOf(characters, message[i]);

                bi = new BigInteger(index);
                bi = BigInteger.Pow(bi, (int)e);

                BigInteger n_ = new BigInteger((int)n);

                bi = bi % n_;

                result.Add(bi.ToString());
            }

            return result;
        }

        private string RSA_Decode(List<string> input, long d, long n)
        {
            string result = "";

            BigInteger bi;

            foreach (string s in input)
            {
                bi = new BigInteger(Convert.ToDouble(s));
                bi = BigInteger.Pow(bi, (int)d);

                BigInteger n_ = new BigInteger((int)n);

                bi = bi % n_;

                int index = Convert.ToInt32(bi.ToString());

                result += characters[index].ToString();
            }

            return result;
        }

        private bool IsTheNumberSimple(long n)
        {
            if (n < 2)
                return false;

            if (n == 2)
                return true;

            for (long i = 2; i < n; i++)
                if (n % i == 0)
                    return false;

            return true;    
        }

        //private long CalculateParameterD (long m)
        //{
        //    long d = m - 1;

        //    for (long i = 2; i <= m; i++)
        //        if ((m%i == 0) && (d % i == 0))
        //        {
        //            d--;
        //            i = 1;
        //        }

        //    return d;
        //}

        //private long CalculateParameterE (long d, long m)
        //{
        //    long e = 10;

        //    while (true)
        //    {
        //        if ((e * d) % m == 1)
        //            break;
        //        else
        //            e++;
        //    }

        //    return e;
        //}

    }
}
