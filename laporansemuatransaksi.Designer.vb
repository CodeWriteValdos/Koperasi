<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class laporansemuatransaksi
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
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.DataSetstruk = New AppKoprasi_cbt_produktif.DataSetstruk()
        Me.view_transaksiBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.DataSetstruk, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.view_transaksiBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource2.Name = "DataSetstruk"
        ReportDataSource2.Value = Me.view_transaksiBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "AppKoprasi_cbt_produktif.Report3.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(921, 695)
        Me.ReportViewer1.TabIndex = 0
        '
        'DataSetstruk
        '
        Me.DataSetstruk.DataSetName = "DataSetstruk"
        Me.DataSetstruk.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'view_transaksiBindingSource
        '
        Me.view_transaksiBindingSource.DataMember = "view_transaksi"
        Me.view_transaksiBindingSource.DataSource = Me.DataSetstruk
        '
        'laporansemuatransaksi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(921, 695)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "laporansemuatransaksi"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "laporansemuatransaksi"
        CType(Me.DataSetstruk, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.view_transaksiBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents view_transaksiBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DataSetstruk As AppKoprasi_cbt_produktif.DataSetstruk
End Class
