﻿Imports MySql.Data.MySqlClient

Public Class lap_barangpertanggal

    Private Sub lap_barangpertanggal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            con()
            Dim ds = New DataSetstruk
            Dim adaptor = New MySqlDataAdapter("SELECT * FROM tb_barang WHERE tgl_input between @fromDate and @toDate", con)
            adaptor.SelectCommand.Parameters.AddWithValue("@fromDate", DateTimePicker1.Text)
            adaptor.SelectCommand.Parameters.AddWithValue("@toDate", DateTimePicker2.Text)
            adaptor.Fill(ds.Tables(0))
            ReportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
            ReportViewer1.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\Report4.rdlc"
            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSetlapbarang", ds.Tables(0)))
            ReportViewer1.DocumentMapCollapsed = True
            Me.ReportViewer1.RefreshReport()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
End Class