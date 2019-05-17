using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problema_mochila.pgm
{
    class SolverProgramacaoDinamica : ISolver
    {
        private int[,] tabela;
        private int qtdLinhas;
        private int qtdColunas;
        private Mochila mochila;
        private List<Item> listaDeItens;

        public SolverProgramacaoDinamica(Mochila mochila, List<Item> listaDeItens)
        {
            this.mochila = mochila;
            this.listaDeItens = listaDeItens;
            this.qtdLinhas = listaDeItens.Count + 1;
            this.qtdColunas = mochila.Capacidade + 1;
            this.tabela = new int[this.qtdLinhas, this.qtdColunas];
        }

        public int Solucionar()
        {
            this.InicializaTabela();

            for (int i = 1; i < this.qtdLinhas; i++)
            {
                for (int j = 1; j < this.qtdColunas; j++)
                {
                    this.tabela[i, j] = this.listaDeItens[i - 1].Peso <= j ?
                                        Math.Max(ValorSemItem(i, j), ValorComItem(i, j)) :
                                        ValorSemItem(i, j);
                }
            }

            return this.tabela[this.qtdLinhas - 1, this.qtdColunas - 1];
        }

        private int ValorComItem(int indiceItem, int tamMachilaAtual)
        {
            Item item = this.listaDeItens[indiceItem - 1];
            return item.Valor + this.tabela[indiceItem - 1, tamMachilaAtual - item.Peso];
        }

        private int ValorSemItem(int indiceItem, int tamMochilaAtual)
        {
            return this.tabela[indiceItem - 1, tamMochilaAtual];
        }

        private void InicializaTabela()
        {
            for (int i = 0; i < this.qtdColunas; i++)
            {
                this.tabela[0, i] = 0;
            }

            for (int i = 0; i < this.qtdLinhas; i++)
            {
                this.tabela[i, 0] = 0;
            }
        }
    }
}
