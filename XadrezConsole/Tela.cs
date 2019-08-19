using System;
using ns.tabuleiro;
using XadrezConsole.Tabuleiro.Enums;
using ns.xadrez;

namespace xadrez_console {
    class Tela {

        public static void imprimirTabuleiro(Tabuleiro tab) {

            for (int i = 0; i < tab.Linhas; i++) {
                Console.Write($"{8-i} ");
                for (int j = 0; j < tab.Colunas; j++) {
                    ImprimirPeca(tab.Peca(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }
        public static void imprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis) {
            ConsoleColor fundoOriginal = Console.BackgroundColor;//pega padrão fundo preto
            ConsoleColor fundoAlterado = ConsoleColor.DarkBlue;

            for (int i = 0; i < tab.Linhas; i++) {
                Console.Write($"{8 - i} ");
                for (int j = 0; j < tab.Colunas; j++) {
                    if (posicoesPossiveis[i, j]) {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else {
                        Console.BackgroundColor = fundoOriginal;
                    }
                    ImprimirPeca(tab.Peca(i, j));
                    Console.BackgroundColor = fundoOriginal;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = fundoOriginal;
        }
        public static void ImprimirPeca(Peca peca) {
            if(peca == null) {
                Console.Write("- ");
            }
            else {
                if (peca.cor == Cor.Branca) {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                }
                else {
                    ConsoleColor aux = Console.ForegroundColor;//cor padrão
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;

                }
                Console.Write(" ");
            }



        }
        public static PosicaoXadrez LerPosicaoXadrez() {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna, linha);
        }

    }
}
