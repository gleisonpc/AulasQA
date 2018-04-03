namespace CalculatorDomain
{
    public class CalculatorLog
    {
        private CalculatorLog() { }

        public int Id { get; private set; }

        public int Value1 { get; private set; }

        public int Value2 { get; private set; }

        public EnumOperationToCalc Operation { get; private set; }

        public string VisibleOperation
        {
            get
            {
                switch (Operation)
                {
                    case EnumOperationToCalc.Sum:
                        return "+";
                    case EnumOperationToCalc.Sub:
                        return "-";
                    case EnumOperationToCalc.Mult:
                        return "x";
                    case EnumOperationToCalc.Div:
                        return "/";
                    default:
                        return string.Empty;
                }
            }
        }

        public int Result { get; private set; }

        public static CalculatorLog Create(int id, int value1, int value2, EnumOperationToCalc operation, int result)
            => new CalculatorLog
            {
                Id = id,
                Value1 = value1,
                Value2 = value2,
                Operation = operation,
                Result = result
            };
    }
}
