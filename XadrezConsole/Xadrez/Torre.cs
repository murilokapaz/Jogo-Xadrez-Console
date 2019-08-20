using ns.tabuleiro;
using XadrezConsole.Tabuleiro.Enums;

namespace ns.xadrez {
    class Torre : Peca {

        public Torre(Tabuleiro tab, Cor cor) : base(tab, cor) {
        }
        private bool PodeMover(Posicao pos) {
            Peca p = tab.Peca(pos);
            return p == null || p.cor != this.cor;
        }
        public override bool[,] movimentosPossiveis() {
            bool[,] mat = new bool[tab.Linhas, tab.Colunas];
            Posicao pos = new Posicao(0, 0);

            //acima
            pos.DefinirValores(posicao.linha - 1, posicao.coluna);
            while(tab.PosicaoValida(pos)&& PodeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
                if(tab.Peca(pos) != null && tab.Peca(pos).cor != cor) {
                    break;
                }
                pos.linha = pos.linha - 1;
            }
            //abaixo
            pos.DefinirValores(posicao.linha + 1, posicao.coluna);
            while (tab.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
                if (tab.Peca(pos) != null && tab.Peca(pos).cor != cor) {
                    break;
                }
                pos.linha = pos.linha + 1;
            }
            //direita
            pos.DefinirValores(posicao.linha , posicao.coluna+1);
            while (tab.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
                if (tab.Peca(pos) != null && tab.Peca(pos).cor != cor) {
                    break;
                }
                pos.coluna = pos.coluna + 1;
            }
            //esquerda
            pos.DefinirValores(posicao.linha, posicao.coluna-1);
            while (tab.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
                if (tab.Peca(pos) != null && tab.Peca(pos).cor != cor) {
                    break;
                }
                pos.coluna = pos.coluna - 1;
            }
            return mat;
        }

        public override string ToString() {
            return "T";
        }
    }
}
