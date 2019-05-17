using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problema_mochila.pgm
{
    class Mochila : ICloneable
    {

        # region propriedades
        public int Capacidade { get; set; }
        public int PesoAtual { get; private set; }
        public List<Item> Itens { get; private set; }

        public int Valor
        {
            get
            {
                return this.Itens.Sum(item => item.Valor);
            }
        }
        # endregion

        public Mochila(int capacidade)
        {
            this.Itens = new List<Item>();
            this.Capacidade = capacidade;
            this.PesoAtual = 0;
        }

        public void AddItem(Item item)
        {
            if (this.Cabe(item))
            {
                this.Itens.Add(item);
                this.PesoAtual += item.Peso;
            }
            else
            {
                throw new ArgumentException("Item não cabe na mochila.");
            }
        }

        public bool Cabe(Item item)
        {
            return item.Peso <= (this.Capacidade - this.PesoAtual);
        }

        public override string ToString()
        {
            StringBuilder st = new StringBuilder();

            st.Append("Mochila: \n");
            st.Append("Capacidade: ");
            st.Append(this.Capacidade.ToString());
            st.Append("\n");

            st.Append("\t[");

            for (int i = 0; i < this.Itens.Count; i++)
            {

                if (i != 0)
                {
                    st.Append("\t");
                }
              
                st.Append(this.Itens[i].ToString());

                if (i < this.Itens.Count - 1)
                {
                    st.Append(",");
                    st.Append("\n");
                }

            }
            
            st.Append("]");
            st.Append("\n");
            st.Append("Valor: ");
            st.Append(this.Valor.ToString());
            st.Append("\n");
            st.Append("Peso atual: ");
            st.Append(this.PesoAtual.ToString());
            st.Append("\n");

            return st.ToString();
        }

        public object Clone()
        {
            Mochila mochila = new Mochila(this.Capacidade);

            foreach (Item item in this.Itens)
            {
                mochila.AddItem(item);
            }

            return mochila;
        }
    }
}
