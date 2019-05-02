Imports MySql.Data.MySqlClient

Public Class data_pemasok
    Dim cmd As MySqlCommand
    Dim baca As MySqlDataReader
    Dim ds As DataSet
    Dim adapter As MySqlDataAdapter
    Sub tampilpemasok()
        adapter = New MySqlDataAdapter("select id_pemasok,nama_pemasok,kode_barang,nama_barang from tb_pemasok", con)
        ds = New DataSet
        adapter.Fill(ds, "tb_pemasok")
        DataGridView1.DataSource = ds.Tables("tb_pemasok")
    End Sub
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        tampilpemasok()
        dg()
    End Sub

    Sub dg()
        DataGridView1.Columns(0).HeaderText = "Kode Pemasok"
        DataGridView1.Columns(1).HeaderText = "Nama Pemasok"
        DataGridView1.Columns(2).HeaderText = "Kode Barang"
        DataGridView1.Columns(3).HeaderText = "Nama Barang"
    End Sub

End Class