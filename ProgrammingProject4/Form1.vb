'Rojeen Mulmi
'j00242551
Public Class Vendors

    Private Sub Vendors_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click, ExitToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub btnInventory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInventory.Click, InventoryToolStripMenuItem.Click
        inventory.ShowDialog()
    End Sub

    Private Sub btnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReport.Click, ReportToolStripMenuItem.Click
        reports.ShowDialog()

    End Sub

    Private Sub btnVendor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVendor.Click, VendorToolStripMenuItem.Click
        vendor.ShowDialog()

    End Sub
End Class
