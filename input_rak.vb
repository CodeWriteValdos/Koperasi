Imports MySql.Data.MySqlClient

Public Class input_rak
    Dim cmd As MySqlCommand
    Dim adapter As MySqlDataAdapter
    Dim baca As MySqlDataReader
    Dim ds As DataSet

    Sub reset()
        TextBox18.Text = ""
        TextBox1.Text = ""
        TextBox18.Focus()
    End Sub

    Sub kode()
        cmd = New MySqlCommand("select count(*) from tb_kel_barang", con)
        Dim rs As Integer
        rs = cmd.ExecuteScalar
        TextBox17.Text = "KB" & rs & ""
    End Sub
    Sub tampil()
        cmd = New MySqlCommand("select * from tb_kel_barang", con)
        cmd.ExecuteNonQuery()
        adapter = New MySqlDataAdapter(cmd)
        Dim table As New DataTable()
        adapter.Fill(table)
        DataGridView1.DataSource = table
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Try
            If TextBox17.Text = "" Or TextBox18.Text = "" Then
                MsgBox("Pilih Data Dulu !!!", vbCritical, "Informasi")
            Else
                cmd = New MySqlCommand("insert into tb_kel_barang values ('" & TextBox17.Text & "','" & TextBox18.Text & "','" & TextBox1.Text & "')", con)
                cmd.ExecuteNonQuery()
                tampil()
                reset()
                kode()
                MsgBox("Success !!!", vbInformation, "Informasi")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub input_rak_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tampil()
        kode()
        Button9.Enabled = True
        Button10.Enabled = False
        Button11.Enabled = False
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        reset()
        kode()
        Button9.Enabled = True
        Button10.Enabled = False
        Button11.Enabled = False
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Try
            If TextBox17.Text = "" Or TextBox18.Text = "" Then
                MsgBox("Lengkapi Data !!!", vbCritical, "Informasi")
            Else
                cmd = New MySqlCommand("delete from tb_kel_barang where kode_kelompok ='" & TextBox17.Text & "'", con)
                cmd.ExecuteNonQuery()
                MsgBox("Data Berhasil di Hapus")
                reset()
                tampil()
                kode()
            End If
        Catch ex As Exception

        End Try
        Button9.Enabled = True
        Button10.Enabled = False
        Button11.Enabled = False

    End Sub
    Private Sub DataGridView1_Click(sender As Object, e As EventArgs) Handles DataGridView1.Click
        TextBox17.Text = DataGridView1.CurrentRow.Cells(0).Value.ToString()
        TextBox18.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString()
        Button11.Enabled = True
        Button10.Enabled = True
        Button9.Enabled = False
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Try
            If TextBox17.Text = "" Or TextBox18.Text = "" Then
                MsgBox("Pilih Data Terlebih dahulu", vbCritical, "Information")
            Else
                cmd = New MySqlCommand("UPDATE tb_kel_barang set nama_kelompok = '" & TextBox18.Text & "', kapasitas = '" & TextBox1.Text & "' where kode_kelompok = '" & TextBox17.Text & "' ", con)
                cmd.ExecuteNonQuery()
                tampil()
                reset()
                kode()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Button9.Enabled = True
        Button10.Enabled = False
        Button11.Enabled = False
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class