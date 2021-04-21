using System.Collections.Generic;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace PracticeSharp
{
    public record Jarmu(int hour, int min, int sec, string plate)
    {
        public static List<Jarmu> Readin(string path)
        {
        string[] readText = File.ReadAllLines(path);

        List<Jarmu> Vehicles = new();

        foreach (string s in readText)
        {
            string[] line = s.Split(" ");
            
            Vehicles.Add(new Jarmu(Converter.Stringtoint(line[0]),Converter.Stringtoint(line[1]),Converter.Stringtoint(line[2]), line[3]));
        }
        //Vehicles.ForEach(x => System.Console.WriteLine(x.ToString()));

        return Vehicles;
        }

        public static void HowManyHours(List<Jarmu> l)
        {
            int workhours = l.Last().hour - l[0].hour;
            int w2 = l[^1].hour - l[0].hour;
            System.Console.WriteLine($"{w2} órát dolgoztak");
        }

        public static void FirstCars(List<Jarmu> l)
        {
            int i = l[0].hour;
            foreach (var item in l)
            {
                if (i == item.hour)
                {
                    System.Console.WriteLine(item.plate);
                    i++;
                }
                
            }
        }
        
        public static void BKM(List<Jarmu> l)
        {   // ezt lehetne még 2szer megcsinálni, de az nem hatékony
            //int b = l.Where(x => x.plate[0] == 'B').Count();

          //  System.Console.WriteLine(result.where);
            
           (int B, int K, int M, int stb) tuple = (0,0,0,0);




            foreach (var item in l)
            {
                switch (item.plate[0])
                {
                case 'B':
                    tuple.B++;
                    break;
                case 'K':
                    tuple.K++;
                    break;
                case 'M':
                    tuple.M++;
                    break;
                 default:
                    tuple.stb++;
                    break;
                }
            }

            System.Console.WriteLine($"B:{tuple.Item1}; K:{tuple.Item2}; M:{tuple.Item3}" +
                $" {nameof(tuple.stb)}: {tuple.stb}");
        }

        public static void FindVehicle(List<Jarmu> l)
        {
            string pattern = Converter.TexttoPattern();
            l.Where(x=> Regex.IsMatch(x.plate, pattern)).ToList().ForEach(x => Console.WriteLine(x.plate));
        }

        public static void Longestnothing(List<Jarmu> list)
        {
            int longest = 0;
            var max = "";
            for (int i = 1; i < list.Count; i++)
            {
                var i1 = (list[i-1].hour * 3600) + (list[i-1].min * 60) + list[i-1].sec;

                var i2 = (list[i].hour * 3600) + (list[i].min * 60) + list[i].sec;

                var i3 = i2 - i1;

                if (longest < i3)
                {
                    longest = i3;
                    max = $"{list[i-1]} - {list[i]}";
                }
            }
            Console.WriteLine(max);         
        }

        public static void WriteToFile(List<Jarmu> list)
        {
            int ido = 300;
            using StreamWriter file = new("vizsgalt.txt");
            file.WriteLine(list[0]);
            for (int i = 1; i < list.Count; i++)
            {
                var i2 = (list[i].hour * 3600) + (list[i].min * 60) + list[i].sec;

                var i1 = (list[i - 1].hour * 3600) + (list[i - 1].min * 60) + list[i - 1].sec;

                var i3 = i2 - i1;
                ido -= i3;
                if (ido <= 0)
                {
                    file.WriteLine(list[i]);
                    ido = 300;
                }

            }
        }
    }


    public static class Converter{

        public static int Stringtoint(string s)
        {
            bool success = int.TryParse(s, out int result);

            if(success)
            {
                return result;
            }
            return Stringtoint(s);
        }

        public static string TexttoPattern()
        {
            System.Console.WriteLine("Egy rendszamot pls!");
            string plate = Console.ReadLine();


            StringBuilder sb = new();
            sb.Append("^");
            foreach (var item in plate)
            {
                if (item != '*')
                {
                    sb.Append(item);
                }
                else{
                    sb.Append("\\w");
                }
            }
            sb.Append("$");
            return sb.ToString();
        }
    }
}