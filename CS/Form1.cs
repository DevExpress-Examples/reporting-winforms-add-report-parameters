using System;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Parameters;
// ...

namespace CreateReportWithParameters {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            // Create a report instance.
            XtraReport1 report = new XtraReport1();

            // Create a parameter and specify its name.
            Parameter param1 = new Parameter();
            param1.Name = "CatID";

            // Specify other parameter properties.
            param1.ParameterType = ParameterType.Int32;
            param1.Value = 1;
            param1.Description = "Category: ";
            param1.Visible = true;

            // Add the parameter to the report, and force the report 
            // to request the parameter's value in preview.
            report.Parameters.Add(param1);
            report.RequestParameters = true;

            // Specify the report's filter.
            report.FilterString = "[CategoryID] = [Parameters.CatID]";

            // Show the parameter's value on a Report Header band.
            XRLabel label = new XRLabel();
            label.DataBindings.Add(new XRBinding(param1, "Text", "Category: {0}"));
            ReportHeaderBand reportHeader = new ReportHeaderBand();
            reportHeader.Controls.Add(label);
            report.Bands.Add(reportHeader);

            // Show the report's print preview.
            report.ShowPreview();
        }
    }
}