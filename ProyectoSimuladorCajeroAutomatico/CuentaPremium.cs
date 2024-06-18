using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorCajeroAutomatico
{
    public class CuentaPremium : Cuenta
    {
        public CuentaPremium(string idCuenta, string idPropietario, double balance, string fecha)
           : base(idCuenta, idPropietario, balance, fecha) { }

        public override double MontoMinimo()
        {
            double SaldoApertura = 1500;
            if (base.Balance > 1500)
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
            return "Cuenta Premium" +
                "\nId de Cuenta: " + IdCuenta
                + "\nId de Propietario: " + IdPropietario
                + "\nBalance: " + Balance
                + "\nFecha de creación:" + Fecha;
        }
    }
}


