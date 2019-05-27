using System;

namespace Cotacao
{
    public class Dolar
    {
        public double DolarHoje()
        {
            var robot = new DolarRobot();

            return robot.CotacaoHoje();
            
        }

    }
}
