using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDeMaths
{
    class Program
    {
        enum e_Operateur
        {
            ADDITION = 1,
            SOUSTRACTION = 2,
            MULTIPLICATION = 3
        }

        static bool PoserQuestion(int min, int max)
        {
            int response = 0;
            int resultatAttendue;
            Random rand = new Random();
            int a = rand.Next(min, max + 1);
            int b = rand.Next(min, max + 1);
            e_Operateur opera = (e_Operateur)rand.Next(1, 4);

            while (true)
            {
                switch (opera)
                {
                    case e_Operateur.ADDITION:
                        Console.Write($" {a} + {b} = ");
                        resultatAttendue = a + b;
                        break;
                    case e_Operateur.SOUSTRACTION:
                        Console.Write($" {a} - {b} = ");
                        resultatAttendue = a - b;
                        break;
                    case e_Operateur.MULTIPLICATION:
                        Console.Write($" {a} x {b} = ");
                        resultatAttendue = a * b;
                        break;
                    default:
                        Console.Write("ERREUR : Opérateur inconnu");
                        return false;
                }
                string input = Console.ReadLine();

                try
                {
                    response = int.Parse(input);
                    break;
                }
                catch
                {
                    Console.WriteLine("ERREUR entrer un nombre ");
                }
            }

            if(resultatAttendue == response)
            {
                return true;
            }
            return false;
        }

        static void AttribMention(int point, int question)
        {
            int moy = question / 2;
            if (point == question)
            {
                Console.WriteLine("Excellent !");
            }
            else if (point == 0)
            {
                Console.WriteLine("Révisez vos maths !");
            }
            else if (moy < point)
            {
                Console.WriteLine("Pas mal ");
            }
            else
            {
                Console.WriteLine("Peut mieux faire ");
            }
        }
        static void Main(string[] args)
        {
            const int NOMBRE_MIN = 1;
            const int NOMBRE_MAX = 10;
            const int NB_QUESTIONS = 5;
            int points = 0;

            for(int i = 0; i < NB_QUESTIONS; i++)
            {
                Console.WriteLine(" QUESTIONS N° " + (i + 1) + "/" + NB_QUESTIONS);
                bool response = PoserQuestion(NOMBRE_MIN, NOMBRE_MAX);
                if (response)
                {
                    Console.WriteLine(" Bonne reponse ");
                    points++;
                }
                else
                {
                    Console.WriteLine(" Mauvaise reponse ");
                }

                Console.WriteLine("********************");
            }

            Console.WriteLine("Nombre de points : " + points + "/" + NB_QUESTIONS);
            AttribMention(points, NB_QUESTIONS);
            Console.ReadKey();
        }
    }
}
