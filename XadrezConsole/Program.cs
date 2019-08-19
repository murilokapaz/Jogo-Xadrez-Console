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
                while(!partida.Terminada){
                    try {
                        Console.Clear();
                        Tela.imprimirTabuleiro(partida.Tab);
                        Console.WriteLine();
                        Console.WriteLine($"Turno da partida: {partida.Turno}");
                        Console.WriteLine($"Aguardando Jogada: {partida.JogadorAtual}");
                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();
                        partida.ValidarPosicaoOrigem(origem);
                        bool[,] posicoesPossiveis = partida.Tab.Peca(origem).MovimentosPossiveis();
                        Console.Clear();

                        Tela.imprimirTabuleiro(partida.Tab, posicoesPossiveis);
                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();

                        partida.RealizaJogada(origem, destino);
                    }
                    catch (TabuleiroException e) {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }

                }
                Tela.imprimirTabuleiro(partida.Tab);
            }
            catch(TabuleiroException e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}
