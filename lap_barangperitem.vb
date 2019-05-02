Imports Microsoft.Reporting.WinForms
Imports MySql.Data.MySqlClient

Public Class lap_barangperitem

    Private Sub tampilbarang_Click(sender As Object, e As EventArgs) Handles tampilbarang.Click
        con()
        Dim ds = New DataSetlapbarang
        Dim adaptor = New MySqlDataAdapter("SELECT * FROM view_barang WHERE kode_barang='" & searchbarang.Text & "'", con)
        adaptor.Fill(ds.Tables(0))

        ReportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\Report1.rdlc"
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSetlapbarang", ds.Tables(0)))
        ReportViewer1.DocumentMapCollapsed = True
        Me.ReportViewer1.RefreshReport()

    End Sub

    Private Sub lap_barangperitem_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class