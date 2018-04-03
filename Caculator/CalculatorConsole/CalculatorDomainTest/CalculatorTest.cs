using CalculatorDomain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace CalculatorDomainTest
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        public void SaveLogTest()
        {
            //Preparação
            var id = 1;
            var value1 = 2;
            var value2 = 2;
            var operation = EnumOperationToCalc.Sum;
            var result = 4;

            //Execução
            var calc = new Calculator();
            calc.Save(value1, value2, operation, result);

            //Verificação
            Assert.AreEqual(calc.Log.First().Id, id);
        }
    }
}
