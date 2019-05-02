Imports MySql.Data.MySqlClient
Public Class input_barang
    Dim cmd As MySqlCommand
    Dim adapter As MySqlDataAdapter
    Dim ds As DataSet
    Dim baca As MySqlDataReader

    Sub tampilBarang()
        Try
            adapter = New MySqlDataAdapter("select kode_barang,nama_barang,harga_awal,harga_jual,stok,kode_kelompok,tgl_input from tb_barang", con)
            ds = New DataSet
            adapter.Fill(ds, "tb_barang")
            DataGridView3.DataSource = ds.Tables("tb_barang")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        

    End Sub
    Sub tampil()
        Try

            cmd = New MySqlCommand("select * from tb_barang", con)
            cmd.ExecuteNonQuery()
            adapter = New MySqlDataAdapter(cmd)
            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridView3.DataSource = table
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Sub reset()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        ComboBox1.Text = ""
        TextBox1.Focus()
        ComboBox1.Items.Clear()

    End Sub
    Sub combo()
        adapter = New MySqlDataAdapter("select * from tb_kel_barang order by kode_kelompok asc", con)
        ds = New DataSet
        ds.Clear()
        adapter.Fill(ds, "tb_kel_barang")
        cmd = New MySqlCommand("select * from tb_kel_barang", con)
        baca = cmd.ExecuteReader
        Do While baca.Read
            ComboBox1.Items.Add(baca.Item(0))
        Loop

    End Sub


    Private Sub input_barang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tampilBarang()
        tampil()
        combo()
        dg()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim tgbarang As String
        tgbarang = Format(Now, "yyyy-MM-dd H:m:s")

        If Val(TextBox8.Text) >= Val(TextBox3.Text) Then
            MsgBox("Kapasitas Kelompok Barang Penuh, Pilih yang lain !!!")
        Else
            If Val(TextBox5.Text) < Val(TextBox4.Text) Then
                MsgBox("Harga Jual harus lebih besar dari Harga Awal")
                TextBox5.Focus()
            Else
                Try
                    If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or ComboBox1.Text = "" Then
                        MsgBox("Data Harus Terisi Semua !!!", vbCritical, "Informasi")
                    Else
                        cmd = New MySqlCommand("insert into tb_barang values ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "','" & ComboBox1.Text & "','" & tgbarang & "')", con)
                        cmd.ExecuteNonQuery()
                        tampil()
                        reset()
                        combo()
                        MsgBox("Success !!!", vbInformation, "Informasi")
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            End If

        End If
        
    End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox5.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub TextBox6_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox6.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub DataGridView3_Click(sender As Object, e As EventArgs) Handles DataGridView3.Click
        dg()
        TextBox1.Text = DataGridView3.CurrentRow.Cells(0).Value.ToString()
        TextBox2.Text = DataGridView3.CurrentRow.Cells(1).Value.ToString()

        TextBox4.Text = DataGridView3.CurrentRow.Cells(2).Value.ToString()
        TextBox5.Text = DataGridView3.CurrentRow.Cells(3).Value.ToString()
        TextBox6.Text = DataGridView3.CurrentRow.Cells(4).Value.ToString()
        ComboBox1.Text = DataGridView3.CurrentRow.Cells(5).Value.ToString()
        Button2.Enabled = True
        Button3.Enabled = True
        Button1.Enabled = False
    End Sub

    Sub dg()
        DataGridView3.Columns(0).HeaderText = "Kode Barang"
        DataGridView3.Columns(1).HeaderText = "Nama Barang"
        DataGridView3.Columns(2).HeaderText = "Harga Awal"
        DataGridView3.Columns(3).HeaderText = "Harga Jual"
        DataGridView3.Columns(4).HeaderText = "Stok"
        DataGridView3.Columns(5).HeaderText = "Kode Kelompok"
        DataGridView3.Columns(2).DefaultCellStyle.Format = "Rp ###,###"
        DataGridView3.Columns(3).DefaultCellStyle.Format = "Rp ###,###"
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Val(TextBox5.Text) < Val(TextBox4.Text) Then
            MsgBox("Harga Jual harus lebih besar dari Harga Awal")
            reset()
        Else
            If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or ComboBox1.Text = "" Then
                MsgBox("Pilih Data Terlebih Dahulu", vbInformation, "Informasi")
            Else
                cmd = New MySqlCommand("update tb_barang set kode_barang='" & TextBox1.Text & "', nama_barang='" & TextBox2.Text & "', harga_awal='" & TextBox4.Text & "', harga_jual='" & TextBox5.Text & "', stok='" & TextBox6.Text & "', kode_kelompok='" & ComboBox1.Text & "' where kode_barang='" & TextBox1.Text & "'", con)
                cmd.ExecuteNonQuery()

                tampil()
                reset()
                combo()
                MsgBox("Berhasil Di Update")
                Button1.Enabled = True
                Button2.Enabled = False
                Button3.Enabled = False
            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or ComboBox1.Text = "" Then
                MsgBox("Pilih Data Terlebih Dahulu !!!", vbInformation, "Informasi")
            Else
                cmd = New MySqlCommand("delete from tb_barang where kode_barang='" & TextBox1.Text & "'", con)
                cmd.ExecuteNonQuery()
                cmd = New MySqlCommand("delete from tb_pemasok where kode_barang='" & TextBox1.Text & "'", con)
                cmd.ExecuteNonQuery()
                tampil()
                MsgBox("Data Berhasil Dihapus")
                reset()
                combo()
                Button1.Enabled = True
                Button2.Enabled = False
                Button3.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        reset()
        combo()
        Button1.Enabled = True
        Button2.Enabled = False
        Button3.Enabled = False
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        cmd = New MySqlCommand("select * from tb_barang where kode_barang='" & TextBox7.Text & "' or nama_barang='" & TextBox7.Text & "'", con)
        baca = cmd.ExecuteReader
        If baca.Read = False Then
            MsgBox("data tidak di temukan")
        Else
            TextBox1.Text = baca("kode_barang")
            TextBox2.Text = baca("nama_barang")
            TextBox4.Text = baca("harga_awal")
            TextBox5.Text = baca("harga_jual")
            TextBox6.Text = baca("stok")
            ComboBox1.Text = baca("kode_kelompok")
        End If
    End Sub

    Private Sub TextBox7_Enter(sender As Object, e As EventArgs) Handles TextBox7.Enter
        cmd = New MySqlCommand("select * from tb_barang where kode_barang='" & TextBox1.Text & "'", con)
        baca = cmd.ExecuteReader
        If baca.Read = False Then
            MsgBox("data tidak di temukan")
        Else
            TextBox2.Text = baca("nama_barang")
            TextBox4.Text = baca("harga_jual")
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        tampil()
        combo()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles TextBox7.TextChanged
    End Sub

    Private Sub DataGridView3_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView3.CellContentClick

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        info_kel.Show()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        cmd = New MySqlCommand("SELECT * FROM tb_kel_barang WHERE kode_kelompok='" & ComboBox1.Text & "'", con)
        baca = cmd.ExecuteReader
        If baca.Read = False Then
            MsgBox("data tidak di temukan")
        Else
            TextBox3.Text = baca("kapasitas")
        End If

        
        cmd = New MySqlCommand("SELECT COUNT(kode_kelompok) FROM tb_barang WHERE kode_kelompok='" & ComboBox1.Text & "'", con)
        baca = cmd.ExecuteReader
        If baca.Read = False Then
            MsgBox("data tidak di temukan")
        Else
            TextBox8.Text = baca("COUNT(kode_kelompok)")
        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class