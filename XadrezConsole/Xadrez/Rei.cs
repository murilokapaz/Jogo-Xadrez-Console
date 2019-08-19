using ns.tabuleiro;
using XadrezConsole.Tabuleiro.Enums;

namespace ns.xadrez {
    class Rei : Peca {

        public Rei(Tabuleiro tab, Cor cor) : base(tab, cor) {
        }
        private bool PodeMover(Posicao pos) {
            Peca p = tab.Peca(pos);
            return p == null || p.cor != this.cor;
        }


        public override bool[,] MovimentosPossiveis() {
            bool[,] mat = new bool[tab.Linhas, tab.Colunas];
            Posicao pos = new Posicao(0, 0);

            //movimento acima
            pos.DefinirValores(posicao.linha - 1, posicao.coluna);
            if(tab.PosicaoValida(pos)&& PodeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            //N.E.
            pos.DefinirValores(posicao.linha - 1, posicao.coluna+1);
            if (tab.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            //Direita
            pos.DefinirValores(posicao.linha, posicao.coluna+1);
            if (tab.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            //S.E.
            pos.DefinirValores(posicao.linha + 1, posicao.coluna+1);
            if (tab.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            //abaixo
            pos.DefinirValores(posicao.linha + 1, posicao.coluna);
            if (tab.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            //S.O
            pos.DefinirValores(posicao.linha + 1, posicao.coluna-1);
            if (tab.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            //esquerda
            pos.DefinirValores(posicao.linha, posicao.coluna-1);
            if (tab.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            //N.O.
            pos.DefinirValores(posicao.linha - 1, posicao.coluna-1);
            if (tab.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            return mat;
        }
        public override string ToString() {
            return "R";
        }
    }
}
