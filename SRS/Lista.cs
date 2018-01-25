using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using testProject;

namespace SRS
{
    public class Struktura<T>
    {
        private Struktura<T> _nastepna;
        private T _obiekt;

        public Struktura(T obiekt)
        {
            _obiekt = obiekt;
            _nastepna = null;
        }

        public Struktura<T> Nastepna { get => _nastepna; set => _nastepna = value; }
        public T Obiekt { get => _obiekt; set => _obiekt = value; }
    }
    public class Lista<T> : IList<T>
    {

        private Struktura<T> _poczatek;
        private int _liczbaElementow;

        public Lista()
        {
            _liczbaElementow = 0;
        }

        public T this[int index] {
            get
            {
                if (index < 0) throw new ArgumentOutOfRangeException("Indeks mniejszy od zera");
                if (index >= _liczbaElementow) throw new ArgumentOutOfRangeException("Indeks poza listą");

                Struktura<T> tmp = _poczatek;
                for (int i = 0; i < index; i++)
                {
                    tmp = tmp.Nastepna;
                }
                return tmp.Obiekt;
            }
            set
            {
                if (index < 0) throw new ArgumentOutOfRangeException("Indeks mniejszy od zera");
                if (index >= _liczbaElementow) throw new ArgumentOutOfRangeException("Indeks poza listą");

                Struktura<T> tmp = _poczatek;
                for (int i = 0; i < index; i++)
                {
                    tmp = tmp.Nastepna;
                }
                tmp.Obiekt = value;
            }
        }

        public int Count
        {
            get { return _liczbaElementow; }
        }

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            if (_poczatek == null)
            {
                _poczatek = new Struktura<T>(item);
            }
            else
            {
                Struktura<T> tmp = _poczatek;
                while (tmp.Nastepna != null)
                {
                    tmp = tmp.Nastepna;
                }
                tmp.Nastepna = new Struktura<T>(item);
            }
            _liczbaElementow++;
            
        }

        public void Clear()
        {
            _poczatek = null;
            _liczbaElementow = 0;
        }

        public bool Contains(T item)
        {
            if (_poczatek.Obiekt.Equals(item)) return true;
            else
            {
                Struktura<T> tmp = _poczatek;
                while (tmp.Nastepna != null)
                {
                    if (_poczatek.Obiekt.Equals(item)) return true;
                    tmp = tmp.Nastepna;
                }
                return false;
            }
         
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            int j = arrayIndex;
            for (int i = 0; i < Count; i++)
            {
                array.SetValue(this[i], j);
                j++;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new ListaEnum<T>(this);
        }

        public int IndexOf(T item)
        {
            int licznik = 0;
            if (_poczatek.Obiekt.Equals(item)) return licznik;
            else
            {
                Struktura<T> tmp = _poczatek;
                while (tmp.Nastepna != null)
                {
                    tmp = tmp.Nastepna;
                    licznik++;
                    if (tmp.Obiekt.Equals(item)) return licznik;
                }
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("Indeks mniejszy od zera");
            if (index > _liczbaElementow) throw new ArgumentOutOfRangeException("Indeks poza listą");

            if (index == 0)
            {
                Struktura<T> doDodania = new Struktura<T>(item);
                doDodania.Nastepna = _poczatek;
                _poczatek = doDodania;
            }
            else
            {
                Struktura<T> tmp = _poczatek;
                for (int i = 0; i < index - 1; i++)
                {
                    tmp = tmp.Nastepna;
                }
                Struktura<T> nastepna = tmp.Nastepna;
                tmp.Nastepna = new Struktura<T>(item);
                tmp = tmp.Nastepna;
                tmp.Nastepna = nastepna;
            }
            _liczbaElementow++;
        }

        public bool Remove(T item)
        {
            if (_poczatek != null)
            {
                if (_poczatek.Obiekt.Equals(item))
                {
                    _poczatek = _poczatek.Nastepna;
                }
                else
                {
                    Struktura<T> tmp = _poczatek;
                    while (tmp.Nastepna != null)
                    {
                        if (tmp.Nastepna.Obiekt.Equals(item)) break;
                        tmp = tmp.Nastepna;
                    }
                    Struktura<T> doUsuniecia = tmp.Nastepna;
                    if (tmp.Nastepna != null)
                    {
                        tmp.Nastepna = tmp.Nastepna.Nastepna;
                    }
                    else
                    {
                        tmp.Nastepna = null;
                    }
                }
                _liczbaElementow--;
                return true;
            }
            
            return false;
        }

        public void RemoveAt(int index)
        {
            if (index < 0) throw new ArgumentOutOfRangeException("Indeks mniejszy od zera");
            if (index >= _liczbaElementow) throw new ArgumentOutOfRangeException("Indeks poza listą");

            if (index == 0) _poczatek = _poczatek.Nastepna;
            else
            {
                Struktura<T> tmp = _poczatek;
                for (int i = 0; i < index - 1; i++)
                {
                    tmp = tmp.Nastepna;
                }
                Struktura<T> doUsuniecia = tmp.Nastepna;
                tmp.Nastepna = tmp.Nastepna.Nastepna;

                _liczbaElementow--;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }
    }
}