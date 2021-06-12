using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace TP__4
{
    class ActividadAutorizada
    {
        private String nombre;
        private Boolean autorizacion;
        private List<Empresa> empresas;

        public bool Autorizacion { get => autorizacion; set => autorizacion = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        internal List<Empresa> Empresas { get => empresas; set => empresas = value; }
    }
}
