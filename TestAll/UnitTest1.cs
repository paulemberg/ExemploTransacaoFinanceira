using Cotacao;
using System;
using Xunit;


namespace TestAll
{
    public class UnitTest1
    {
        
        [Fact]        
        public void RobotCotacao_Test()
        {
            DolarRobot robot = new DolarRobot();
            robot.CotacaoHoje();



        }
    }
}
