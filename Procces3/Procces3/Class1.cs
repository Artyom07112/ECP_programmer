using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;
using System.Numerics;
using System.Threading.Tasks;

namespace Procces3
{
    class Class1
    {

        public static List<BigInteger> big;
        public string HASHIRING(string hash)
        {
            //hash = Zash(hash);
            hash = Zash(hash);
            List<BigInteger> bigIntegers = RSA(hash);
            Serf(bigIntegers);
            return hash;
        }
        public void Second_deu()
        {
            big = Vtoray_proga(Getiitng(), d, N);
            big = Vtoray_proga(big, d, N);
            Serf(big);
        }
        public string first_deu()
        {
            string hash = Vtoraya_proga_2(Getiitng(), e, N);
            return hash;
        }

        public static string Zash(string slovo)
        {
            while (slovo.Length % 4 != 0)
            {
                slovo += " ";
            }
            char[] text = slovo.ToCharArray();
            for (int i = 4; i < text.Length; i += 4)
            {
                for (int j = 0; j < 4; j++)
                {
                    text[j] = (char)((((int)text[j] * (int)text[i]) ^ (int)text[j]) % (int)text.Length);
                }
            }
            string hs = "";
            for (int i = 0; i < 4; i++)
            {
                hs += text[i];
            }
            return hs;

        }

        public static int d, N, e;
        public static Random rand = new Random();
        public static List<BigInteger> RSA(string slovo)
        {
            double p, q, Fn;

            List<BigInteger> list1 = new List<BigInteger>();
            ArrayList list_for_rand_e = new ArrayList();
            double[] Prostie_chisla = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 };
            p = Prostie_chisla[rand.Next(0, Prostie_chisla.Length)];
            q = Prostie_chisla[rand.Next(0, Prostie_chisla.Length)];
            N = Convert.ToInt32(q * p);
            Fn = (p - 1) * (q - 1);
            for (int i = 1; i < Prostie_chisla.Length; i++)
            {
                if (Prostie_chisla[i] % N != 0 && Prostie_chisla[i] < Fn)
                {
                    list_for_rand_e.Add(Prostie_chisla[i]);
                }
            }
            e = Convert.ToInt32(list_for_rand_e[rand.Next(list_for_rand_e.Count)]);
            // list1.Clear();
            char[] mass = slovo.ToCharArray();
            for (int i = 0; i < mass.Length; i++)
            {
                BigInteger big = (BigInteger.Pow(mass[i], e) % N);
                list1.Add(big);
            }
            d = 0;
            while ((d * e) % Fn != 1)
            {
                d++;
            };
            // Console.WriteLine("Ключ для расшифровки " + d + " " + N);
            return list1;
        }
        public int Return_N_Key()
        {
            return N;
        }
        public int Return_e_Key()
        {
            return e;
        }
        public int Return_D_key()
        {
            return d;
        }
        public static List<BigInteger> Getiitng()
        {
            StreamReader streamread = new StreamReader(@"C:\Users\artik\OneDrive\Рабочий стол\Key.txt");

            string text = streamread.ReadLine();
            streamread.Close();
            Console.WriteLine();
            List<BigInteger> list = new List<BigInteger>();
            string[] mass = text.Split(new char[] { ' ' });

            foreach (var item in mass)
            {
                if (item != "")
                {
                    list.Add(Convert.ToInt32(item));
                }

            }

            return list;
        }
        public List<BigInteger> Vtoray_proga(List<BigInteger> bigIntegers, int d, int N)
        {

            List<BigInteger> list = new List<BigInteger>();
            //char[] mass = hash.ToCharArray();
            for (int i = 0; i < bigIntegers.Count; i++)
            {
                BigInteger big = (BigInteger.Pow(bigIntegers[i], d) % N);
                list.Add(big);
            }
            return list;

        }
        public static string Vtoraya_proga_2(List<BigInteger> list, int e, int N)
        {
            string hash = "";
            ArrayList list_index = new ArrayList();
            for (int i = 0; i < list.Count; i++)
            {
                BigInteger lol = (BigInteger.Pow((BigInteger)list[i], e) % N);
                list_index.Add(lol);
            }
            foreach (BigInteger big in list_index)
            {
                hash +=(char)big;
            }
            return hash;
        }
        public void Serf(List<BigInteger> arrayList)
        {
            string key = "";
            foreach (var item in arrayList)
            {
                key += item + " ";
            }
            StreamWriter streamWriter = new StreamWriter(@"C:\Users\artik\OneDrive\Рабочий стол\Key.txt");

            streamWriter.WriteLine(key);
            streamWriter.Close();

        }
    }
}
