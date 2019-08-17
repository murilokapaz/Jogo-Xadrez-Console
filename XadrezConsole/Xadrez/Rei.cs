using ns.tabuleiro;
using XadrezConsole.Tabuleiro.Enums;

namespace ns.xadrez {
    class Rei : Peca {

        public Rei(Tabuleiro tab, Cor cor) : base(tab, cor) {
        }

        public override string ToString() {
            return "R";
        }
    }
}
