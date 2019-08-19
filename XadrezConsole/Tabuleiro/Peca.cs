using XadrezConsole.Tabuleiro.Enums;
namespace ns.tabuleiro {
    abstract class Peca {

        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int qteMovimentos { get; protected set; }
        public Tabuleiro tab { get; protected set; }

        public Peca(Tabuleiro tab, Cor cor) {
            this.posicao = null;
            this.tab = tab;
            this.cor = cor;
            this.qteMovimentos = 0;
        }

        public void IncrementarQtMovimentos() {
            qteMovimentos++;
        }
        public bool ExisteMovimentosPossiveis() {
            bool[,] mat = MovimentosPossiveis();
            for (int i = 0; i < tab.Linhas; i++) {
                for (int j = 0; j < tab.Colunas; j++) {
                    if (mat[i, j]) return true;
                }
            }
            return false;
        }

        public abstract bool[,] MovimentosPossiveis();
    }
}