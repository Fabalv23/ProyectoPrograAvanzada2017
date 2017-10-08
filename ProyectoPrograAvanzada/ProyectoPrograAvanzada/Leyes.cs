﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoPrograAvanzada
{
    class Leyes<T>
    {
        int codigo;
        public Pila<Ley> first, last;
        public Leyes<Ley> siguiente;

        public Leyes(int codigo)
        {
            this.codigo = codigo;
            first = last = null;
            siguiente = null;
        }

        public int Codigo
        {
            get { return codigo; }
        }

        public void Insertar(Pila<Ley> nuevo)
        {
            if (first == null)
                first = nuevo;
            else
                last.siguiente = nuevo;
            last = nuevo;
        }

        public String Mostrar()
        {
            String regreso = "";
            if (first != null)
            {
                Pila<Ley> actual = first;
                Pila<Ley> Temp = actual;
                while (actual != null)
                {
                    regreso += actual.verCima().mostrarLey() + "\n";
                    actual = actual.siguiente;
                }
            }
            else
                regreso = "\nLa pila de leyes esta {0} Está Vacía...";

            return regreso;
        }

        /** public void MostrarLey()
         {
             Console.Write("N° Ley: {0}\n", codigo);
         }**/

        public Pila<Ley> Buscar(int n)
        {
            Pila<Ley> actual = first;
            while (actual != null)
            {
                if (actual.verCima().getLey() == n)
                    return actual;
                actual = actual.siguiente;
            }
            return null;
        }

        public void Eliminar(int n)
        {
            if (first != null)
            {
                Pila<Ley> actual, padre;
                padre = BuscarPadre(n);
                if (padre == last)
                {
                    MessageBox.Show("\nLey No Encontrada...");
                    return;
                }
                if (padre == null)
                {
                    actual = first;
                    first = first.siguiente;
                    padre = first;
                }
                else
                {
                    actual = padre.siguiente;
                    padre.siguiente = actual.siguiente;
                }
                actual = null;
                if (padre == null || padre.siguiente == null)
                    last = padre;
                MessageBox.Show("Ley eliminada");
            }
            else
                MessageBox.Show("\nNo Existe ninguna ley");
        }

        private Pila<Ley> BuscarPadre(int n)
        {
            Pila<Ley> padre, actual;
            actual = first;
            padre = null;
            while (actual != null)
            {
                if (actual.verCima().getLey() == n)
                    break;
                padre = actual;
                actual = actual.siguiente;
            }
            return padre;
        }
    }
}
