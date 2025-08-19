using System;

namespace PickNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string nochmal;
            int bestVersuche = int.MaxValue;

            do
            {
                int maxZahl = 100;

                Console.WriteLine("Wähle Schwierigkeitsgrad: (l = leicht, m = mittel, s = schwer)");
                string level = Console.ReadLine();

                if (level == "l")
                {
                    maxZahl = 50;
                }
                else if (level == "m")
                {
                    maxZahl = 100;
                }
                else if (level == "s")
                {
                    maxZahl = 500;
                }
                else
                {
                    Console.WriteLine("Ungültige Eingabe. Standart (mittel) wird verwendet");
                    maxZahl = 100;
                }

                Random random = new Random();
                int geheimZahl = random.Next(1, maxZahl + 1);
                //int geheimZahl = random.Next(1, 101);

                int versuch = 0;
                int benutzereingabe = 0;

                Console.WriteLine($"Ich habe mir eine Zahl zwischen 1 und {maxZahl} ausgedacht.");
                Console.WriteLine("Kannst du sie erraten?");

                while (benutzereingabe != geheimZahl && versuch < 10)
                {
                    Console.Write("Dein Tipp: ");
                    string input = Console.ReadLine();

                    try
                    {
                        benutzereingabe = int.Parse(input);
                        versuch++;

                        if (benutzereingabe < geheimZahl)
                        {
                            Console.WriteLine("Zu niedrig!");
                        }
                        else if (benutzereingabe > geheimZahl)
                        {
                            Console.WriteLine("Zu hoch !");
                        }
                       
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Nur ganze Zahlen sind erlaubt.");
                    }
                }

                if (benutzereingabe == geheimZahl)
                {
                    Console.WriteLine($"Richtig ! Die Zahl war {geheimZahl}.");
                    Console.WriteLine($"Du hast {versuch} Versuche gebraucht.");
                }
                else if (versuch >= 10)
                {
                    Console.WriteLine($"\nLeider verloren. Die Zahl war: {geheimZahl}");
                }


                Console.WriteLine("Spiel beendet.");

                if(benutzereingabe == geheimZahl && versuch < bestVersuche)
                {
                    bestVersuche = versuch;
                    Console.WriteLine("Neuer Highscore!");
                }


                Console.WriteLine("Nochmal spielen ? (j/n): ");
                nochmal = Console.ReadLine().ToLower();

                

            } while (nochmal == "j");

            
            
        }
    }
}
