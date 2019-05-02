Imports MySql.Data.MySqlClient
Public Class input_pemasok
    Dim cmd As MySqlCommand
    Dim adapter As MySqlDataAdapter
    Dim baca As MySqlDataReader
    Dim ds As DataSet
    Sub reset()
        TextBox9.Text = ""
        kd.Text = ""
        TextBox11.Text = ""
        TextBox13.Text = ""
        TextBox14.Text = ""
        TextBox15.Text = ""
        TextBox16.Text = ""
        ComboBox2.Text = ""
        TextBox9.Focus()
        ComboBox2.Items.Clear()
        Button5.Enabled = True
        Button7.Enabled = False
    End Sub
    Sub hilang()

        TextBox13.Visible = False
        TextBox14.Visible = False
        TextBox15.Visible = False
        ComboBox2.Visible = False

        Label27.Visible = False
        Label28.Visible = False
        Label29.Visible = False
        Label31.Visible = False

        RectangleShape20.Visible = False
        RectangleShape21.Visible = False
        RectangleShape22.Visible = False
        RectangleShape23.Visible = False
    End Sub
    Sub tampilText()

        TextBox13.Visible = True
        TextBox14.Visible = True
        TextBox15.Visible = True
        ComboBox2.Visible = True

        Label27.Visible = True
        Label28.Visible = True
        Label29.Visible = True
        Label31.Visible = True
        RectangleShape20.Visible = True
        RectangleShape21.Visible = True
        RectangleShape22.Visible = True
        RectangleShape23.Visible = True
    End Sub
    Sub kode()
        cmd = New MySqlCommand("select count(*) from tb_pemasok", con)
        Dim rs As Integer
        rs = cmd.ExecuteScalar

        TextBox8.Text = "PS" & rs & ""

    End Sub
    Sub tampilpemasok()
        adapter = New MySqlDataAdapter("select id_pemasok,nama_pemasok,kode_barang,nama_barang,harga_awal,harga_jual,stok,kode_kelompok, tgl_input from tb_pemasok", con)
        ds = New DataSet
        adapter.Fill(ds, "tb_pemasok")
        DataGridView4.DataSource = ds.Tables("tb_pemasok")

    End Sub
    Sub tampil()
        cmd = New MySqlCommand("select * from tb_pemasok", con)
        cmd.ExecuteNonQuery()
        adapter = New MySqlDataAdapter(cmd)
        Dim table As New DataTable()
        adapter.Fill(table)
        DataGridView4.DataSource = table

    End Sub
    Sub combo()

        adapter = New MySqlDataAdapter("select * from tb_kel_barang order by kode_kelompok asc", con)
        ds = New DataSet
        ds.Clear()
        adapter.Fill(ds, "tb_kel_barang")
        cmd = New MySqlCommand("select * from tb_kel_barang", con)
        baca = cmd.ExecuteReader
        Do While baca.Read
            ComboBox2.Items.Add(baca.Item(0))
        Loop

    End Sub

    Private Sub input_pemasok_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tampilpemasok()
        combo()
        kode()
        Button7.Enabled = False
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim tgbarang As String
        tgbarang = Format(Now, "yyyy-MM-dd H:m:s")
        If Val(TextBox1.Text) >= Val(TextBox3.Text) Then
            MsgBox("Kapasitas Kelompok Barang Penuh, Pilih yang lain !!!")
        Else
            If Val(TextBox14.Text) < Val(TextBox13.Text) Then
                MsgBox("Harga Jual harus lebih besar dari Harga Awal", vbInformation, "Informasi")
                TextBox14.Focus()
            Else
                Try
                    If TextBox8.Text = "" Or TextBox9.Text = "" Or kd.Text = "" Or TextBox11.Text = "" Or TextBox13.Text = "" Or TextBox14.Text = "" Or TextBox15.Text = "" Or ComboBox2.Text = "" Then
                        MsgBox("Data Harus Terisi Semua !!!", vbCritical, "Informasi")
                    Else
                        cmd = New MySqlCommand("insert into tb_pemasok values('" & TextBox8.Text & "','" & TextBox9.Text & "','" & kd.Text & "','" & TextBox11.Text & "','" & TextBox13.Text & "','" & TextBox14.Text & "','" & TextBox15.Text & "','" & ComboBox2.Text & "','" & tgbarang & "')", con)
                        cmd.ExecuteNonQuery()
                        cmd = New MySqlCommand("insert into tb_barang values('" & kd.Text & "','" & TextBox11.Text & "','" & TextBox13.Text & "','" & TextBox14.Text & "','" & TextBox15.Text & "','" & ComboBox2.Text & "','" & tgbarang & "')", con)
                        cmd.ExecuteNonQuery()
                        reset()
                        tampilpemasok()
                        MsgBox("Tersimpan")
                        combo()
                        kode()
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            End If
        End If

    End Sub

    Private Sub tampil_pemasok_Click(sender As Object, e As EventArgs) Handles tampil_pemasok.Click
        tampilpemasok()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Try
            If TextBox8.Text = "" Or TextBox9.Text = "" Or kd.Text = "" Or TextBox11.Text = "" Then
                MsgBox("Pilih Data Terlebih dahulu")
            Else
                cmd = New MySqlCommand("delete from tb_pemasok where id_pemasok='" & TextBox8.Text & "'", con)
                cmd.ExecuteNonQuery()
                cmd = New MySqlCommand("delete from tb_barang where kode_barang='" & kd.Text & "'", con)
                cmd.ExecuteNonQuery()
                MsgBox("data berhasil di hapus")
                tampilpemasok()
                reset()
                tampilText()
                combo()
                kode()
                Button5.Enabled = True
            End If            
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub DataGridView4_Click(sender As Object, e As EventArgs) Handles DataGridView4.Click
        TextBox8.Text = DataGridView4.CurrentRow.Cells(0).Value.ToString()
        TextBox9.Text = DataGridView4.CurrentRow.Cells(1).Value.ToString()
        kd.Text = DataGridView4.CurrentRow.Cells(2).Value.ToString()
        TextBox11.Text = DataGridView4.CurrentRow.Cells(3).Value.ToString()

        Button7.Enabled = True
        Button5.Enabled = False
        hilang()
    End Sub

    Sub dg()
        DataGridView4.Columns(0).HeaderText = "Kode Pemasok"
        DataGridView4.Columns(1).HeaderText = "Nama Pemasok"
        DataGridView4.Columns(2).HeaderText = "Kode Barang"
        DataGridView4.Columns(3).HeaderText = "Nama Barang"
        DataGridView4.Columns(4).HeaderText = "Harga Awal"
        DataGridView4.Columns(5).HeaderText = "Harga Jual"
        DataGridView4.Columns(6).HeaderText = "Stok"
        DataGridView4.Columns(7).HeaderText = "Kode Kelompok"
        DataGridView4.Columns(8).HeaderText = "Tanggal Input"
        DataGridView4.Columns(4).DefaultCellStyle.Format = "Rp ###,###"
        DataGridView4.Columns(5).DefaultCellStyle.Format = "Rp ###,###"
    End Sub
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        reset()
        tampilText()
    End Sub

    Private Sub TextBox13_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox13.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub TextBox14_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox14.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub TextBox15_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox15.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        cmd = New MySqlCommand("select * from tb_pemasok where id_pemasok='" & TextBox16.Text & "' Or nama_pemasok='" & TextBox16.Text & "' or kode_barang='" & TextBox16.Text & "' or nama_barang='" & TextBox16.Text & "'", con)
        baca = cmd.ExecuteReader
        If baca.Read = False Then
            MsgBox("Data Tidak di Temukan !!!", vbCritical, "Infromasi")
        Else
            hilang()
            Button7.Enabled = True
            Button5.Enabled = False
            TextBox8.Text = baca("id_pemasok")
            TextBox9.Text = baca("nama_pemasok")
            kd.Text = baca("kode_barang")
            TextBox11.Text = baca("nama_barang")
        End If


    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        info_kel.Show()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        cmd = New MySqlCommand("SELECT * FROM tb_kel_barang WHERE kode_kelompok='" & ComboBox2.Text & "'", con)
        baca = cmd.ExecuteReader
        If baca.Read = False Then
            MsgBox("data tidak di temukan")
        Else
            TextBox3.Text = baca("kapasitas")
        End If


        cmd = New MySqlCommand("SELECT COUNT(kode_kelompok) FROM tb_barang WHERE kode_kelompok='" & ComboBox2.Text & "'", con)
        baca = cmd.ExecuteReader
        If baca.Read = False Then
            MsgBox("data tidak di temukan")
        Else
            TextBox1.Text = baca("COUNT(kode_kelompok)")
        End If
    End Sub
End Class