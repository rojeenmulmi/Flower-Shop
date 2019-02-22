'Name : Rojeen Mulmi
'Date : 3/30/2016
'Class : ISC 185-101
'Purpose of  Program : Flower Shop inventory
Public Class reports
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

    'Event 2
    'generate inventory report
    Private Sub btnList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnList.Click
        Refresh_load()
        Dim generateQuery = From item In items
                          Let department = item.ProductNumber.department
                          Let itemNumber = item.ProductNumber.itemNmber
                          Let descriptionProduct = item.ProductDescription
                          Let available = item.Available
                          Let retailprice = item.RetailPrice
                          Order By department, itemNumber
                          Let result = department & "-" & itemNumber & " " & descriptionProduct & ": " & available & " @ " & retailprice.ToString("n2")
                          Select result

        lstOutput.Items.Clear()
        lstOutput.Items.Add("Inventory List by Departments")
        lstOutput.Items.Add(" ")
        
                For Each result In generateQuery
                    lstOutput.Items.Add(result)
                Next



    End Sub

    'Event 3
    'generate the profit
    Private Sub btnGenerateProfit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerateProfit.Click
        Refresh_load()
        Dim generateprofitQuery = From item In items
                                  Let profit = totalprofit(item.WsalePrice, item.RetailPrice, item.Available)
                                  Order By item.ProductDescription
                                  Let result = item.ProductNumber.department & "-" & item.ProductNumber.itemNmber & " " & item.ProductDescription & ": " & profit.ToString("c2")
                                  Select result

        lstOutput.Items.Clear()
        lstOutput.Items.Add("Projected Profits")
        lstOutput.Items.Add(" ")
        For Each result In generateprofitQuery
            lstOutput.Items.Add(result)
        Next
        'taotal profit
        lstOutput.Items.Add(" ")
        Dim total As Double
        For i As Integer = 0 To items.Count - 1
            total = total + totalprofit(items(i).WsalePrice, items(i).RetailPrice, items(i).Available)
        Next
        lstOutput.Items.Add("Total Projected Profit " & total.ToString("c2"))
    End Sub
    ' function for total profit
    Private Function totalprofit(ByVal WsalePrice As Double, ByVal Retailprice As Double, ByVal Available As Integer) As Double
        Return (Retailprice - WsalePrice) * Available
    End Function

    'Event 4: Generate reorder list
    Private Sub btnReorder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReorder.Click
        Refresh_load()
        Dim reorderQuery = From item In items
                           Where item.Available < item.ReOrder
                           Let result = item.ProductNumber.department & "-" & item.ProductNumber.itemNmber & " " & item.ProductDescription & " " & item.Available
                           Select result

        lstOutput.Items.Clear()
        lstOutput.Items.Add("ReOrder Report")
        lstOutput.Items.Add(" ")
        For Each result In reorderQuery
            lstOutput.Items.Add(result)
        Next
    End Sub

    'Event 5: Apply sale prices
    Private Sub btnSalesPrices_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalesPrices.Click
        Refresh_load()
        lstOutput.Items.Clear()
        lstOutput.Items.Add("Price Reductions for " & Today.Date)
        lstOutput.Items.Add(" ")
        Dim days As Integer
        For i As Integer = 0 To items.Count - 1
            days = Today.DayOfYear - DateTime.Parse(items(i).PurchasedDate).DayOfYear
            If days > 30 Then
                lstOutput.Items.Add("Price Changes for items " & items(i).ProductDescription & ": " & "From " &
                                    items(i).RetailPrice.ToString("c2") & " to " & (items(i).RetailPrice * 0.8).ToString("c2"))
            ElseIf days > 60 Then
                lstOutput.Items.Add(items(i).RetailPrice * 0.5)
            End If
        Next
    End Sub

    'Event 6: update a file save it in new file
    Private Sub btnWrite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWrite.Click
        Refresh_load()
        Dim strarray(items.Count - 1) As String
        For i As Integer = 0 To items.Count - 1
            Dim days As Integer = Today.DayOfYear - DateTime.Parse(items(i).PurchasedDate).DayOfYear
            If days > 30 Then
                strarray(i) = items(i).ProductNumber.department & "-" & items(i).ProductNumber.itemNmber & "," & items(i).ProductDescription & "," & Today.Date & "," &
                              items(i).WsalePrice.ToString("n2") & "," & (items(i).RetailPrice * 0.8).ToString("n2") & "," & items(i).ReOrder & "," & items(i).Available
            ElseIf days > 60 Then
                strarray(i) = items(i).ProductNumber.department & "-" & items(i).ProductNumber.itemNmber & "," & items(i).ProductDescription & "," & Today.Date & "," &
                    items(i).WsalePrice.ToString("n2") & "," & (items(i).RetailPrice * 0.5).ToString("n2") & "," & items(i).ReOrder & "," & items(i).Available
            Else
                strarray(i) = items(i).ProductNumber.department & "-" & items(i).ProductNumber.itemNmber & "," & items(i).ProductDescription & "," & items(i).PurchasedDate & "," &
                    items(i).WsalePrice.ToString("n2") & "," & items(i).RetailPrice.ToString("n2") & "," & items(i).ReOrder & "," & items(i).Available
            End If
        Next
        Dim newname As String
        newname = "items" & Today.ToString("yyyy-MM-dd") & ".txt"
        IO.File.WriteAllLines(newname, strarray.ToList)
        MessageBox.Show("File has been updated")
    End Sub

   
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Structure vendors
        Dim Vnumber As Integer
        Dim Vname As String
        Dim Vadd As String
        Dim Vcity As String
    End Structure

    Dim Avendors() As vendors
    Private Sub btnVendor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVendor.Click
        Dim lines() As String = IO.File.ReadAllLines("vendor.dat")
        ReDim items(lines.Count - 1)
        Dim data(3) As String

        Dim line As String
        For i As Integer = 0 To lines.Count - 1
            line = lines(i)
            data = line.Split(","c)

            Avendors(i).Vnumber = CInt(data(0))
            Avendors(i).Vname = data(1)
            Avendors(i).Vadd = data(2)
            Avendors(i).Vcity = data(3)
            
        Next
        Dim generateQuery = From vendor In Avendors
                         Let number = vendor.Vnumber
                         Let name = vendor.Vname
                         Let address = vendor.Vadd
                         Let city = vendor.Vcity
                         Order By name, address, city, number
                         Let result = name & "," & address & ", " & city & ", " & number
                         Select result

        lstOutput.Items.Clear()
        lstOutput.Items.Add("Vendor list")
        lstOutput.Items.Add(" ")

        For Each result In generateQuery
            lstOutput.Items.Add(result)
        Next


    End Sub
End Class

