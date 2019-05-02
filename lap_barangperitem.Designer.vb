<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class lap_barangperitem
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
        Me.tb_barangBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataSetlapbarang = New AppKoprasi_cbt_produktif.DataSetlapbarang()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.searchbarang = New System.Windows.Forms.TextBox()
        Me.tampilbarang = New System.Windows.Forms.Button()
        CType(Me.tb_barangBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSetlapbarang, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tb_barangBindingSource
        '
        Me.tb_barangBindingSource.DataMember = "tb_barang"
        Me.tb_barangBindingSource.DataSource = Me.DataSetlapbarang
        '
        'DataSetlapbarang
        '
        Me.DataSetlapbarang.DataSetName = "DataSetlapbarang"
        Me.DataSetlapbarang.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        ReportDataSource1.Name = "DataSetlapbarang"
        ReportDataSource1.Value = Me.tb_barangBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "AppKoprasi_cbt_produktif.Report1.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 65)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(909, 504)
        Me.ReportViewer1.TabIndex = 0
        '
        'searchbarang
        '
        Me.searchbarang.Location = New System.Drawing.Point(542, 30)
        Me.searchbarang.Multiline = True
        Me.searchbarang.Name = "searchbarang"
        Me.searchbarang.Size = New System.Drawing.Size(283, 29)
        Me.searchbarang.TabIndex = 1
        '
        'tampilbarang
        '
        Me.tampilbarang.Location = New System.Drawing.Point(831, 30)
        Me.tampilbarang.Name = "tampilbarang"
        Me.tampilbarang.Size = New System.Drawing.Size(75, 29)
        Me.tampilbarang.TabIndex = 2
        Me.tampilbarang.Text = "Tampil"
        Me.tampilbarang.UseVisualStyleBackColor = True
        '
        'lap_barangperitem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(921, 695)
        Me.Controls.Add(Me.tampilbarang)
        Me.Controls.Add(Me.searchbarang)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "lap_barangperitem"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "lap_barangperitem"
        CType(Me.tb_barangBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSetlapbarang, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents tb_barangBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DataSetlapbarang As AppKoprasi_cbt_produktif.DataSetlapbarang
    Friend WithEvents searchbarang As System.Windows.Forms.TextBox
    Friend WithEvents tampilbarang As System.Windows.Forms.Button
End Class
