Imports MySql.Data.MySqlClient
Public Class info_kel
    Dim cmd As MySqlCommand
    Dim adapter As MySqlDataAdapter
    Dim baca As MySqlDataReader
    Dim ds As DataSet
    Private Sub info_kel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmd = New MySqlCommand("select * from tb_kel_barang", con)
        cmd.ExecuteNonQuery()
        adapter = New MySqlDataAdapter(cmd)
        Dim table As New DataTable()
        adapter.Fill(table)
        DataGridView1.DataSource = table
    End Sub
End Class