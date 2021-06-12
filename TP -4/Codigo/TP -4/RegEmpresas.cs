using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP__4
{
    class RegEmpresas
    {
        private List<Empresa> empresasRegistradas = new List<Empresa>();

        internal List<Empresa> EmpresasRegistradas { get => empresasRegistradas; set => empresasRegistradas = value; }

        public void RegistrarEmpresa(Empresa empresa)
        {
            empresasRegistradas.Add(empresa);
        }

        public int CantidadEmpresas()
        {
            return empresasRegistradas.Count();
        }

        public void MuestreoEmpresas()
        {
            for (int i = 0; i < empresasRegistradas.Count; i++)
            {
                empresasRegistradas[i].ToStringEmpresa();
            }
        }
    }
}
