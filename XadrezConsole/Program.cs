using System;
using ns.tabuleiro;
using ns.xadrez;
using XadrezConsole.Tabuleiro.Enums;
using XadrezConsole.Tabuleiro.Exceptions;

namespace xadrez_console {
    class Program {
        static void Main(string[] args) {
            PosicaoXadrez pos = new PosicaoXadrez('c', 7);
            Console.WriteLine(pos);
            Console.WriteLine();
            Console.WriteLine(pos.ToPosicao());

        }
    }
}
