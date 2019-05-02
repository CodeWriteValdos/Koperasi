Imports Microsoft.Reporting.WinForms
Imports MySql.Data.MySqlClient

Public Class strukdatadata

    Private Sub Btn_Cari_Click(sender As Object, e As EventArgs) Handles Btn_Cari.Click
        con()
        Dim ds = New DataSetlapbarang
        Dim adaptor = New MySqlDataAdapter("SELECT * FROM view_transaksi WHERE kode_transaksi = '" & ComboBox1.Text & "'", con)
        adaptor.Fill(ds.Tables(0))
        ReportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\Report2.rdlc"
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSetstruk", ds.Tables(0)))
        ReportViewer1.DocumentMapCollapsed = True
        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub Struk_Penjualan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'tampil()
        combo()
    End Sub

    'Sub tampil()
    'con()
    'Dim ds = New DataSetlapbarang
    'Dim adaptor = New MySqlDataAdapter("select * from view_transaksi order by kode_transaksi desc limit 1 where kode_transaksi", con)
    'adaptor.Fill(ds.Tables(0))
    'ReportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
    'ReportViewer1.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\Report2.rdlc"
    'ReportViewer1.LocalReport.DataSources.Clear()
    'ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSetstruk", ds.Tables(0)))
    'ReportViewer1.DocumentMapCollapsed = True
    'Me.ReportViewer1.RefreshReport()
    'End Sub

    Dim cmd As MySqlCommand
    Dim adapter As MySqlDataAdapter
    Dim ds As DataSet
    Dim baca As MySqlDataReader
    Sub combo()
        adapter = New MySqlDataAdapter("select * from view_transaksi order by kode_transaksi desc", con)
        ds = New DataSet
        ds.Clear()
        adapter.Fill(ds, "view_transaksi")
        cmd = New MySqlCommand("select * from view_transaksi order by kode_transaksi desc", con)
        baca = cmd.ExecuteReader
        Do While baca.Read
            ComboBox1.Items.Add(baca.Item(0))
        Loop
    End Sub
End Class