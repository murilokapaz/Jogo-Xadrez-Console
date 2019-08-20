using System;
using System.Collections.Generic;
using System.Text;
using ns.tabuleiro;
using XadrezConsole.Tabuleiro.Enums;
using XadrezConsole.Tabuleiro.Exceptions;


namespace ns.xadrez {
    class PartidaDeXadrez {
        public Tabuleiro Tab { get; private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool Terminada { get; private set; }
        private HashSet<Peca> Pecas;
        private HashSet<Peca> Capturadas;
        public bool Xeque { get; private set; }

        public PartidaDeXadrez() {
            Xeque = false;
            Tab = new Tabuleiro(8, 8);
            Turno = 1;
            Terminada = false;
            JogadorAtual = Cor.Branca;
            Pecas = new HashSet<Peca>();
            Capturadas = new HashSet<Peca>();
            colocarPecas();

        }


        public Peca executaMovimento(Posicao origem, Posicao destino) {
            Peca p = Tab.RetirarPeca(origem);
            p.incrementarQteMovimentos();
            Peca pecaCapturada = Tab.RetirarPeca(destino);
            Tab.ColocarPeca(p, destino);
            if (pecaCapturada != null) {
                Capturadas.Add(pecaCapturada);
            }
            return pecaCapturada;
        }

        public void desfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada) {
            Peca p = Tab.RetirarPeca(destino);
            p.decrementarQteMovimentos();
            if (pecaCapturada != null) {
                Tab.ColocarPeca(pecaCapturada, destino);
                Capturadas.Remove(pecaCapturada);
            }
            Tab.ColocarPeca(p, origem);
        }

        public void realizaJogada(Posicao origem, Posicao destino) {
            Peca pecaCapturada = executaMovimento(origem, destino);

            if (estaEmXeque(JogadorAtual)) {
                desfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Você não pode se colocar em xeque!");
            }

            if (estaEmXeque(adversaria(JogadorAtual))) {
                Xeque = true;
            }
            else {
                Xeque = false;
            }

            Turno++;
            mudaJogador();
        }

        public void validarPosicaoDeOrigem(Posicao pos) {
            if (Tab.Peca(pos) == null) {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida!");
            }
            if (JogadorAtual != Tab.Peca(pos).cor) {
                throw new TabuleiroException("A peça de origem escolhida não é sua!");
            }
            if (!Tab.Peca(pos).existeMovimentosPossiveis()) {
                throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida!");
            }
        }

        public void validarPosicaoDeDestino(Posicao origem, Posicao destino) {
            if (!Tab.Peca(origem).podeMoverPara(destino)) {
                throw new TabuleiroException("Posição de destino inválida!");
            }
        }

        private void mudaJogador() {
            if (JogadorAtual == Cor.Branca) {
                JogadorAtual = Cor.Preta;
            }
            else {
                JogadorAtual = Cor.Branca;
            }
        }

        public HashSet<Peca> pecasCapturadas(Cor cor) {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in Capturadas) {
                if (x.cor == cor) {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Peca> pecasEmJogo(Cor cor) {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in Pecas) {
                if (x.cor == cor) {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(pecasCapturadas(cor));
            return aux;
        }

        private Cor adversaria(Cor cor) {
            if (cor == Cor.Branca) {
                return Cor.Preta;
            }
            else {
                return Cor.Branca;
            }
        }

        private Peca rei(Cor cor) {
            foreach (Peca x in pecasEmJogo(cor)) {
                if (x is Rei) {
                    return x;
                }
            }
            return null;
        }

        public bool estaEmXeque(Cor cor) {
            Peca R = rei(cor);
            if (R == null) {
                throw new TabuleiroException("Não tem rei da cor " + cor + " no tabuleiro!");
            }
            foreach (Peca x in pecasEmJogo(adversaria(cor))) {
                bool[,] mat = x.movimentosPossiveis();
                if (mat[R.posicao.linha, R.posicao.coluna]) {
                    return true;
                }
            }
            return false;
        }

        public bool TesteXequemate(Cor cor) {
            if (!estaEmXeque(cor)) {
                return false;
            }
            foreach (Peca x in pecasEmJogo(cor)) {
                bool[,] mat = x.movimentosPossiveis();
                for (int i = 0; i < Tab.Linhas; i++) {
                    for (int j = 0; j < Tab.Colunas; j++) {
                        if (mat[i, j]) {
                            Peca pecaCapturada = executaMovimento(x.posicao, new Posicao(i, j));
                            bool testeXeque = estaEmXeque(cor);
                            desfazMovimento(x.posicao, destino, pecaCapturada);
                            if (!testeXeque) {
                                return false;
                            }
                        }
                    }
                }
            }
        }
            public void colocarNovaPeca(char coluna, int linha, Peca peca) {
                Tab.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
                Pecas.Add(peca);
            }

            private void colocarPecas() {
                colocarNovaPeca('c', 1, new Torre(Tab, Cor.Branca));
                colocarNovaPeca('c', 2, new Torre(Tab, Cor.Branca));
                colocarNovaPeca('d', 2, new Torre(Tab, Cor.Branca));
                colocarNovaPeca('e', 2, new Torre(Tab, Cor.Branca));
                colocarNovaPeca('e', 1, new Torre(Tab, Cor.Branca));
                colocarNovaPeca('d', 1, new Rei(Tab, Cor.Branca));

                colocarNovaPeca('c', 7, new Torre(Tab, Cor.Preta));
                colocarNovaPeca('c', 8, new Torre(Tab, Cor.Preta));
                colocarNovaPeca('d', 7, new Torre(Tab, Cor.Preta));
                colocarNovaPeca('e', 7, new Torre(Tab, Cor.Preta));
                colocarNovaPeca('e', 8, new Torre(Tab, Cor.Preta));
                colocarNovaPeca('d', 8, new Rei(Tab, Cor.Preta));
            }

        }
    }
