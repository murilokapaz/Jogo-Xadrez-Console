﻿using ns.tabuleiro;

namespace ns.xadrez {
    class PosicaoXadrez {
        public char Coluna { get; set; }
        public int Linha { get; set; }
        public PosicaoXadrez() {

        }

        public PosicaoXadrez(char coluna, int linha) {
            Coluna = coluna;
            Linha = linha;
        }

        public Posicao ToPosicao() {
            return new Posicao(8 - Linha, Coluna - 'a');
        }

        public override string ToString() {
            return "" +Linha+Coluna;

        }

    }
}
