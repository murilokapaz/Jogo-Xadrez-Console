﻿using System;
using ns.tabuleiro;
using ns.xadrez;
using XadrezConsole.Tabuleiro.Enums;
using XadrezConsole.Tabuleiro.Exceptions;


namespace xadrez_console {
    class Program {
        static void Main(string[] args) {
            try {
                Tabuleiro tab = new Tabuleiro(8, 8);

                tab.ColocarPeca(new Torre(tab, Cor.Preta), new Posicao(0, 0));
                tab.ColocarPeca(new Torre(tab, Cor.Preta), new Posicao(1, 3));
                tab.ColocarPeca(new Rei(tab, Cor.Preta), new Posicao(2, 4));


                Tela.imprimirTabuleiro(tab);

                Console.ReadLine();
            }
            catch(TabuleiroException e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}
