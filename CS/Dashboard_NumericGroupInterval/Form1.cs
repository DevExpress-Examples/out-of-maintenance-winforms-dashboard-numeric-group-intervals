using DevExpress.XtraBars.Ribbon;

namespace Dashboard_NumericGroupInterval {
    public partial class Form1 : RibbonForm {
        public Form1() {
            InitializeComponent();
            dashboardDesigner1.CreateRibbon();
            Size = new System.Drawing.Size(1200, 600);
            dashboardDesigner1.LoadDashboard(@"..\..\Data\NumericGroupIntervalFunctionWithMathValues.xml");
        }
    }
}
