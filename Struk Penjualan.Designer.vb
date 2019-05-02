<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Struk_Penjualan
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.view_transaksiBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataSetstruk = New AppKoprasi_cbt_produktif.DataSetstruk()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.Btn_Cari = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        CType(Me.view_transaksiBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSetstruk, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'view_transaksiBindingSource
        '
        Me.view_transaksiBindingSource.DataMember = "view_transaksi"
        Me.view_transaksiBindingSource.DataSource = Me.DataSetstruk
        '
        'DataSetstruk
        '
        Me.DataSetstruk.DataSetName = "DataSetstruk"
        Me.DataSetstruk.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        ReportDataSource1.Name = "DataSetstruk"
        ReportDataSource1.Value = Me.view_transaksiBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "AppKoprasi_cbt_produktif.Report2.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(-1, 60)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(646, 422)
        Me.ReportViewer1.TabIndex = 0
        '
        'Btn_Cari
        '
        Me.Btn_Cari.Location = New System.Drawing.Point(544, 12)
        Me.Btn_Cari.Name = "Btn_Cari"
        Me.Btn_Cari.Size = New System.Drawing.Size(89, 28)
        Me.Btn_Cari.TabIndex = 2
        Me.Btn_Cari.Text = "Show"
        Me.Btn_Cari.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBox1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(324, 12)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(214, 25)
        Me.ComboBox1.TabIndex = 73
        '
        'Struk_Penjualan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(644, 482)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Btn_Cari)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "Struk_Penjualan"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Struk_Penjualan"
        CType(Me.view_transaksiBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSetstruk, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents Btn_Cari As System.Windows.Forms.Button
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents view_transaksiBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DataSetstruk As AppKoprasi_cbt_produktif.DataSetstruk
End Class
