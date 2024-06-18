using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorCajeroAutomatico
{
    public abstract class Cuenta
    {
        public string IdCuenta { get; set; }
        public string IdPropietario { get; set; }
        public double Balance { get; set; }
        public string Fecha { get; set; }

        public Cuenta() { }

        public Cuenta(string idCuenta, string idPropietario, double balance, string fecha)
        {
            IdCuenta = idCuenta;
            IdPropietario = idPropietario;
            Balance = balance;
            Fecha = fecha;
        }

        public void Deposito(double monto)
        {
            if (monto > 0)
            {
                Balance += monto;
            }
        }
        public void Retiro(double monto)
        {
            if (monto <= Balance)
            {
                Balance -= monto;
            }
        }

        public abstract double MontoMinimo();
    }

}

