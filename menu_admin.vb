Public Class menu_admin

    Private Sub menu_admin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel2.Controls.Clear()
        home.MdiParent = Me
        Me.Panel2.Controls.Add(home.Panel1)
        home.Show()
    End Sub

   
    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        Panel2.Controls.Clear()
        home.MdiParent = Me
        Me.Panel2.Controls.Add(home.Panel1)
        home.Show()
    End Sub

    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click
        Panel2.Controls.Clear()
        input_barang.MdiParent = Me
        Me.Panel2.Controls.Add(input_barang.Panel1)
        input_barang.Show()
    End Sub

    Private Sub BunifuFlatButton3_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton3.Click
        Panel2.Controls.Clear()
        input_pemasok.MdiParent = Me
        Me.Panel2.Controls.Add(input_pemasok.Panel1)
        input_pemasok.Show()
    End Sub

    Private Sub BunifuFlatButton4_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton4.Click
        Panel2.Controls.Clear()
        input_rak.MdiParent = Me
        Me.Panel2.Controls.Add(input_rak.Panel1)
        input_rak.Show()
    End Sub

    Private Sub BunifuFlatButton5_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton5.Click
        Me.Hide()
        transaksi.Show()
        transaksi.keluar.Visible = False
        transaksi.kembali.Visible = True
    End Sub

    Private Sub BunifuFlatButton6_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton6.Click
        Panel2.Controls.Clear()
        laporan.MdiParent = Me
        Me.Panel2.Controls.Add(laporan.Panel1)
        laporan.Show()
    End Sub

    Private Sub Label38_Click(sender As Object, e As EventArgs) Handles Label38.Click
        Application.Exit()
    End Sub

    Private Sub BunifuGradientPanel1_Paint(sender As Object, e As PaintEventArgs) Handles BunifuGradientPanel1.Paint

    End Sub

    Private Sub BunifuFlatButton7_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton7.Click
        Me.Hide()
        log_out.Show()
    End Sub
End Class