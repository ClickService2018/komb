using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace po
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-D5MISNE\SQLEXPRESS;Initial Catalog=FXvendorSCAN;Persist Security Info=True;User ID=sa;Password=123halo321");
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT top 3 [extid],[anzahl] FROM [FXvendorSCAN].[dbo].[tm140916FXamVCorderLOG]", connection);
            SqlDataReader dataReader = command.ExecuteReader();
            List<string> nae = new List<string>();
            int count = 0;
            while (dataReader.Read())
            {
                for (int j = 0; j < Convert.ToInt32(dataReader[1].ToString()); j++)
                {
                    nae.Add(dataReader[0].ToString());
                }
               // count++;
                //Console.WriteLine(dataReader[0] + " - " + dataReader[1]);
               // nae.Add(dataReader[0].ToString());
            }
            //for (int i = 0; i < count; i++)
            //{
            //    for (int j = 0; j < Convert.ToInt32(dataReader[1].ToString()); j++)
            //    {
            //        nae.Add(dataReader[0].ToString());
            //    }
            //}
            string[,] ean = new string[,] { { "a", "2" }, { "b", "5" }, { "c", "3" }, { "d", "2" } };
            List<string> allEan = new List<string>();
            List<string> combination = new List<string>();
            List<string> final = new List<string>();


            // Preapre ean list
            for (int i = 0; i < ean.Length / 2; i++)
            {
                for (int j = 0; j < Convert.ToInt32(ean[i, 1]); j++)
                {
                    allEan.Add(ean[i, 0]);
                }
            }



            combinations(nae, combination);

            foreach (string comb in combination)
            {
                if (final.Count > 0)
                {
                    //var aSet = new HashSet<char>(comb);
                    int combCount = final.Count;
                    bool find = false;
                    for (int i = 0; i < combCount; i++)
                    {
                        //bool abSame = aSet.SetEquals(final[i]);
                        if (final[i] == comb)
                        {
                            find = true;
                            break;
                        }
                    }
                    if (find == false)
                    {
                        final.Add(comb);
                    }
                }
                else if (final.Count == 0)
                {
                    final.Add(comb);
                }

                foreach (string result in final)
                {
                    if (result[0] == 'd')
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine(result);
                    }
                    if (result[0] == 'c')
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(result);
                    }
                    if (result[0] == 'b')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(result);
                    }
                    if (result[0] == 'a')
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine(result);
                    }

                }

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("All Combination: " + combination.Count);

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Final Combinations: " + final.Count);

                Console.ReadKey();
            }
            connection.Close();
            Console.ReadLine();
        }
        static void combinations(List<string> list, List<string> fin)
        {
            double count = Math.Pow(2, list.Count);
            for (int i = 1; i <= count - 1; i++)
            {
                string str = Convert.ToString(i, 2).PadLeft(list.Count, '0');
                //Console.WriteLine(str);
                string comb = "";
                for (int j = 0; j < str.Length; j++)
                {

                    if (str[j] == '1')
                    {
                        comb = comb + list[j] + "||";
                    }

                }
                //Console.WriteLine(comb);
                fin.Add(comb);
            }
        }
    }
}
