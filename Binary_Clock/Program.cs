using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Binary_Clock
{
    internal class Program
    {
        static void Main(string[] args)
        {           
                STPUPDT();
                FINISH();
        }

        private static void FINISH()
        {
            return;
        }

        static void Clock()
        {
            Console.Clear();
            Console.WriteLine("Binary Coded Decimal Clock : ");           
            PrintClock();
        }
        static void STPUPDT()
        {
            Stopwatch update;
            update = Stopwatch.StartNew();
            do
            {
                for (long i = update.ElapsedMilliseconds; i < update.ElapsedMilliseconds + 1; i++)
                {                   
                    if (i % 1000 == 0)
                    {
                        Clock();                        
                    }
                    
                }
            }
            while (true);

        }
        static DateTime Time_Update()
        {
            return DateTime.Now;
        }
        static void PrintClock() // metoda romaneasca, we like typing
        {
            PrintRowSimple();
            PrintRowHeader();
            PrintRowSimple();
            PrintRowEmpty();
            PrintRow1();
            PrintRowEmpty();
            PrintRow2();
            PrintRowEmpty();
            PrintRow3();
            PrintRowEmpty();
            PrintRow4();
            PrintRowEmpty();
            PrintRowSimple();
            PrintRowConvert();
            PrintRowSimple();
        }
        static void PrintRowSimple()
        {
            Console.Write("\n|");
            for (int i = 0; i < 35; i++)
            {
                Console.Write("-");
            }
            Console.Write("|");
        }
        static void PrintRowEmpty()
        {
            Console.Write("\n|");
            for (int i = 0; i < 35; i++)
            {
                if (i == 11 || i == 23 ) Console.Write("|"); 
                else Console.Write(" ");
            }
            Console.Write("|");
        }
        static void PrintRowHeader()
        {
            Console.Write("\n|");
            for (int i = 1; i <= 35; i++)
            {
                if (i % 4 != 0) Console.Write(" ");
                if (i == 4 || i == 8) Console.Write("H");
                if (i == 16 || i == 20) Console.Write("M");
                if (i == 28 || i == 32) Console.Write("S");
                if (i % 4 == 0 && i % 3 == 0) Console.Write("|");                
            }
            Console.Write("|");
        }
        static void PrintRow1() // pentru ca valorile binare se duc pe coloane iar tabelul este tiparit pe randuri am facut manual conversia pe randuri ( a durat un pic )
        {
            DateTime azi = Time_Update();
            int hour = azi.Hour;
            int h2 = hour % 10;
            int minute = azi.Minute;
            int min2 = minute % 10;
            int second = azi.Second;
            int sec2 = second % 10;
            string H2S = "O";
            string M2S = "O";
            string S2S = "O";
            if (h2 > 7) H2S = "X";
            if (min2 > 7) M2S = "X";
            if (sec2 > 7) S2S = "X";
            Console.Write("\n|");
            for (int i = 1; i <= 35; i++)
            {               
                if (i == 8) Console.Write(H2S);
                else if (i == 20) Console.Write(M2S);
                else if (i == 32) Console.Write(S2S);
                else if (i % 4 == 0 && i % 3 == 0) Console.Write("|");
                else Console.Write(" ");
            }
            Console.Write("|");
        } 
        static void PrintRow2()
        {
            DateTime azi = Time_Update();
            int hour = azi.Hour;
            int h2 = hour % 10;
            int minute = azi.Minute;
            int min1 = minute / 10;
            int min2 = minute % 10;
            int second = azi.Second;
            int sec1 = second / 10;
            int sec2 = second % 10;
            string H2S = "O";
            string M2S = "O";
            string S2S = "O";
            string M1S = "O";
            string S1S = "O";
            if (h2 > 3 && h2 < 8) H2S = "X";
            if (min2 > 3 && min2 < 8) M2S = "X";
            if (min1 > 3) M1S = "X";
            if (sec2 > 3 && sec2 < 8) S2S = "X";
            if (sec1 > 3) S1S = "X";
            Console.Write("\n|");
            for (int i = 1; i <= 35; i++)
            {
                if (i == 8) Console.Write(H2S);
                else if (i == 16) Console.Write(M1S);
                else if (i == 20) Console.Write(M2S);
                else if (i == 28) Console.Write(S1S);
                else if (i == 32) Console.Write(S2S);
                else if (i % 4 == 0 && i % 3 == 0) Console.Write("|");
                else Console.Write(" ");
            }
            Console.Write("|");
        }
        static void PrintRow3()
        {
            DateTime azi = Time_Update();
            int hour = azi.Hour;
            int h1 = hour / 10;
            int h2 = hour % 10;
            int minute = azi.Minute;
            int min1 = minute / 10;
            int min2 = minute % 10;
            int second = azi.Second;
            int sec1 = second / 10;
            int sec2 = second % 10;
            string H2S = "O";
            string H1S = "O";
            string M2S = "O";
            string S2S = "O";
            string M1S = "O";
            string S1S = "O";
            if (h2 == 2 || h2 == 3 || h2 == 6 || h2 == 7) H2S = "X";
            if (h1 == 2 || h1 == 3 || h1 == 6 || h1 == 7) H1S = "X";
            if (min2 == 2 || min2 == 3 || min2 == 6 || min2 == 7) M2S = "X";
            if (min1 == 2 || min1 == 3 || min1 == 6 || min1 == 7) M1S = "X";
            if (sec2 == 2 || sec2 == 3 || sec2 == 6 || sec2 == 7) S2S = "X";
            if (sec1 == 2 || sec1 == 3 || sec1 == 6 || sec1 == 7) S1S = "X";
            Console.Write("\n|");
            for (int i = 1; i <= 35; i++)
            {
                if (i == 4) Console.Write(H1S);
                else if (i == 8) Console.Write(H2S);
                else if (i == 16) Console.Write(M1S);
                else if (i == 20) Console.Write(M2S);
                else if (i == 28) Console.Write(S1S);
                else if (i == 32) Console.Write(S2S);
                else if (i % 4 == 0 && i % 3 == 0) Console.Write("|");
                else Console.Write(" ");
            }
            Console.Write("|");
        }
        static void PrintRow4()
        {
            DateTime azi = Time_Update();
            int hour = azi.Hour;
            int h1 = hour / 10;
            int h2 = hour % 10;
            int minute = azi.Minute;
            int min1 = minute / 10;
            int min2 = minute % 10;
            int second = azi.Second;
            int sec1 = second / 10;
            int sec2 = second % 10;
            string H2S = "O";
            string H1S = "O";
            string M2S = "O";
            string S2S = "O";
            string M1S = "O";
            string S1S = "O";
            if (h2 % 2 != 0) H2S = "X";
            if (h1 == 1) H1S = "X";
            if (min2 % 2 != 0) M2S = "X";
            if (min1 % 2 != 0) M1S = "X";
            if (sec2 % 2 != 0) S2S = "X";
            if (sec1 % 2 != 0) S1S = "X";
            Console.Write("\n|");
            for (int i = 1; i <= 35; i++)
            {
                if (i == 4) Console.Write(H1S);
                else if (i == 8) Console.Write(H2S);
                else if (i == 16) Console.Write(M1S);
                else if (i == 20) Console.Write(M2S);
                else if (i == 28) Console.Write(S1S);
                else if (i == 32) Console.Write(S2S);
                else if (i % 4 == 0 && i % 3 == 0) Console.Write("|");
                else Console.Write(" ");
            }
            Console.Write("|");
        }
        static void PrintRowConvert()
        {
            DateTime azi = Time_Update();
            int hour = azi.Hour;
            int h1 = hour / 10;
            int h2 = hour % 10;
            int minute = azi.Minute;
            int min1 = minute / 10;
            int min2 = minute % 10;
            int second = azi.Second;
            int sec1 = second / 10;
            int sec2 = second % 10;
            Console.Write("\n|");
            for (int i = 1; i <= 35; i++)
            {
                if (i == 4) Console.Write(h1);
                else if (i == 8) Console.Write(h2);
                else if (i == 16) Console.Write(min1);
                else if (i == 20) Console.Write(min2);
                else if (i == 28) Console.Write(sec1);
                else if (i == 32) Console.Write(sec2);
                else if (i % 4 == 0 && i % 3 == 0) Console.Write("|");
                else Console.Write(" ");
            }
            Console.Write("|");
        }
    }
}
