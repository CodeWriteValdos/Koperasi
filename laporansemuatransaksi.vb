Imports MySql.Data.MySqlClient

Public Class laporansemuatransaksi

    Private Sub laporansemuatransaksi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            con()
            Dim ds = New DataSetstruk
            Dim adaptor = New MySqlDataAdapter("SELECT * FROM view_transaksi", con)
            adaptor.Fill(ds.Tables(0))
            ReportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
            ReportViewer1.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\Report3.rdlc"
            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSetstruk", ds.Tables(0)))
            ReportViewer1.DocumentMapCollapsed = True
            Me.ReportViewer1.RefreshReport()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

    End Sub
End Class