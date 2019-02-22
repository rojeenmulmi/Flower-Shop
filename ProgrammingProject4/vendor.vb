Public Class vendor
    Function DataOk() As Boolean
        'check empty space
        Try
            If txtAddress.Text = " " Or txtCity.Text = " " Or txtName.Text = " " Or
                txtNumber.Text = "" Then
            End If
        Catch ex As Exception
            MessageBox.Show("All the fiels shoud be provided")
            Return False
        End Try
        'check - seperation
        
        Try
            Dim numericCheck As Integer
            numericCheck = CInt(txtNumber.Text)
        Catch ex As InvalidCastException
            MessageBox.Show("Should be numeric")
            txtNumber.Text = ""
            txtNumber.Focus()
            Return False
        End Try

       
        Return True
    End Function
End Class