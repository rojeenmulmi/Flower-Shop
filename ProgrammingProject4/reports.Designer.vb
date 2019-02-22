<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class reports
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
        Me.btnWrite = New System.Windows.Forms.Button()
        Me.btnSalesPrices = New System.Windows.Forms.Button()
        Me.btnReorder = New System.Windows.Forms.Button()
        Me.btnGenerateProfit = New System.Windows.Forms.Button()
        Me.btnList = New System.Windows.Forms.Button()
        Me.lstOutput = New System.Windows.Forms.ListBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnVendor = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnWrite
        '
        Me.btnWrite.Location = New System.Drawing.Point(399, 174)
        Me.btnWrite.Name = "btnWrite"
        Me.btnWrite.Size = New System.Drawing.Size(196, 34)
        Me.btnWrite.TabIndex = 17
        Me.btnWrite.Text = "Backup File"
        Me.btnWrite.UseVisualStyleBackColor = True
        '
        'btnSalesPrices
        '
        Me.btnSalesPrices.Location = New System.Drawing.Point(399, 131)
        Me.btnSalesPrices.Name = "btnSalesPrices"
        Me.btnSalesPrices.Size = New System.Drawing.Size(196, 37)
        Me.btnSalesPrices.TabIndex = 16
        Me.btnSalesPrices.Text = "Apply Sales Prices"
        Me.btnSalesPrices.UseVisualStyleBackColor = True
        '
        'btnReorder
        '
        Me.btnReorder.Location = New System.Drawing.Point(399, 93)
        Me.btnReorder.Name = "btnReorder"
        Me.btnReorder.Size = New System.Drawing.Size(196, 32)
        Me.btnReorder.TabIndex = 15
        Me.btnReorder.Text = "Generate ReOrder List"
        Me.btnReorder.UseVisualStyleBackColor = True
        '
        'btnGenerateProfit
        '
        Me.btnGenerateProfit.Location = New System.Drawing.Point(399, 53)
        Me.btnGenerateProfit.Name = "btnGenerateProfit"
        Me.btnGenerateProfit.Size = New System.Drawing.Size(196, 34)
        Me.btnGenerateProfit.TabIndex = 14
        Me.btnGenerateProfit.Text = "Generate Profit"
        Me.btnGenerateProfit.UseVisualStyleBackColor = True
        '
        'btnList
        '
        Me.btnList.Location = New System.Drawing.Point(399, 12)
        Me.btnList.Name = "btnList"
        Me.btnList.Size = New System.Drawing.Size(196, 35)
        Me.btnList.TabIndex = 13
        Me.btnList.Text = "Inventory List"
        Me.btnList.UseVisualStyleBackColor = True
        '
        'lstOutput
        '
        Me.lstOutput.FormattingEnabled = True
        Me.lstOutput.Location = New System.Drawing.Point(12, 12)
        Me.lstOutput.Name = "lstOutput"
        Me.lstOutput.Size = New System.Drawing.Size(379, 277)
        Me.lstOutput.TabIndex = 12
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(400, 250)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(195, 39)
        Me.Button1.TabIndex = 18
        Me.Button1.Text = "Back to Main Menu"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnVendor
        '
        Me.btnVendor.Location = New System.Drawing.Point(399, 214)
        Me.btnVendor.Name = "btnVendor"
        Me.btnVendor.Size = New System.Drawing.Size(196, 34)
        Me.btnVendor.TabIndex = 19
        Me.btnVendor.Text = "Vendor List"
        Me.btnVendor.UseVisualStyleBackColor = True
        '
        'reports
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(603, 309)
        Me.Controls.Add(Me.btnVendor)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnWrite)
        Me.Controls.Add(Me.btnSalesPrices)
        Me.Controls.Add(Me.btnReorder)
        Me.Controls.Add(Me.btnGenerateProfit)
        Me.Controls.Add(Me.btnList)
        Me.Controls.Add(Me.lstOutput)
        Me.Name = "reports"
        Me.Text = "reports"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnWrite As System.Windows.Forms.Button
    Friend WithEvents btnSalesPrices As System.Windows.Forms.Button
    Friend WithEvents btnReorder As System.Windows.Forms.Button
    Friend WithEvents btnGenerateProfit As System.Windows.Forms.Button
    Friend WithEvents btnList As System.Windows.Forms.Button
    Friend WithEvents lstOutput As System.Windows.Forms.ListBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnVendor As System.Windows.Forms.Button
End Class
