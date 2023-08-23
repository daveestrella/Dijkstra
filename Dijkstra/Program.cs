using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra
{
    class Program
    {
        private static int DistanciaMinima(int[] dist, bool[] ArbolMasCorto, int numvertices) //Funcion que devuelve el indice del camino mas corto
        {
            int min = int.MaxValue;
            int minIndex = 0;

            for (int v = 0; v < numvertices; ++v)
            {
                if (ArbolMasCorto[v] == false && dist[v] <= min)
                {
                    min = dist[v];
                    minIndex = v;
                }
            }

            return minIndex;
        }

        private static void Imprimir(int[] distancia, int numvertices) //Funcion que imprime una lista de vertices y la distancia total desde el origen
        {
            Console.WriteLine("Vertice    Distancia desde el origen");

            for (int i = 0; i < numvertices; ++i)
                Console.WriteLine("{0}\t  {1}", i, distancia[i]);
        }

        public static void Dijkstra(int[,] graph, int partida, int numvertices) //Funcion que implementa el algoritmo de Dijkstra
        {
            int[] distancia = new int[numvertices];
            bool[] ArbolMasCorto = new bool[numvertices];

            for (int i = 0; i < numvertices; ++i)
            {
                distancia[i] = int.MaxValue;
                ArbolMasCorto[i] = false;
            }

            distancia[partida] = 0;

            for (int count = 0; count < numvertices - 1; ++count)
            {
                int x = DistanciaMinima(distancia, ArbolMasCorto, numvertices);
                ArbolMasCorto[x] = true;

                for (int j = 0; j < numvertices; ++j)
                    if (!ArbolMasCorto[j] && Convert.ToBoolean(graph[x, j]) && distancia[x] != int.MaxValue && distancia[x] + graph[x, j] < distancia[j])
                        distancia[j] = distancia[x] + graph[x, j];
            }

            Imprimir(distancia, numvertices);
        }


        static void Main(string[] args)
        {
            int[,] prueba =  {
                         { 0, 6, 0, 0, 0, 0, 0, 9, 0 },
                         { 6, 0, 9, 0, 0, 0, 0, 11, 0 },
                         { 0, 9, 0, 5, 0, 6, 0, 0, 2 },
                         { 0, 0, 5, 0, 9, 16, 0, 0, 0 },
                         { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
                         { 0, 0, 6, 0, 10, 0, 2, 0, 0 },
                         { 0, 0, 0, 16, 0, 2, 0, 1, 6 },
                         { 9, 11, 0, 0, 0, 0, 1, 0, 5 },
                         { 0, 0, 2, 0, 0, 0, 6, 5, 0 } }; //Matriz de prueba

            int[,] Matriz; //matriz que almacena la matriz ingresada por el usuario y tambien la respuesta
            int i, j, x;
            int partida;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Cuántos vértices?: ");
            x = int.Parse(Console.ReadLine());
            Matriz = new int[x, x];

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Ingrese los valores: ");

            for (i = 0; i < Matriz.GetLength(0); i++)  //Se llena la matriz con datos ingresados por el usuario
                for (j = 0; j < Matriz.GetLength(1); j++)
                {
                    Console.Write("[{0},{1}]---> ", i, j);
                    Matriz[i, j] = int.Parse(Console.ReadLine());
                }

            Console.WriteLine();
            Console.Write("Desde qué vértice parte?: ");
            partida = int.Parse(Console.ReadLine());

            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Dijkstra(Matriz,partida,x); //Se llama a la funcion Dijkstra para que devuelva la respuesta

            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.ReadKey();
        }
    }
}
