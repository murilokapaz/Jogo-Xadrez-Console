using System;
using ns.tabuleiro;
using ns.xadrez;
using XadrezConsole.Tabuleiro.Enums;
using XadrezConsole.Tabuleiro.Exceptions;

namespace xadrez_console {
    class Program {
        static void Main(string[] args) {

            try {
                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.Terminada) {

                    try {
                        Console.Clear();
                        Tela.imprimirPartida(partida);

                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Posicao origem = Tela.lerPosicaoXadrez().ToPosicao();
                        partida.validarPosicaoDeOrigem(origem);

                        bool[,] posicoesPossiveis = partida.Tab.Peca(origem).movimentosPossiveis();

                        Console.Clear();
                        Tela.imprimirTabuleiro(partida.Tab, posicoesPossiveis);

                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Posicao destino = Tela.lerPosicaoXadrez().ToPosicao();
                        partida.validarPosicaoDeDestino(origem, destino);

                        partida.realizaJogada(origem, destino);
                    }
                    catch (TabuleiroException e) {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }

            }
            catch (TabuleiroException e) {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
