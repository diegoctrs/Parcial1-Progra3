using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arbolSQL.ArbolBinario
{
    class ArbolBinario
    {
        protected Nodo raiz;

        public ArbolBinario()
        {
            raiz = null;
        }

        public ArbolBinario(Nodo ValorRaiz)
        {
            this.raiz = ValorRaiz;
        }

        public Nodo raizArbol()
        {
            return raiz;
        }

        //bool esVacio()
        //{
        //    return raiz = null;
        //}

        public static Nodo nuevoArbol(Nodo ramaIzqda, object dato, Nodo ramaDrcha)
        {
            return new Nodo(ramaIzqda, dato, ramaDrcha);
        }
    }
}
