﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TP_Integrador___Team_4
{
    class Cuota
    {
        private decimal monto;
        private DateTime fecha;
        private Boolean pagado;
        private Pago pagos;

        public decimal Monto { get => monto; set => monto = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public Boolean Pagado { get => pagado; set => pagado = value; }
        public Pago Pagos { get => pagos; set => pagos = value; }
    }
}
