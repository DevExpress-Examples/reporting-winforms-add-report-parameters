Imports Microsoft.VisualBasic
Imports System
Imports System.Windows.Forms
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraReports.Parameters
' ...

Namespace CreateReportWithParameters
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a report instance.
			Dim report As New XtraReport1()

			' Create a parameter and specify its name.
			Dim param1 As New Parameter()
			param1.Name = "CatID"

			' Specify other parameter properties.
			param1.ParameterType = ParameterType.Int32
			param1.Value = 1
			param1.Description = "Category: "
			param1.Visible = True

			' Add the parameter to the report, and force the report 
			' to request the parameter's value in preview.
			report.Parameters.Add(param1)
			report.RequestParameters = True

			' Specify the report's filter.
			report.FilterString = "[CategoryID] = [Parameters.CatID]"

			' Show the parameter's value on a Report Header band.
			Dim label As New XRLabel()
			label.DataBindings.Add(New XRBinding(param1, "Text", "Category: {0}"))
			Dim reportHeader As New ReportHeaderBand()
			reportHeader.Controls.Add(label)
			report.Bands.Add(reportHeader)

			' Show the report's print preview.
			report.ShowPreview()
		End Sub
	End Class
End Namespace