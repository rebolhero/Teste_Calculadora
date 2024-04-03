using System;
using System.Collections;
using System.Collections.Generic;

namespace Calculadora
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<Operacoes> filaOperacoes = new Queue<Operacoes>();
            filaOperacoes.Enqueue(new Operacoes { valorA = 2, valorB = 3, operador = '+' });
            filaOperacoes.Enqueue(new Operacoes { valorA = 14, valorB = 8, operador = '-' });
            filaOperacoes.Enqueue(new Operacoes { valorA = 5, valorB = 6, operador = '*' });
            filaOperacoes.Enqueue(new Operacoes { valorA = 2147483647, valorB = 2, operador = '+' });
            filaOperacoes.Enqueue(new Operacoes { valorA = 18, valorB = 3, operador = '/' }); 

            Calculadora calculadora = new Calculadora();
            Stack<string> resultados = new Stack<string>();

            var i = 1;

            while (filaOperacoes.Count > 0)
            {
                
                Console.WriteLine("Cálculo " + i + ":");
                Operacoes operacao = filaOperacoes.Dequeue();
                operacao = calculadora.calcular(operacao);
                resultados.Push("Resultado do calculo " + i + ": " + operacao.resultado);
                Console.WriteLine("{0} {1} {2} = {3}", operacao.valorA, operacao.operador, operacao.valorB, operacao.resultado);
                Console.WriteLine("\n");

                // Imprime todas as operações pendentes
                if(filaOperacoes.Count > 0)
                {
                    Console.WriteLine("Operações pendentes:");
                    foreach (Operacoes op in filaOperacoes)
                    {
                        Console.WriteLine("{0} {1} {2}", op.valorA, op.operador, op.valorB);
                    }
                    Console.WriteLine("\n-----------------------------------------");
                }

                i++;
            }
            
            // Ordena os resultados para aparecer na ordem
            List<string> lista = new List<string>(resultados);
            lista.Sort((x, y) => y.CompareTo(x));
            resultados = new Stack<string>(lista);


            Console.WriteLine("\n==========================================");

            // Mostra os Resultados
            Console.WriteLine("Resultados dos cálculos:");
            foreach (var resultado in resultados)
            {
                Console.WriteLine(resultado);
            }
        }
    }
}
