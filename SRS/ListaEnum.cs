using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRS;

namespace testProject
{
    class ListaEnum<T> : IEnumerator<T>
    {
        Lista<T> lista;
        int pozycja = -1;

        public ListaEnum(Lista<T> lista){
            this.lista = lista;
        }

        public T Current
        {
            get
            {
                try
                {
                    return lista[pozycja];
                }
                catch(IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public void Dispose()
        {
            
        }

        public bool MoveNext()
        {
            pozycja++;
            return (pozycja < lista.Count);
        }

        public void Reset()
        {
            pozycja = -1;
        }
    }
}
