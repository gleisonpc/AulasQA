using System.Collections.Generic;
using System.Linq;

namespace CalculatorDomain
{
    public class Calculator
    {
        public Calculator()
        {
            Log = new List<CalculatorLog>();
        }

        public IList<CalculatorLog> Log { get; private set; }

        public int Calculate(int value1, int value2, EnumOperationToCalc operation)
        {
            switch (operation)
            {
                case EnumOperationToCalc.Sum:
                    return value1 + value2;

                case EnumOperationToCalc.Sub:
                    return value1 - value2;

                case EnumOperationToCalc.Mult:
                    return value1 * value2;

                case EnumOperationToCalc.Div:
                    return value1 / value2;

                default:
                    return 0;
            }
        }

        public void Save(int value1, int value2, EnumOperationToCalc operation, int result)
        {
            var id = Log.LastOrDefault() == null ? 1 : Log.LastOrDefault().Id + 1;
            Log.Add(CalculatorLog.Create(id, value1, value2, operation, result));
        }
    }
}
