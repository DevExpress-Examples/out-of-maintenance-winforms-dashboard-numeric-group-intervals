Imports DevExpress.Data.Filtering
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace Dashboard_NumericGroupInterval
	Friend Class GetNumericGroupIntervalFunction
		Implements ICustomFunctionOperatorBrowsable, ICustomFunctionOperatorFormattable

		Private Shared Function GetNumericGroupInterval(ByVal number As Double, ByVal intervalNumber As Double) As Double
			If intervalNumber <= 0 Then
				Throw New ArgumentException("Interval number must be more, than 0.")
			End If
			Dim [module] As Double = Math.Abs(number)
			Return Math.Sign(number) * ([module] - [module] Mod intervalNumber)
		End Function
		Public ReadOnly Property MinOperandCount() As Integer Implements ICustomFunctionOperatorBrowsable.MinOperandCount
			Get
				Return 2
			End Get
		End Property

		Public ReadOnly Property MaxOperandCount() As Integer Implements ICustomFunctionOperatorBrowsable.MaxOperandCount
			Get
				Return 2
			End Get
		End Property

		Public ReadOnly Property Description() As String Implements ICustomFunctionOperatorBrowsable.Description
			Get
				Return "Calculates numeric group interval for the given value and interval"
			End Get
		End Property

		Public ReadOnly Property Category() As FunctionCategory Implements ICustomFunctionOperatorBrowsable.Category
			Get
				Return FunctionCategory.Math
			End Get
		End Property

		Public ReadOnly Property Name() As String Implements DevExpress.Data.Filtering.ICustomFunctionOperator.Name
			Get
				Return "GetNumericGroupInterval"
			End Get
		End Property

		Public Function Evaluate(ParamArray ByVal operands() As Object) As Object Implements DevExpress.Data.Filtering.ICustomFunctionOperator.Evaluate
			Return GetNumericGroupInterval(Convert.ToDouble(operands(0)), Convert.ToDouble(operands(1)))
		End Function

		Public Function IsValidOperandCount(ByVal count As Integer) As Boolean Implements ICustomFunctionOperatorBrowsable.IsValidOperandCount
			Return count = 2
		End Function

		Private Function IsNumericType(ByVal type As Type) As Boolean
			Return type Is GetType(Double) OrElse type Is GetType(Decimal) OrElse type Is GetType(Single) OrElse type Is GetType(Byte) OrElse type Is GetType(SByte) OrElse type Is GetType(Short) OrElse type Is GetType(UShort) OrElse type Is GetType(Integer) OrElse type Is GetType(UInteger) OrElse type Is GetType(Long) OrElse type Is GetType(UInteger)
		End Function

		Public Function IsValidOperandType(ByVal operandIndex As Integer, ByVal operandCount As Integer, ByVal type As Type) As Boolean Implements ICustomFunctionOperatorBrowsable.IsValidOperandType
			Return IsNumericType(type) AndAlso operandCount = 2 AndAlso (operandIndex = 0 OrElse operandIndex = 1)
		End Function

		Public Function ResultType(ParamArray ByVal operands() As Type) As Type Implements DevExpress.Data.Filtering.ICustomFunctionOperator.ResultType
			Return GetType(Double)
		End Function

		Public Function Format(ByVal providerType As Type, ParamArray ByVal operands() As String) As String Implements ICustomFunctionOperatorFormattable.Format
			Return $"SIGN({operands(0)}) * (ABS({operands(0)}) - ABS({operands(0)}) % {operands(1)})"
		End Function
	End Class
End Namespace
