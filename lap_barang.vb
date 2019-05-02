Imports MySql.Data.MySqlClient
Imports Microsoft.Reporting.WinForms

Public Class lap_barang

    Private Sub lap_barang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        tampil()
    End Sub

    Private Sub tampil()
        con()
        Dim ds = New DataSetlapbarang
        Dim adaptor = New MySqlDataAdapter("SELECT * FROM view_barang", con)
        adaptor.Fill(ds.Tables(0))

        ReportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\Report1.rdlc"
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSetlapbarang", ds.Tables(0)))
        ReportViewer1.DocumentMapCollapsed = True
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class