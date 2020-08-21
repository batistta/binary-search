using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace busca_binaria
{
    class Program
    {
        public int cont = 0;
        static void Main(string[] args)
        {
            int qtd = 0;
            Produto[] vetProd;


            Console.WriteLine("Quantos itens deseja cadastrar?");
            qtd = int.Parse(Console.ReadLine());


            vetProd = new Produto[qtd];

            for (int i = 0; i < qtd; i++)
            {
                vetProd[i] = new Produto();
                Console.WriteLine("Codigo de barras do produto: ");
                vetProd[i].codBarras = int.Parse(Console.ReadLine());
                Console.WriteLine("Nome do produto:  ");
                vetProd[i].nome = Console.ReadLine();
                Console.WriteLine("Preco do produto: ");
                vetProd[i].preco = double.Parse(Console.ReadLine());
            }


            Console.WriteLine("Digite o codigo de barras a ser pesquisado: ");
            int codigoPesquisa = int.Parse(Console.ReadLine());
            int contador = 0;

            int resultadoPesquisa = PesquisaBin(vetProd, codigoPesquisa, ref contador);

            Console.WriteLine("PESQUISA BINARIA");

            if (resultadoPesquisa == -1)
            {
                Console.WriteLine("Produto nao encontrado");
                Console.WriteLine("Numero de comparacoes: " + contador);
            }
            else
            {
                Console.WriteLine("Nome do Produto: " + vetProd[resultadoPesquisa].nome);
                Console.WriteLine("Preco do produto: " + vetProd[resultadoPesquisa].preco);
                Console.WriteLine("Numero de comparacoes: " + contador);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("PESQUISA SEQUENCIAL");

            int contadorSeq = 0;
            int resultadoSequencial = PesquisaSeq(vetProd, codigoPesquisa, ref contadorSeq);

            if (resultadoPesquisa == -1)
            {
                Console.WriteLine("Produto nao encontrado");
                Console.WriteLine("Numero de comparacoes: " + contadorSeq);
            }
            else
            {
                Console.WriteLine("Nome do Produto: " + vetProd[resultadoSequencial].nome);
                Console.WriteLine("Preco do produto: " + vetProd[resultadoSequencial].preco);
                Console.WriteLine("Numero de comparacoes: " + contadorSeq);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("PESQUISA BINARIA RECURSIVA");

            int contadorRec = 0;
            int resultadoRec = PesquisaBinRec(vetProd, codigoPesquisa, 0, vetProd.Length - 1, ref contadorRec);

            if (resultadoPesquisa == -1)
            {
                Console.WriteLine("Produto nao encontrado");
                Console.WriteLine("Numero de comparacoes: " + contadorRec);
            }
            else
            {
                Console.WriteLine("Nome do Produto: " + vetProd[resultadoRec].nome);
                Console.WriteLine("Preco do produto: " + vetProd[resultadoRec].preco);
                Console.WriteLine("Numero de comparacoes: " + contadorRec);
            }

            Console.ReadKey();

        }
        public static int PesquisaBin(Produto[] v, int x, ref int contador)
        {
            int meio;
            int inicio = 0;
            int fim = v.Length - 1;

            do
            {
                contador++;
                meio = (int)(inicio + fim) / 2;
                if (v[meio].codBarras == x)
                {
                    return meio;
                }
                else if (x > v[meio].codBarras)
                    inicio = meio + 1;
                else
                    fim = meio - 1;
            }
            while (inicio <= fim);

            return -1;
        }
        public static int PesquisaSeq(Produto[] v, int x, ref int contadorSequencial)
        {
            int resultado = 0;

            for (int i = 0; i < v.Length; i++)
            {
                contadorSequencial++;
                if (v[i].codBarras == x)
                {
                    resultado = i;
                    return resultado;
                }
            }


            return -1;
        }

        public static int PesquisaBinRec(Produto[] v, int x, int inicio, int fim, ref int contadorRec)
        {
            int meio = (inicio + fim) / 2;

            contadorRec++;

            if (v[meio].codBarras == x)
            {
                return meio;
            }

            else if (inicio > fim)
            {
                return -1;
            }

            else if (x > v[meio].codBarras)
            {
                return PesquisaBinRec(v, x, meio + 1, fim, ref contadorRec);
            }

            else
            {
                return PesquisaBinRec(v, x, inicio, meio - 1, ref contadorRec);
            }
        }

    }
}

