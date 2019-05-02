Imports MySql.Data.MySqlClient
Public Class home
    Dim cmd As MySqlCommand
    Sub hitung()
        cmd = New MySqlCommand("select count(*) from tb_user", con)
        Dim rs As Integer
        rs = cmd.ExecuteScalar

        Label6.Text = rs
    End Sub
    Sub hitungpemasok()
        cmd = New MySqlCommand("select count(*) from tb_pemasok", con)
        Dim rs As Integer
        rs = cmd.ExecuteScalar

        Label8.Text = rs
    End Sub
    

    Private Sub home_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        hitung()
        hitungpemasok()
    End Sub

    Private Sub RectangleShape1_Click(sender As Object, e As EventArgs) Handles RectangleShape1.Click
        Try
            Panel2.Controls.Clear()
            Me.Panel2.Controls.Add(Tentang_app.Panel1)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        

    End Sub

    Private Sub RectangleShape2_Click(sender As Object, e As EventArgs) Handles RectangleShape2.Click
        Panel2.Controls.Clear()
        Me.Panel2.Controls.Add(data_user.Panel1)
    End Sub

    Private Sub RectangleShape3_Click(sender As Object, e As EventArgs) Handles RectangleShape3.Click
        Panel2.Controls.Clear()
        Me.Panel2.Controls.Add(data_pemasok.Panel1)
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        hitungpemasok()
    End Sub
End Class