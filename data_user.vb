Imports MySql.Data.MySqlClient
Public Class data_user
    Dim cmd As MySqlCommand
    Dim baca As MySqlDataReader
    Dim ds As DataSet
    Dim adapter As MySqlDataAdapter
    Sub tampiluser()
        Try
            adapter = New MySqlDataAdapter("select id_user,nama_user,level from tb_user", con)
            ds = New DataSet
            adapter.Fill(ds, "tb_user")
            DataGridView1.DataSource = ds.Tables("tb_user")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        
    End Sub
    Private Sub data_user_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        tampiluser()
        dg()

    End Sub

    Sub dg()
        DataGridView1.Columns(0).HeaderText = "Id User"
        DataGridView1.Columns(1).HeaderText = "Nama User"
        DataGridView1.Columns(2).HeaderText = "Level"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If TextBox1.Text = "" Then
                MsgBox("Silahkan pilih data", vbInformation, "Informasi")
            Else
                cmd = New MySqlCommand("delete from tb_user where id_user='" & TextBox1.Text & "'", con)
                cmd.ExecuteNonQuery()
                tampiluser()
                MsgBox("Data Berhasil Dihapus")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub DataGridView1_Click(sender As Object, e As EventArgs) Handles DataGridView1.Click
        TextBox1.Text = DataGridView1.CurrentRow.Cells(0).Value.ToString()
    End Sub
End Class