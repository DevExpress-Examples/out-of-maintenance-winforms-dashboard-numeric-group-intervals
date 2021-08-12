Imports DevExpress.XtraBars.Ribbon

Namespace Dashboard_NumericGroupInterval
	Partial Public Class Form1
		Inherits RibbonForm

		Public Sub New()
			InitializeComponent()
			dashboardDesigner1.CreateRibbon()
			Size = New System.Drawing.Size(1200, 600)
			dashboardDesigner1.LoadDashboard("..\..\Data\NumericGroupIntervalFunctionWithMathValues.xml")
		End Sub
	End Class
End Namespace
