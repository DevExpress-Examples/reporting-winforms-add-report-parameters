Imports System
Imports System.Windows.Forms
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraReports.Parameters
' ...

Namespace Report_ParametertsPanel
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

        Private Sub simpleButton1_Click(ByVal sender As Object, _
        ByVal e As EventArgs) Handles simpleButton1.Click
            ' Create a report instance.
            Dim report As New XtraReport1()

            ' Create a parameter and specify its name.
            Dim param1 As New Parameter()
            param1.Name = "CatID"

            ' Specify other parameter properties.
            param1.Type = GetType(System.Int32)
            param1.Value = 1
            param1.Description = "Category: "
            param1.Visible = True

            ' Add the parameter to the report.
            report.Parameters.Add(param1)

            ' Specify the report's filter string.
            report.FilterString = "[CategoryID] = [Parameters.CatID]"

            ' Force the report creation without previously 
            ' requesting the parameter value from end-users.
            report.RequestParameters = False

            ' Show the parameter's value on a Report Header band.
            Dim label As New XRLabel()
            label.DataBindings.Add(New XRBinding(param1, "Text", "Category: {0}"))
            Dim reportHeader As New ReportHeaderBand()
            reportHeader.Controls.Add(label)
            report.Bands.Add(reportHeader)

            ' Assign the report to a ReportPrintTool,
            ' to hide the Parameters panel,
            ' and show the report's print preview.
            Dim pt As New ReportPrintTool(report)
            pt.AutoShowParametersPanel = True
            pt.ShowPreviewDialog()
        End Sub

	End Class
End Namespace
