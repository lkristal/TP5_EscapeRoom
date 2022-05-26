using System;
using System.Collections.Generic;

namespace TP5_Kristal.Models
{
    public class Escape
    {
        private List<string> _IncongnitasSalas = new List<string>();
        private int _EstadoJuego = 1;
        public int EstadoJuego { get { return _EstadoJuego;}}
        
        private void InicializarJuego()
        {
            _IncongnitasSalas.Add("ZSOHNMHO");
            _IncongnitasSalas.Add("38");
            _IncongnitasSalas.Add("1975-01-13");
            _IncongnitasSalas.Add("TRIANGULO");
        }
        
        public bool ResolverSala(int Sala, string Incognita)
        {
            bool Retorno = false;
            if (_IncongnitasSalas.Count == 0) InicializarJuego();
            if (_EstadoJuego <= Sala) {
                if (_IncongnitasSalas[Sala-1]== Incognita) 
                {
                    _EstadoJuego++;
                    Retorno = true;
                }
            }
            return Retorno;
        }

    }
}
