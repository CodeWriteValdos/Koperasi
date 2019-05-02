Imports MySql.Data.MySqlClient
Public Class transaksi
    Dim cmd As MySqlCommand
    Dim baca As MySqlDataReader
    Dim adapter As MySqlDataAdapter
    Sub tampil()
        cmd = New MySqlCommand("select * from tb_transaksi", con)
        cmd.ExecuteNonQuery()
        adapter = New MySqlDataAdapter(cmd)
        Dim table As New DataTable()
        adapter.Fill(table)
        DataGridView1.DataSource = table
    End Sub
    Sub auto()
        cmd = New MySqlCommand("select count(*) from tb_transaksi2", con)
        Dim rs As Integer
        rs = cmd.ExecuteScalar

        TextBox17.Text = "PG0" & rs & ""
    End Sub
    Sub reset()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        total_harga.Text = "Total Harga"
        TextBox1.Focus()
    End Sub
    Sub hitung()
        Dim totalbelanja As Integer
        totalbelanja = 0
        For t As Integer = 0 To DataGridView1.Rows.Count - 1
            totalbelanja = totalbelanja + Val(DataGridView1.Rows(t).Cells(5).Value)
        Next
        TextBox6.Text = totalbelanja
    End Sub

    Private Sub transaksi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        auto()
    End Sub

    Private Sub Label38_Click(sender As Object, e As EventArgs) Handles Label38.Click
        Application.Exit()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles kembali.Click
        Me.Hide()
        menu_admin.Show()
    End Sub

    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox5.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub


    Private Sub TextBox7_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox7.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True


    End Sub

    Private Sub keluar_Click(sender As Object, e As EventArgs) Handles keluar.Click
        Me.Hide()
        login.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If TextBox7.Text = "" Or TextBox6.Text = "" Or TextBox8.Text = "" Then
            MsgBox("Lengkapi Data !!!", vbInformation, "Informasi")
        Else
            If TextBox8.Text < 0 Then
                MsgBox("Maaf Uang anda kurang !!!", vbInformation, "Informasi")
            Else
                Try
                    cmd = New MySqlCommand("insert into tb_pretransaksi values ('" & TextBox17.Text & "','" & TextBox6.Text & "','" & TextBox7.Text & "','" & TextBox8.Text & "', '" & DateTimePicker1.Text & "')", con)
                    cmd.ExecuteNonQuery()
                    cmd = New MySqlCommand("truncate tb_transaksi", con)
                    cmd.ExecuteNonQuery()
                    tampil()
                    auto()
                    TextBox6.Text = ""
                    TextBox7.Text = ""
                    TextBox8.Text = ""
                    MsgBox("Success !!!", vbInformation, "Informasi")
                    Struk_Penjualan.Show()
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        cmd = New MySqlCommand("select * from tb_barang where kode_barang='" & TextBox1.Text & "'", con)
        baca = cmd.ExecuteReader
        If baca.Read = False Then
            MsgBox("data tidak di temukan")
        Else
            TextBox2.Text = baca("nama_barang")
            TextBox3.Text = baca("stok")
            TextBox4.Text = baca("harga_jual")
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim jumlah As Integer
        If TextBox1.Text Like lblkd.Text Then
            If Val(TextBox5.Text) > Val(TextBox3.Text) Then
                MsgBox("Maaf Stok Barang Kurang ...", vbInformation, "Informasi")
                TextBox5.Text = ""
                TextBox5.Focus()
            Else
                If TextBox1.Text = "" Or TextBox5.Text = "" Then
                    MsgBox("Lengkapi data !!!", vbInformation, "Informasi")
                Else
                    If TextBox3.Text < 0 Then
                        MsgBox("Maaf Stok Habis", vbInformation, "Informasi")
                    Else
                        jumlah = Val(TextBox5.Text) + Val(TextBox9.Text)
                        cmd = New MySqlCommand("update tb_transaksi set jumlah_barang = '" & jumlah & "' where kode_barang ='" & TextBox1.Text & "' and kode_transaksi = '" & TextBox17.Text & "' ", con)
                        cmd.ExecuteNonQuery()
                        cmd = New MySqlCommand("update tb_transaksi2 set jumlah_barang = '" & jumlah & "' where kode_barang ='" & TextBox1.Text & "' and kode_transaksi = '" & TextBox17.Text & "' ", con)
                        cmd.ExecuteNonQuery()
                        tampil()
                        reset()
                    End If
                End If
            End If
        Else
            If Val(TextBox5.Text) > Val(TextBox3.Text) Then
                MsgBox("Maaf Stok Barang Kurang ...", vbInformation, "Informasi")
                TextBox5.Text = ""
                TextBox5.Focus()
            Else
                If TextBox1.Text = "" Or TextBox5.Text = "" Then
                    MsgBox("Lengkapi data !!!", vbInformation, "Informasi")
                Else
                    If TextBox3.Text < 0 Then
                        MsgBox("Maaf Stok Habis", vbInformation, "Informasi")
                    Else
                        cmd = New MySqlCommand("insert into tb_transaksi values('" & TextBox17.Text & "','" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & total_harga.Text & "','" & DateTimePicker1.Text & "')", con)
                        cmd.ExecuteNonQuery()
                        cmd = New MySqlCommand("insert into tb_transaksi2 values('" & TextBox17.Text & "','" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & total_harga.Text & "','" & DateTimePicker1.Text & "')", con)
                        cmd.ExecuteNonQuery()
                        tampil()
                        reset()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        hitung()
        TextBox7.Focus()
    End Sub

    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles TextBox7.TextChanged
        TextBox8.Text = Val(TextBox7.Text) - Val(TextBox6.Text)
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        total_harga.Text = Val(TextBox4.Text) * Val(TextBox5.Text)
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        If TextBox3.Text = "0" Then
            MsgBox("Barang Sudah Habis Terjual")
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            TextBox1.Focus()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            If lblkd.Text = "" Then
                MsgBox("Pilih Data Terlebih Dahulu !!!", vbInformation, "Informasi")
            Else
                cmd = New MySqlCommand("delete from tb_transaksi where kode_barang='" & lblkd.Text & "'", con)
                cmd.ExecuteNonQuery()
                cmd = New MySqlCommand("delete from tb_transaksi2 where kode_transaksi='" & kode_transaksi.Text & "' and kode_barang='" & lblkd.Text & "'", con)
                cmd.ExecuteNonQuery()
                tampil()
                MsgBox("Data Berhasil Dihapus")
                lblkd.Text = "Id Barang"
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub DataGridView1_Click(sender As Object, e As EventArgs) Handles DataGridView1.Click

        kode_transaksi.Text = DataGridView1.CurrentRow.Cells(0).Value.ToString()
        lblkd.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString()
        TextBox1.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString()
        TextBox9.Text = DataGridView1.CurrentRow.Cells(4).Value.ToString()
    End Sub

End Class