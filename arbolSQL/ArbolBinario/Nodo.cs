using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arbolSQL.ArbolBinario
{
    class Nodo
    {
        public object dato;
        public Nodo izquierda;
        public Nodo derecha;

        public Nodo(object valor)
        {
            dato = valor;
            izquierda = null;
            derecha = null;

        }

        public Nodo(Nodo ramaIzquierda, object valor, Nodo ramaDerecha)
        {
            dato = valor;
            izquierda = ramaIzquierda;
            derecha = ramaDerecha;
        }

        public void visitar()
        {
            Console.WriteLine(dato + "<->");


        }

        public object valorNodo()
        {
            return dato;
        }

        public Nodo subarbolDerecho()
        {
            return derecha;
        }

        public Nodo subarbolIzquierdo()
        {
            return izquierda;
        }

        public void nuevoValor(object nv)
        {
            dato = nv;
        }

        public void ramaIzquierda(Nodo n)
        {
            izquierda = n;

        }

        public void ramaDerecha(Nodo n)
        {
            derecha = n;
        }
    }
}
