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
                    if (tab.Peca(i, j) == null) {
                        Console.Write("- ");
                    }
                    else {
                        ImprimirPeca(tab.Peca(i, j));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");




        }
        public static void ImprimirPeca(Peca peca) {
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
        }
        public static PosicaoXadrez LerPosicaoXadrez() {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna, linha);
        }

    }
}
