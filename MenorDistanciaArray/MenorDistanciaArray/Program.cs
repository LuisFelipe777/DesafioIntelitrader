using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenorDistanciaArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array1 = new int[] {-5, -13, 33, -5, 41, -21, 22, 25, 47, 11 };
            int[] array2 = new int[] { 6, 2, -23, -2, 48, -44, -19, 40, 34, 28 };
            int distancia = array1[0] - array2[0];
            string resposta = "";

            for (int i = 0; i < array1.Length; i++)
            {

                for (int j = 0; j < array2.Length; j++)
                {
                    int count = InverteSinal(array1[i] - array2[j]);
                    distancia = InverteSinal(distancia);
                    if (distancia > count)
                    {
                        distancia = count;
                        resposta = $"A menor distancia é {distancia}, dos numeros {array1[i]} e {array2[j]}";
                    }

                    distancia = InverteSinal(distancia);
                }

            }
            Console.WriteLine(resposta);

        }
        static int InverteSinal(int num)
        {
            if (num < 0) return num * -1;
            else return num;
        }
    }
}
