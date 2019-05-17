using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problema_mochila.pgm
{
    class Item
    {
        public int Valor { get; private set; }
        public int Peso { get; private set; }

        public Item(int valor, int peso)
        {
            this.Valor = valor;
            this.Peso = peso;
        }

        public override string ToString()
        {
            StringBuilder st = new StringBuilder();
            
            st.Append("(");
            st.Append(this.Peso.ToString());
            st.Append(" / ");
            st.Append(this.Valor.ToString());
            st.Append(")");

            return st.ToString(); 
        }

    }
}
