using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace DescriptografarMensagem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string crip = "10010110 11110111 01010110 00000001 00010111 00100110 01010111 00000001" +
               " 00010111 01110110 01010111 00110110 11110111 11010111 01010111 00000011";

            string cripSemEspaco = RemoveEspaco(crip);

            int count = cripSemEspaco.Length / 8;

            string[] vetor = new string[count];
            string[] vetorDoisUltimosInvertidos = new string[count];
            string[] vetorQuatroInvertidos = new string[count];
            int[] valoresDecimais = new int[count];
            string mensagemDescriptografada = "";

            int indiceVetor = 0;
            for (int i = 0; i < crip.Length; i += 8)
            {
                string num = "";
                for (int j = 0; j < 8 && (i + j) < cripSemEspaco.Length; j++)
                {
                    num += cripSemEspaco[j + i];
                }
                if (indiceVetor < vetor.Length)
                {
                    vetor[indiceVetor] = num;
                }
                indiceVetor++;
            }
            for(int i = 0; i < count; i++)
            {
                for (int j = 0;j < vetor[i].Length; j++)
                {
                    if (j == 6 && vetor[i][j] == '1') vetorDoisUltimosInvertidos[i] += "0";
                    else if (j == 6 && vetor[i][j] == '0' ) vetorDoisUltimosInvertidos[i] += "1";
                    else if (j == 7 && vetor[i][j] == '1') vetorDoisUltimosInvertidos[i] += "0";
                    else if (j == 7 && vetor[i][j] == '0') vetorDoisUltimosInvertidos[i] += "1";
                    else vetorDoisUltimosInvertidos[i] += vetor[i][j];
                }
            }
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < vetor[i].Length; j++)
                {
                    if (j + 4 < vetorDoisUltimosInvertidos[i].Length) vetorQuatroInvertidos[i] += vetorDoisUltimosInvertidos[i][j + 4];                    
                }
                for (int j = 0; j < vetor[i].Length; j++)
                {
                    if (j + 4 < vetorDoisUltimosInvertidos[i].Length) vetorQuatroInvertidos[i] += vetorDoisUltimosInvertidos[i][j];
                }
            }

            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < vetor[i].Length; j++)
                {
                    char digit = vetorQuatroInvertidos[i][j];
                    int numeric = digit - '0';
                    valoresDecimais[i] += numeric * Potencia(2, 7 - j);
                }
                mensagemDescriptografada += (char)valoresDecimais[i];
            }
            Console.WriteLine(mensagemDescriptografada);

        }

        static string RemoveEspaco(string crip)
        {
            string stringSemEspaco = "";
            for (int i = 0; i < crip.Length; i++)
            {
                if (crip[i] != ' ')
                {
                    stringSemEspaco += crip[i];
                }
            }
            return stringSemEspaco;
        }

       static int Potencia(int baseNumero, int expoente)
        {
            int result = 1;
            for (int i = 0; i < expoente; i++)
            {
                result *= baseNumero;
            }
            return result;
        }
    }
}