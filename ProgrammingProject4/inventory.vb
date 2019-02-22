'Name : Rojeen Mulmi
'Date : 3/30/2016
'Class : ISC 185-101
'Purpose of  Program : Flower Shop inventory
Public Class inventory
    Structure fullProductNumber
        Dim department As String
        Dim itemNmber As String
    End Structure
    Structure item
        Dim ProductNumber As fullProductNumber
        Dim ProductDescription As String
        Dim PurchasedDate As String
        Dim WsalePrice, RetailPrice As Double
        Dim ReOrder, Available As Integer
    End Structure
    Dim items() As item

    'file validation
    Function fileValdation() As Boolean
        Try
            If IO.File.Exists("items.txt") = False Then
                Throw New ArgumentException
            End If
        Catch ex As Exception
            MessageBox.Show("File missing!!!")
            Return False
        End Try
        Return True

    End Function

    'sub procedure for loading
    Sub Refresh_load()
        Dim lines() As String = IO.File.ReadAllLines("items.txt")
        ReDim items(lines.Count - 1)
        Dim data(6) As String
        Dim pronumber(1) As String
        Dim line As String
        For i As Integer = 0 To lines.Count - 1
            line = lines(i)
            data = line.Split(","c)
            pronumber = data(0).Split("-"c)
            items(i).ProductNumber.department = pronumber(0)
            items(i).ProductNumber.itemNmber = pronumber(1)
            items(i).ProductDescription = data(1)
            items(i).PurchasedDate = data(2)
            items(i).WsalePrice = CDbl(data(3))
            items(i).RetailPrice = CDbl(data(4))
            items(i).ReOrder = CInt(data(5))
            items(i).Available = CInt(data(6))
        Next

    End Sub

    'form loading
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If fileValdation() Then
            Refresh_load()

        Else
            Close()
        End If
    End Sub

    

    'search for record
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim sr As IO.StreamReader = IO.File.OpenText("items.txt")
        Dim line As String
        Dim data(6) As String
        Dim foundflag As Boolean = False
        Dim inputSearch As String = txtProductNum.Text
        Dim inputName As String = txtProductName.Text
        Do Until sr.EndOfStream
            line = sr.ReadLine
            data = line.Split(","c)
            If data(0) = inputSearch Then
                txtProductName.Text = data(1)
                txtDate.Text = data(2)
                txtWholesale.Text = data(3)
                txtRetail.Text = data(4)
                txtReOrder.Text = data(5)
                txtAvailable.Text = data(6)

            ElseIf data(1) = inputName Then
                txtProductNum.Text = data(0)
                txtDate.Text = data(2)
                txtWholesale.Text = data(3)
                txtRetail.Text = data(4)
                txtReOrder.Text = data(5)
                txtAvailable.Text = data(6)
            End If
        Loop
        sr.Close()
        If foundflag = True Then
            MessageBox.Show("Cannot find")
        End If

    End Sub

    'updaating record
    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If DataOk() Then
            Dim sr As IO.StreamReader = IO.File.OpenText("items.txt")
            Dim sw As IO.StreamWriter = IO.File.CreateText("temp.txt")
            Dim line, outline As String
            Dim data(6) As String
            Dim foundflag As Boolean = False
            Dim productInput As String = txtProductNum.Text
            Dim nameInput As String = txtProductName.Text
            Do Until sr.EndOfStream
                line = sr.ReadLine
                data = line.Split(","c)
                If data(1) = nameInput Or data(0) = productInput Then
                    outline = txtProductNum.Text & "," & txtProductName.Text & "," &
                            txtDate.Text & "," & txtRetail.Text & "," & txtWholesale.Text & "," & txtReOrder.Text & "," & txtAvailable.Text
                    sw.WriteLine(outline)
                Else
                    sw.WriteLine(line)
                End If
            Loop
            sr.Close()
            sw.Close()
            IO.File.Delete("items.txt")
            IO.File.Move("temp.txt", "items.txt")
        End If
    End Sub

    'deleting record
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim sr As IO.StreamReader = IO.File.OpenText("items.txt")
        Dim sw As IO.StreamWriter = IO.File.CreateText("temp.txt")
        Dim line As String
        Dim data(6) As String
        Dim foundflag As Boolean = False
        Dim productInput As String = txtProductNum.Text
        Dim nameInput As String = txtProductName.Text
        Do Until sr.EndOfStream
            line = sr.ReadLine
            data = line.Split(","c)
            If data(1) <> nameInput Or data(0) <> productInput Then
                sw.WriteLine(line)
            Else
            End If
        Loop
        sr.Close()
        sw.Close()
        IO.File.Delete("items.txt")
        IO.File.Move("temp.txt", "items.txt")
    End Sub

    'addd a record
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If DataOk() Then
            Dim sw As IO.StreamWriter = IO.File.AppendText("items.txt")
            Dim record As String
            record = txtProductNum.Text & "," & txtProductName.Text & "," &
                        txtDate.Text & "," & txtRetail.Text & "," & txtWholesale.Text & "," & txtReOrder.Text & "," & txtAvailable.Text
            sw.WriteLine(record)
            sw.Close()
        End If
    End Sub

    'data validaation
    Function DataOk() As Boolean
        'check empty space
        Try
            If txtProductNum.Text = " " Or txtProductName.Text = " " Or txtDate.Text = " " Or
                txtRetail.Text = "" Or txtWholesale.Text = "" Or txtReOrder.Text = "" Or txtAvailable.Text = "" Then
            End If
        Catch ex As Exception
            MessageBox.Show("All the fiels shoud be provided")
            Return False
        End Try
        'check - seperation
        Try
            If CStr(txtProductNum.Text.Substring(2, 1)) <> "-" Then
            End If

        Catch ex As Exception
            MessageBox.Show("Product Number need to contain dash")
            Return False
        End Try
        'check numeric or not
        Try
            Dim numericCheck As Integer
            numericCheck = CInt(txtAvailable.Text)
        Catch ex As InvalidCastException
            MessageBox.Show("Should be numeric")
            txtAvailable.Text = ""
            txtAvailable.Focus()
            Return False
        End Try

        Try
            Dim numericCheck As Integer
            numericCheck = CInt(txtAvailable.Text)
        Catch ex As InvalidCastException
            MessageBox.Show("Should be numeric")
            txtAvailable.Text = ""
            txtAvailable.Focus()
            Return False
        End Try

        Try
            Dim numericCheck As Integer
            numericCheck = CInt(txtAvailable.Text)
        Catch ex As InvalidCastException
            MessageBox.Show("Should be numeric")
            txtAvailable.Text = ""
            txtAvailable.Focus()
            Return False
        End Try

        Try
            Dim numericCheck As Integer
            numericCheck = CInt(txtReOrder.Text)
        Catch ex As InvalidCastException
            MessageBox.Show("Should be numeric")
            txtReOrder.Text = ""
            txtReOrder.Focus()
            Return False
        End Try

        Try
            Dim numericCheck As Integer
            numericCheck = CInt(txtWholesale.Text)
        Catch ex As InvalidCastException
            MessageBox.Show("Should be numeric")
            txtWholesale.Text = ""
            txtWholesale.Focus()
            Return False
        End Try

        Try
            Dim numericCheck As Integer
            numericCheck = CInt(txtRetail.Text)
        Catch ex As InvalidCastException
            MessageBox.Show("Should be numeric")
            txtRetail.Text = ""
            txtRetail.Focus()
            Return False
        End Try
        'date validation
        Try

            Dim dt As Date = CDate(txtDate.Text)
        Catch ex As InvalidCastException
            MessageBox.Show("Enter a Valid Date")
            txtDate.Text = ""
            txtDate.Focus()
            Return False
        End Try
        Return True
    End Function

    Private Sub btnReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReturn.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
End Class

