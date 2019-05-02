Imports MySql.Data.MySqlClient
Public Class login
    Dim cmd As MySqlCommand
    Dim baca As MySqlDataReader
    Dim sql As String

    Sub reset()
        TextBox1.Text = ""
        TextBox2.Text = ""
        ComboBox1.Text = ""
        TextBox1.Focus()
    End Sub
    Sub reset1()
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox7.Text = ""
        TextBox1.Focus()
    End Sub
    Sub kode()
        cmd = New MySqlCommand("select count(*) from tb_user", con)
        Dim rs As Integer
        rs = cmd.ExecuteScalar

        TextBox3.Text = "PG" & rs & ""

    End Sub


    Private Sub login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Items.Add("Admin")
        ComboBox1.Items.Add("Kasir")
        ComboBox2.Items.Add("Kasir")
        con()

        kode()
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Panel1.Visible = True
        TextBox4.Focus()
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        Panel1.Visible = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btn_login.Click

        If ComboBox1.Text = "Admin" Then
            Try

                cmd = New MySqlCommand("SELECT * FROM tb_user WHERE username = '" & TextBox1.Text & "' and password = '" & TextBox2.Text & "' and level='" & ComboBox1.Text & "'", con)

                baca = cmd.ExecuteReader

                If baca.HasRows Then
                    MsgBox("Selamat Datang" & TextBox1.Text & "", vbInformation, "Infromasi")
                    Me.Hide()
                    menu_admin.Show()
                    reset()

                Else
                    baca.Close()
                    MsgBox("Username dan Password Salah", vbCritical, "Informasi")
                    reset()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try


        ElseIf ComboBox1.Text = "Kasir" Then

            Try
                cmd = New MySqlCommand("SELECT * FROM tb_user WHERE username = '" & TextBox1.Text & "' and password = '" & TextBox2.Text & "' and level='" & ComboBox1.Text & "'", con)

                baca = cmd.ExecuteReader

                If baca.HasRows Then
                    MsgBox("Selamat Datang'" & TextBox1.Text & "'", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Informasi")
                    Me.Hide()
                    transaksi.Show()
                    transaksi.kembali.Visible = False
                    transaksi.keluar.Visible = True
                    reset()
                Else
                    baca.Close()
                    MsgBox("Username dan Password Salah", vbCritical, "Informasi")
                    reset()
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        Else
            MsgBox("Username dan Password Salah !!!", vbCritical, "Informasi")
            reset()
        End If
    End Sub

    Private Sub Label15_Click(sender As Object, e As EventArgs) Handles Label15.Click
        Application.Exit()
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            If TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox7.Text = "" Or ComboBox2.Text = "" Then
                MsgBox("Data Harus Terisi Semua !!!", vbCritical, "Informasi")
                reset1()
                TextBox3.Focus()

            Else
                cmd = New MySqlCommand("INSERT INTO tb_user VALUES ('" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox7.Text & "','" & ComboBox2.Text & "')", con)
                cmd.ExecuteNonQuery()

                MsgBox("Berhasil", vbInformation, "Infromasi")
                Panel1.Visible = False
                reset1()
                kode()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class
