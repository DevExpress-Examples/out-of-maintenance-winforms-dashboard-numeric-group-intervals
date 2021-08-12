using DevExpress.Data.Filtering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard_NumericGroupInterval {
    class GetNumericGroupIntervalFunction : ICustomFunctionOperatorBrowsable, ICustomFunctionOperatorFormattable {

        static double GetNumericGroupInterval(double number, double intervalNumber) {
            if(intervalNumber <= 0) {
                throw new ArgumentException("Interval number must be more, than 0.");
            }
            double module = Math.Abs(number);
            return Math.Sign(number) * (module - module % intervalNumber);
        }
        public int MinOperandCount => 2;

        public int MaxOperandCount => 2;

        public string Description => "Calculates numeric group interval for the given value and interval";

        public FunctionCategory Category => FunctionCategory.Math;

        public string Name => "GetNumericGroupInterval";

        public object Evaluate(params object[] operands) {
            return GetNumericGroupInterval(Convert.ToDouble(operands[0]), Convert.ToDouble(operands[1]));
        }

        public bool IsValidOperandCount(int count) {
            return count == 2;
        }

        bool IsNumericType(Type type) {
            return type == typeof(double) || type == typeof(decimal) || type == typeof(float) ||
            type == typeof(byte) || type == typeof(sbyte) || type == typeof(short) ||
            type == typeof(ushort) || type == typeof(int) || type == typeof(uint) ||
            type == typeof(long) || type == typeof(uint);
        }

        public bool IsValidOperandType(int operandIndex, int operandCount, Type type) {
            return IsNumericType(type) && operandCount == 2 && (operandIndex == 0 || operandIndex == 1);
        }

        public Type ResultType(params Type[] operands) {
            return typeof(double);
        }

        public string Format(Type providerType, params string[] operands) { 
            return $"SIGN({operands[0]}) * (ABS({operands[0]}) - ABS({operands[0]}) % {operands[1]})";
        }
    }
}
