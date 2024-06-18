using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SimuladorCajeroAutomatico
{
    public class CuentaBasica:Cuenta
    {
        public CuentaBasica(string idCuenta, string idPropietario, double balance, string fecha)
           : base(idCuenta, idPropietario, balance, fecha) { }

        public override double MontoMinimo()
        {
            double SaldoApertura = 100;
            if (base.Balance > 100)
            {
                SaldoApertura = base.Balance;
                Console.Write("Apertura de cuenta exitoso: ");
            }
            else
            {
                SaldoApertura = base.Balance;
                Console.Write("Saldo no es suficiente para aperturar cuenta ");
            }
            return SaldoApertura;
        }
        public override string ToString()
        {
            return "Cuenta Básica" +
                "\nId de Cuenta: " + IdCuenta
                + "\nId de Propietario: " + IdPropietario
                + "\nBalance: " + Balance
                + "\nFecha de creación:" + Fecha;
        }
    }
}
