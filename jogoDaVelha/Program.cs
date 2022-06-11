using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jogoDaVelha
{
    internal class Program
    {
        static string VaiJogarXouO(int contador)
        {
            if (contador % 2 == 0)
            {
                return "X";
            }
            else
            {
                return "O";
            }
        }
        public static void MostrarTabuleiro(string[,] tabuleiro)
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("+---+---+---+");

                for (int j = 0; j < 3; j++)
                {
                    if (j == 2)
                    {
                        Console.Write($"|  {tabuleiro[i, j]}|");
                    }
                    else
                    {
                        Console.Write($"|  {tabuleiro[i, j]}");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("+---+---+---+");
        }
        public static void Jogando(string[,] tabuleiro, string XouO, string escolha)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (tabuleiro[i,j] == escolha)
                    {
                        tabuleiro[i, j] = XouO;
                    }
                }
            }
        }
        static int OcupadoOuNao(string[,] tabuleiro, string[,] verificarTabuleiro, string escolha)
        {
            int invalido = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if ((tabuleiro[i, j] == "X" || tabuleiro[i, j] == "O") && escolha == verificarTabuleiro[i, j])
                    {
                        invalido = 0;

                    }
                    else if ((tabuleiro[i, j] != "X" || tabuleiro[i, j] != "O") && escolha == verificarTabuleiro[i, j])
                    {
                        invalido = 1;

                    }
                }
            }
            if (invalido == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        static string QuemGanhaOuVelha(string[,] tabuleiro)
        {
            if (tabuleiro[0,0] == "X" && tabuleiro[0,1] == "X" && tabuleiro[0,2] == "X" )
            {
                return "X";
            }
            else if (tabuleiro[1, 0] == "X" && tabuleiro[1, 1] == "X" && tabuleiro[1, 2] == "X")
            {
                return "X";
            }
            else if (tabuleiro[2, 0] == "X" && tabuleiro[2, 1] == "X" && tabuleiro[2, 2] == "X")
            {
                return "X";
            }
            else if (tabuleiro[0, 0] == "X" && tabuleiro[1, 0] == "X" && tabuleiro[2, 0] == "X")
            {
                return "X";
            }
            else if (tabuleiro[0, 1] == "X" && tabuleiro[1, 1] == "X" && tabuleiro[2, 1] == "X")
            {
                return "X";
            }
            else if (tabuleiro[0, 2] == "X" && tabuleiro[1, 2] == "X" && tabuleiro[2, 2] == "X")
            {
                return "X";
            }
            else if (tabuleiro[0, 0] == "X" && tabuleiro[1, 1] == "X" && tabuleiro[2, 2] == "X")
            {
                return "X";
            }
            else if (tabuleiro[0, 2] == "X" && tabuleiro[1, 1] == "X" && tabuleiro[2, 0] == "X")
            {
                return "X";
            }
            else if (tabuleiro[0, 0] == "O" && tabuleiro[0, 1] == "O" && tabuleiro[0, 2] == "O")
            {
                return "O";
            }
            else if (tabuleiro[1, 0] == "O" && tabuleiro[1, 1] == "O" && tabuleiro[1, 2] == "O")
            {
                return "O";
            }
            else if (tabuleiro[2, 0] == "O" && tabuleiro[2, 1] == "O" && tabuleiro[2, 2] == "O")
            {
                return "O";
            }
            else if (tabuleiro[0, 0] == "O" && tabuleiro[1, 0] == "O" && tabuleiro[2, 0] == "O")
            {
                return "O";
            }
            else if (tabuleiro[0, 1] == "O" && tabuleiro[1, 1] == "O" && tabuleiro[2, 1] == "O")
            {
                return "O";
            }
            else if (tabuleiro[0, 2] == "O" && tabuleiro[1, 2] == "O" && tabuleiro[2, 2] == "O")
            {
                return "O";
            }
            else if (tabuleiro[0, 0] == "O" && tabuleiro[1, 1] == "O" && tabuleiro[2, 2] == "O")
            {
                return "O";
            }
            else if (tabuleiro[0, 2] == "O" && tabuleiro[1, 1] == "O" && tabuleiro[2, 0] == "O")
            {
                return "O";
            }
            else
            {
                return "VELHA";
            }
        }
        public static void FinalDaPartida(string fimDeJogo)
        {
            Console.WriteLine("JOGO FINALIZADO!!!");

            if (fimDeJogo == "VELHA")
            {
                Console.WriteLine("Ninquem ganhou o jogo deu VELHA!");
            }
            else if (fimDeJogo == "O")
            {
                Console.WriteLine("O jogador de O ganhou");
            }
            else
            {
                Console.WriteLine("O jogador de X ganhou");
            }
        }
        static void Main(string[] args)
        {
            string[,] tabuleiro = new string[3, 3];
            string[,] verificarTabuleiro = new string[3, 3];
            int contador = 1;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    tabuleiro[i, j] = contador.ToString();
                    verificarTabuleiro[i, j] = contador.ToString();
                    contador++;
                }
            }

            contador = 0;
            string fimDeJogo;

            do
            {
                MostrarTabuleiro(tabuleiro);
                string XouO = VaiJogarXouO(contador);

                Console.Write($"Vai jogar [{XouO}] em qual posicao? ");
                string escolha = Console.ReadLine();

                int invalido = 1;

                do
                {

                    invalido = OcupadoOuNao(tabuleiro, verificarTabuleiro, escolha);

                    if (invalido == 0)
                    {
                        Console.WriteLine("JOGADA INVALIDA!");
                        Console.WriteLine($"O numero {escolha} já foi escolhido");

                        Console.Write($"Vai jogar [{XouO}] em qual posicao? ");
                        escolha = Console.ReadLine();
                    }

                } while (invalido == 0);

                Jogando(tabuleiro, XouO, escolha);
                contador++;

                fimDeJogo = QuemGanhaOuVelha(tabuleiro);
                Console.Clear();

            } while (fimDeJogo == "VELHA" && contador < 9);

            MostrarTabuleiro(tabuleiro);
            Console.WriteLine();
            FinalDaPartida(fimDeJogo);

            Console.ReadKey();
        }
    }
}
