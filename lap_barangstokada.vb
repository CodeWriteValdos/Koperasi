Imports MySql.Data.MySqlClient

Public Class lap_barangstokada

    Private Sub lap_barangstokada_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con()
        Dim ds = New DataSetlapbarang
        Dim adaptor = New MySqlDataAdapter("SELECT * FROM view_barang WHERE stok BETWEEN '1' AND '1000'", con)
        adaptor.Fill(ds.Tables(0))

        ReportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\Report5.rdlc"
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSetlapbarang", ds.Tables(0)))
        ReportViewer1.DocumentMapCollapsed = True
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class