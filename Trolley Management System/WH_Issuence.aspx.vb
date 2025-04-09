
Imports System.IO
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Web
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports System.Collections.Generic


Public Class WH_Issuence
    Inherits System.Web.UI.Page


    Sub get_uploadNo()

        Dim Connstr As String = ConfigurationManager.ConnectionStrings("DBCS").ToString
        Dim cn As New SqlConnection(Connstr)

        Dim cmd As New SqlCommand("select distinct(uploadNo) from Pickliststatus where status1<>'Closed' order by UploadNo asc", cn)

        Dim adaptor As New SqlDataAdapter(cmd)
        Dim table1 As New DataTable
        adaptor.Fill(table1)

        Me.DropDownList1.DataSource = table1
        Dim i As Integer
        For i = 0 To table1.Rows.Count - 1
            Me.DropDownList1.Items.Add(table1.Rows(i)(0).ToString)
        Next i

    End Sub


    'Sub get_TrolleyNo()

    '    Dim Connstr As String = ConfigurationManager.ConnectionStrings("DBCS").ToString
    '    Dim cn As New SqlConnection(Connstr)
    '    Dim cmd As New SqlCommand("select distinct(TrolleyNo) from currentTI where trolleylocation='warehouse' order by TrolleyNo asc", cn)

    '    Dim adaptor As New SqlDataAdapter(cmd)
    '    Dim table2 As New DataTable
    '    adaptor.Fill(table2)

    '    Me.DropDownList1.DataSource = table2
    '    Dim i As Integer
    '    For i = 0 To table2.Rows.Count - 1
    '        Me.DropDownList2.Items.Add(table2.Rows(i)(0).ToString)
    '    Next i


    'End Sub





    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.Session("Userid") Is Nothing Then
            Response.Redirect("~/Default.aspx")
        End If



        If Not IsPostBack Then

            Me.DropDownList1.Items.Clear()

            Me.DropDownList1.Items.Add("----Upload No----")
            Call get_uploadNo()


            'Me.DropDownList1.SelectedItem.Text = "----Upload No----"

            'Me.DropDownList2.Enabled = False
            'Me.Button2.Enabled = False
            Me.DropDownList3.Enabled = False
            Me.Button3.Enabled = False
            Me.TextBox1.Enabled = False
            Me.TextBox2.Enabled = False

            Me.TextBox3.Enabled = False

            Me.Button4.Enabled = False
            Me.Label3.Visible = False
            Me.Label4.Text = ""

        End If

    End Sub


    '---------------------------------------------------------------------------------------------

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        'If Me.DropDownList2.SelectedItem.Text = "----Warehouse Area----" Then

        '    Dim msg As String = "Please select Warehouse Area First"
        '    Dim script = String.Format("alert('{0}');", msg)
        '    ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", script, True)

        '    Exit Sub

        'Else
        '-----disable---
        Me.DropDownList1.Enabled = False
        Me.Button1.Enabled = False
        Me.DropDownList3.Enabled = True
        Me.Button3.Enabled = True

        'End If




        '----------------------------------------------------------------------------------

        'Dim userrole As String = Me.Session("Roles").ToString.ToUpper
        'If userrole.Contains("WHUSER") Or userrole.Contains("ADMIN") Then



        '    If Me.DropDownList1.SelectedItem.Text = "----Upload No----" Then

        '        Dim msg As String = "Please select Uploadno First"
        '        Dim script = String.Format("alert('{0}');", msg)
        '        ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", script, True)

        '        Exit Sub
        '    Else

        '        Me.DropDownList2.Items.Clear()

        '        Me.DropDownList2.Items.Add("----Warehouse Area----")
        '        Call get_TrolleyNo()
        '        '-----disable---
        '        Me.DropDownList1.Enabled = False
        '        Me.Button1.Enabled = False
        '        Me.DropDownList2.Enabled = True
        '        Me.Button2.Enabled = True


        '    End If

        'Else

        '    Dim msg As String = "You do not have rights to this page"
        '    Dim script = String.Format("alert('{0}');", msg)
        '    ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", script, True)

        'End If

    End Sub

    'Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click


    '    If Me.DropDownList2.SelectedItem.Text = "----Warehouse Area----" Then

    '        Dim msg As String = "Please select Warehouse Area First"
    '        Dim script = String.Format("alert('{0}');", msg)
    '        ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", script, True)

    '        Exit Sub

    '    Else
    '        '-----disable---
    '        Me.DropDownList2.Enabled = False
    '        Me.Button2.Enabled = False
    '        Me.DropDownList3.Enabled = True
    '        Me.Button3.Enabled = True

    '    End If


    'End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click


        If Me.DropDownList3.SelectedItem.Text = "----Scan Type----" Then

            Dim msg As String = "Please select Scan Type First"
            Dim script = String.Format("alert('{0}');", msg)
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", script, True)

            Exit Sub

        Else

            If Me.DropDownList3.SelectedItem.Text = "QR Code" Then

                Me.DropDownList3.Enabled = False
                Me.Button3.Enabled = False
                '--------------------------

                Me.Label1.Text = "Scan QR Code"
                Me.Label2.Enabled = False
                Me.TextBox1.Enabled = True
                Me.Button4.Enabled = True

                'MsgBox("data need to be inserted now for QR code")

            Else
                Me.DropDownList3.Enabled = False
                Me.Button3.Enabled = False
                Me.TextBox1.Enabled = True
                Me.TextBox2.Enabled = True
                Me.Button4.Enabled = True

                'MsgBox("data need to be inserted now for Manual/barcode")

            End If

        End If


    End Sub

    Protected Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        Dim ItemUID As String
        Dim itmcode As String
        Dim Qty As Decimal
        Dim size As String
        Dim ExpiryDate As String

        '------======================== Get itemUID/itemcode/quantity/ExpiryDate basis upon Barcode and QR code =================------, 

        If Me.DropDownList3.SelectedItem.Text = "QR Code" And Me.TextBox1.Text = String.Empty Then

            Dim msg As String = "Please Scan QR code"
            Dim script = String.Format("alert('{0}');", msg)
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", script, True)

            Exit Sub


        ElseIf Me.DropDownList3.SelectedItem.Text = "QR Code" And Me.TextBox1.Text <> String.Empty Then

            Dim str As String = Me.TextBox1.Text

            'ItemUID = str.Split("|")(0)
            'itmcode = str.Split("|")(1)
            'Qty = str.Split("|")(3)
            'ExpiryDate = str.Split("|")(7)


            ItemUID = str.Split("/")(4).ToString() ' Handling Unit ( Lot number)
            itmcode = str.Split("/")(0).ToString() ' Handling Unit/Lot Number partcode (Raw Material Partcode) 
            Qty = Convert.ToInt32(str.Split("/")(1))
            ExpiryDate = str.Split("/")(7).ToString()




        Else

            If Me.TextBox1.Text = String.Empty Or Me.TextBox2.Text = String.Empty Then

                Dim msg As String = "Please fill Barcode and Quantity"
                Dim script = String.Format("alert('{0}');", msg)
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", script, True)

                Exit Sub

            Else

                '------------------=------------

                itmcode = Me.TextBox1.Text
                Qty = Me.TextBox2.Text

                'MsgBox(itmcode & "__" & Qty)

            End If


        End If




        '-----**********************Size validations basis of selected itemcode from "Itemcode_Size" Table ***********************----

        Dim Connstr As String = ConfigurationManager.ConnectionStrings("DBCS").ToString
        Dim cn As New SqlConnection(Connstr)

        Dim cmd1 As New SqlCommand("select * from itemcode_size where itemcode='" & itmcode & "'", cn)

        Dim adaptor As New SqlDataAdapter(cmd1)
        Dim table1 As New DataTable
        adaptor.Fill(table1)

        If table1.Rows.Count <= 0 Then

            size = "No Row Found"

            Dim msg As String = "Item code is not mapped with bin type."
            Dim script = String.Format("alert('{0}');", msg)
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", script, True)

            TextBox1.Text = String.Empty
            TextBox2.Text = String.Empty
            TextBox1.Focus()
            Exit Sub


        Else

            size = table1.Rows(0)(1).ToString()

        End If




        '=========================Checking if Item code and Item UID is the same in QR Code Scanning=================================

        Dim cmd30 As New SqlCommand("select * from Handling_Unit where Handling_Unitpartcode='" & itmcode & "'", cn)
        Dim adaptor30 As New SqlDataAdapter(cmd30)
        Dim table30 As New DataTable
        adaptor30.Fill(table30)

        If table30.Rows.Count <= 0 Then


        Else

            '--------
            Dim cmd3 As New SqlCommand("Select * from TrolleyLaser where  Item='" & itmcode & "' and ItemUID='" & ItemUID & "' and ItemUID is not NULL and transaction_type='Inv_In'", cn)
            Dim adaptor3 As New SqlDataAdapter(cmd3)
            Dim table3 As New DataTable
            adaptor3.Fill(table3)

            If table3.Rows.Count > 0 And Me.DropDownList3.SelectedItem.Text = "QR Code" Then

                Dim msg As String = "Item code with duplicate UID code is not allowed."
                Dim script = String.Format("alert('{0}');", msg)
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", script, True)


                Me.TextBox1.Text = String.Empty
                Me.TextBox2.Text = String.Empty
                Me.TextBox1.Focus()
                Me.Label4.Text = ""

                Exit Sub

            End If

        End If






        '-================================check wheather partcode is in GRN List or not=================================

        Dim qry_a As String = "select distinct uploadno,item, sum(qty) Sum from Picklist where Item='" & itmcode & "' and UploadNo='" & DropDownList1.SelectedItem.Text & "' and Status1='QualityEnd'  group by UploadNo,item "

        Dim cmd_a As New SqlCommand(qry_a, cn)
        Dim adaptor_a As New SqlDataAdapter(cmd_a)
        Dim table_a As New DataTable
        adaptor_a.Fill(table_a)

        If table_a.Rows.Count <= 0 Then

            Dim msg As String = "Item code not found in given upload number or IQC not Done."
            Dim script = String.Format("alert('{0}');", msg)
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", script, True)


            Me.TextBox1.Text = String.Empty
            Me.TextBox2.Text = String.Empty

            Me.TextBox1.Focus()
            Me.Label4.Text = ""

            Exit Sub


        Else

            Dim sum_qty, already_entered_qty As Integer

            sum_qty = table_a.Rows(0)(2)


            Dim qry_b As String = "select distinct item, uploadno, sum(qty) Sum from TrolleyLaser where item='" & itmcode & "' and Uploadno='" & DropDownList1.SelectedItem.Text & "' and transaction_type='Inv_In' group by item, uploadno"

            Dim cmd_b As New SqlCommand(qry_b, cn)
            Dim adaptor_b As New SqlDataAdapter(cmd_b)
            Dim table_b As New DataTable
            adaptor_b.Fill(table_b)

            If table_b.Rows.Count <= 0 Then
                already_entered_qty = 0
            Else
                already_entered_qty = table_b.Rows(0)(2)
            End If


            If already_entered_qty + Qty > sum_qty Then

                Dim msg As String = "Upload number " & DropDownList1.SelectedItem.Text & " and Partnumber " & itmcode & " is already having " & already_entered_qty & " qty and current input Quantity " & Qty & " is more then GRN Quantity " & sum_qty
                Dim script = String.Format("alert('{0}');", msg)
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", script, True)


                Me.TextBox1.Text = String.Empty
                Me.TextBox2.Text = String.Empty
                Me.TextBox1.Focus()
                Me.Label4.Text = ""

                Exit Sub

            End If


        End If




        '============================Checking Expiry date again itemcode==============================

        Dim cmd100 As New SqlCommand("select * from expiry_itemmaterial where expiry_itemmaterial='" & itmcode & "'", cn)
        Dim adaptor100 As New SqlDataAdapter(cmd100)
        Dim table100 As New DataTable
        adaptor100.Fill(table100)

        Dim exp As Date

        If table100.Rows.Count <= 0 Then

        Else



            If ExpiryDate = "" Then

                Dim msg As String = "Expiry date is mandatory for this item, please check the labels"
                Dim script = String.Format("alert('{0}');", msg)
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", script, True)

                TextBox1.Text = String.Empty
                Exit Sub

            Else



                'ExpiryDate = Mid(ExpiryDate, 7, 2) & "-" & Mid(ExpiryDate, 5, 2) & "-" & Mid(ExpiryDate, 1, 4)

                ExpiryDate = Mid(ExpiryDate, 1, 4) & "-" & Mid(ExpiryDate, 5, 2) & "-" & Mid(ExpiryDate, 7, 2)

                exp = Convert.ToDateTime(ExpiryDate).ToString("yyyy-MM-dd")


                'MsgBox(exp)
                'Exit Sub


            End If

        End If



        '----------------

        Dim qry_c As String = "select * from view_CurrentTI where CurrentItem='" & itmcode & "' and size='" & size & "' order by TrolleyIndex asc, Rackindex asc, slotNo asc"

        Dim cmd_c As New SqlCommand(qry_c, cn)
        Dim adaptor_c As New SqlDataAdapter(cmd_c)
        Dim table_c As New DataTable
        adaptor_c.Fill(table_c)

        Dim Uniquid As String

        If table_c.Rows.Count <= 0 Then

            Dim qry As String = "select Top 1 * from CurrentTI where  size='" & size & "' and Currentitem is null and Qty is null order by TrolleyIndex asc, Rackindex asc, slotNo asc"

            Dim cmd2 As New SqlCommand(qry, cn)
            Dim adaptor1 As New SqlDataAdapter(cmd2)
            Dim table2 As New DataTable
            adaptor1.Fill(table2)

            If table2.Rows.Count <= 0 Then

                Dim msg As String = "no Bin space available to keep this material"
                Dim script = String.Format("alert('{0}');", msg)
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", script, True)


                Me.TextBox1.Text = String.Empty
                Me.TextBox2.Text = String.Empty
                Me.TextBox1.Focus()
                Me.Label4.Text = ""

                Exit Sub


            Else

                Uniquid = table2.Rows(0)(0)

                Me.Label3.Text = Uniquid ' this line need to be comment in fill button code
                Me.Label3.Visible = True

                Me.TextBox3.Enabled = True
                TextBox3.Focus()
                TextBox1.Enabled = False
                TextBox2.Enabled = False

                Me.Label4.Text = ""

                Exit Sub

            End If


        Else


            For i As Integer = 0 To table_c.Rows.Count - 1

                Dim current_bin_count, current_bin_capacity As Integer

                current_bin_count = table_c.Rows(i)("Qty")
                current_bin_capacity = table_c.Rows(i)("bin_capacity")

                If current_bin_count + Qty <= current_bin_capacity Then

                    Uniquid = table_c.Rows(i)(0)

                    Me.Label3.Text = Uniquid ' this line need to be comment in fill button code
                    Me.Label3.Visible = True

                    Me.TextBox3.Enabled = True
                    TextBox3.Focus()
                    TextBox1.Enabled = False
                    TextBox2.Enabled = False

                    Me.Label4.Text = ""

                    Exit Sub

                End If

            Next





            Dim qry As String = "select Top 1 * from CurrentTI where  size='" & size & "' and Currentitem is null and Qty is null order by TrolleyIndex asc, Rackindex asc, slotNo asc"

            Dim cmd2 As New SqlCommand(qry, cn)
            Dim adaptor1 As New SqlDataAdapter(cmd2)
            Dim table2 As New DataTable
            adaptor1.Fill(table2)

            If table2.Rows.Count <= 0 Then

                Dim msg As String = "no Bin space available to keep this material"
                Dim script = String.Format("alert('{0}');", msg)
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", script, True)


                Me.TextBox1.Text = String.Empty
                Me.TextBox2.Text = String.Empty
                Me.TextBox1.Focus()
                Me.Label4.Text = ""

                Exit Sub


            Else

                Uniquid = table2.Rows(0)(0)

                Me.Label3.Text = Uniquid ' this line need to be comment in fill button code
                Me.Label3.Visible = True

                Me.TextBox3.Enabled = True
                TextBox3.Focus()
                TextBox1.Enabled = False
                TextBox2.Enabled = False

                Me.Label4.Text = ""

            End If


        End If







        '-------------------------------Getting Uniqeid where material need to be assign from CurrentTI Table -------------------------------

        'Dim qry As String = "select Top 1 * from CurrentTI where  size='" & size & "' and Currentitem is null and Qty is null order by Rackindex asc, slotNo asc"

        'Dim cmd2 As New SqlCommand(qry, cn)
        'Dim adaptor1 As New SqlDataAdapter(cmd2)
        'Dim table2 As New DataTable
        'adaptor1.Fill(table2)

        'Dim Uniquid As String = table2.Rows(0)(0)

        'Me.Label3.Text = Uniquid
        'Me.Label3.Visible = True

        'Me.TextBox3.Enabled = True
        'TextBox3.Focus()
        'TextBox1.Enabled = False

        'Me.Label4.Text = ""

        '----------------Matching uniqueno with the trolley Slots--------------------





        ''---------------------------------update SQL Table- currentTI basis of Uniqueid ----------------------------------------------

        'If Me.TextBox1.Text <> "" Then

        '    Dim cmd3 As New SqlCommand("update CurrentTI set currentitem='" & itmcode & "',qty='" & Qty & "', Lastfilledby='" & Session("userid") & "',lastfilled_dt=getdate(),Uploadno='" & Me.DropDownList1.SelectedItem.Text & "' where uniqueid='" & Uniquid & "'", cn)
        '    cn.Open()
        '    cmd3.ExecuteNonQuery()
        '    cn.Close()


        '    '--------------------------------inserting data in Trolleylaser for history purpose-------------------------------------------

        '    Dim updatetype As String = "Warehouse issuence"
        '    Dim trolleyno As String = Uniquid.Split("-")(0)
        '    Dim Rackno As String = Uniquid.Split("-")(1)
        '    Dim Slotno As String = Uniquid.Split("-")(2)

        '    Dim cmd4 As New SqlCommand("insert into TrolleyLaser values(cast(getdate() as date), getdate(),'Warehouse Issuence','" & Uniquid & "','" & trolleyno & "','" & Rackno & "','" & Slotno & "','" & size & "','" & itmcode & "','" & Qty & "','" & Session("userid") & "',getdate(), NULL, NULL, 'Warehouse','" & Me.DropDownList1.SelectedItem.Text & "')", cn)

        '    cn.Open()
        '    cmd4.ExecuteNonQuery()
        '    cn.Close()

        '    '-----------------------------------------updating status in PicklistStatus Table---------------------------------------

        '    Dim cmd5 As New SqlCommand("update PicklistStatus set Status1='Inprocess' where Uploadno='" & Me.DropDownList1.SelectedItem.Text & "'", cn)
        '    cn.Open()
        '    cmd5.ExecuteNonQuery()
        '    cn.Close()


        '    Me.Label3.Visible = True

        '    Me.TextBox1.Text = String.Empty
        '    Me.TextBox2.Text = String.Empty


        'End If


    End Sub

    Protected Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If Me.Label3.Text = Me.TextBox3.Text Then


            Call insertData_After_succesfulil_validations()

        Else
            Me.Label4.Text = "FAIL - system suggested bin and scanned bin is not matching"
            Me.Label4.BackColor = System.Drawing.Color.Black
            Me.Label4.ForeColor = System.Drawing.Color.Red

            Me.TextBox3.Text = String.Empty
            Me.TextBox3.Focus()


            Exit Sub
        End If
    End Sub



    Sub insertData_After_succesfulil_validations()


        Dim ItemUID As String
        Dim itmcode As String
        Dim Qty As Decimal
        Dim size As String
        Dim ExpiryDate As String
        '-----------------------

        If Me.DropDownList3.SelectedItem.Text = "QR Code" And Me.TextBox1.Text = String.Empty Then

            Dim msg As String = "Please Scan QR code"
            Dim script = String.Format("alert('{0}');", msg)
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", script, True)

            Exit Sub


        ElseIf Me.DropDownList3.SelectedItem.Text = "QR Code" And Me.TextBox1.Text <> String.Empty Then

            Dim str As String = Me.TextBox1.Text

            'ItemUID = str.Split("|")(0)
            'itmcode = str.Split("|")(1)
            'Qty = str.Split("|")(3)
            'ExpiryDate = str.Split("|")(7)


            ItemUID = str.Split("/")(4).ToString() ' Handling Unit ( Lot number)
            itmcode = str.Split("/")(0).ToString() 'Handling Unit/Lot Number partcode (Raw Material Partcode) 
            Qty = Convert.ToInt32(str.Split("/")(1))
            ExpiryDate = str.Split("/")(7).ToString() '------expirydate date squence on lable may be change this need to validate after---------

            '------------------------------------------------------------------


        Else

            If Me.TextBox1.Text = String.Empty Or Me.TextBox2.Text = String.Empty Then

                Dim msg As String = "Please fill Barcode and Quantity"
                Dim script = String.Format("alert('{0}');", msg)
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", script, True)

                Exit Sub

            Else

                '------------------=------------

                itmcode = Me.TextBox1.Text
                Qty = Me.TextBox2.Text


                'MsgBox(itmcode & "__" & Qty)

            End If


        End If


        '--------------------------------Size validations basis of selected itemcode from "Itemcode_Size" Table -------------------------------

        Dim Connstr As String = ConfigurationManager.ConnectionStrings("DBCS").ToString
        Dim cn As New SqlConnection(Connstr)

        Dim cmd1 As New SqlCommand("select * from itemcode_size where itemcode='" & itmcode & "'", cn)

        Dim adaptor As New SqlDataAdapter(cmd1)
        Dim table1 As New DataTable
        adaptor.Fill(table1)



        If table1.Rows.Count <= 0 Then

            size = "No Row Found"

            Dim msg As String = "Item code is not mapped with bin type."
            Dim script = String.Format("alert('{0}');", msg)
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", script, True)

            TextBox1.Text = String.Empty
            TextBox2.Text = String.Empty
            TextBox1.Focus()
            Exit Sub


        Else

            size = table1.Rows(0)(1).ToString()

        End If

        '--------****************************************************--------

        '--------------------------Checking if Item code and Item UID is the same in QR Code Scanning----------------------------------------------

        Dim cmd30 As New SqlCommand("select * from Handling_Unit where Handling_Unitpartcode='" & itmcode & "'", cn)
        Dim adaptor30 As New SqlDataAdapter(cmd30)
        Dim table30 As New DataTable
        adaptor30.Fill(table30)



        If table30.Rows.Count <= 0 Then


        Else

            '--------
            Dim cmd3 As New SqlCommand("Select * from TrolleyLaser where  Item='" & itmcode & "' and ItemUID='" & ItemUID & "' and ItemUID is not NULL and transaction_type='Inv_In'", cn)
            Dim adaptor3 As New SqlDataAdapter(cmd3)
            Dim table3 As New DataTable
            adaptor3.Fill(table3)

            If table3.Rows.Count > 0 And Me.DropDownList3.SelectedItem.Text = "QR Code" Then

                Dim msg As String = "Item code with duplicate UID code is not allowed."
                Dim script = String.Format("alert('{0}');", msg)
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", script, True)


                Me.TextBox1.Text = String.Empty
                Me.TextBox2.Text = String.Empty
                Me.TextBox1.Focus()
                Me.Label4.Text = ""

                Exit Sub

            End If

        End If


        '------------------------check wheather partcode is in GRN List or not-------------------------


        Dim qry_a As String = "select distinct uploadno,item, sum(qty) Sum from Picklist where Item='" & itmcode & "' and UploadNo='" & DropDownList1.SelectedItem.Text & "'  group by UploadNo,item "

        Dim cmd_a As New SqlCommand(qry_a, cn)
        Dim adaptor_a As New SqlDataAdapter(cmd_a)
        Dim table_a As New DataTable
        adaptor_a.Fill(table_a)

        If table_a.Rows.Count <= 0 Then

            Dim msg As String = "Item code not found in given upload number."
            Dim script = String.Format("alert('{0}');", msg)
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", script, True)


            Me.TextBox1.Text = String.Empty
            Me.TextBox2.Text = String.Empty

            Me.TextBox1.Focus()
            Me.Label4.Text = ""

            Exit Sub


        Else

            Dim sum_qty, already_entered_qty As Integer

            sum_qty = table_a.Rows(0)(2)


            Dim qry_b As String = "select distinct item, uploadno, sum(qty) Sum from TrolleyLaser where item='" & itmcode & "' and Uploadno='" & DropDownList1.SelectedItem.Text & "' and transaction_type='Inv_In' group by item, uploadno"

            Dim cmd_b As New SqlCommand(qry_b, cn)
            Dim adaptor_b As New SqlDataAdapter(cmd_b)
            Dim table_b As New DataTable
            adaptor_b.Fill(table_b)

            If table_b.Rows.Count <= 0 Then
                already_entered_qty = 0
            Else
                already_entered_qty = table_b.Rows(0)(2)
            End If


            If already_entered_qty + Qty > sum_qty Then

                Dim msg As String = "Upload number " & DropDownList1.SelectedItem.Text & " and Partnumber " & itmcode & " is already having " & already_entered_qty & " qty and current input Quantity " & Qty & " is more then GRN Quantity " & sum_qty
                Dim script = String.Format("alert('{0}');", msg)
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", script, True)


                Me.TextBox1.Text = String.Empty
                Me.TextBox2.Text = String.Empty
                Me.TextBox1.Focus()
                Me.Label4.Text = ""

                Exit Sub

            End If


        End If




        '-------------------------End partcode grn list-----------------------------------------------


        Dim qry_c As String = "select * from view_CurrentTI where CurrentItem='" & itmcode & "' and size='" & size & "' order by TrolleyIndex asc, Rackindex asc, slotNo asc"

        Dim cmd_c As New SqlCommand(qry_c, cn)
        Dim adaptor_c As New SqlDataAdapter(cmd_c)
        Dim table_c As New DataTable
        adaptor_c.Fill(table_c)

        Dim Uniquid As String

        If table_c.Rows.Count <= 0 Then

            Dim qry As String = "select Top 1 * from CurrentTI where  size='" & size & "' and Currentitem is null and Qty is null order by TrolleyIndex asc, Rackindex asc, slotNo asc"

            Dim cmd2 As New SqlCommand(qry, cn)
            Dim adaptor1 As New SqlDataAdapter(cmd2)
            Dim table2 As New DataTable
            adaptor1.Fill(table2)

            If table2.Rows.Count <= 0 Then

                Dim msg As String = "no Bin space available to keep this material"
                Dim script = String.Format("alert('{0}');", msg)
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", script, True)


                Me.TextBox1.Text = String.Empty
                Me.TextBox2.Text = String.Empty
                Me.TextBox1.Focus()
                Me.Label4.Text = ""

                Exit Sub


            Else

                Uniquid = table2.Rows(0)(0)

                'Me.Label3.Text = Uniquid ' this line need to be comment in fill button code
                Me.Label3.Visible = True

                Me.TextBox3.Enabled = True
                TextBox3.Focus()
                TextBox1.Enabled = False
                TextBox2.Enabled = False

                Me.Label4.Text = ""



            End If


        Else


            For i As Integer = 0 To table_c.Rows.Count - 1

                Dim current_bin_count, current_bin_capacity As Integer

                current_bin_count = table_c.Rows(i)("Qty")
                current_bin_capacity = table_c.Rows(i)("bin_capacity")



                If current_bin_count + Qty <= current_bin_capacity Then


                    Uniquid = table_c.Rows(i)(0)

                    'Me.Label3.Text = Uniquid ' this line need to be comment in fill button code
                    Me.Label3.Visible = True

                    Me.TextBox3.Enabled = True
                    TextBox3.Focus()
                    TextBox1.Enabled = False
                    TextBox2.Enabled = False

                    Me.Label4.Text = ""


                    Exit For

                End If

            Next




            Dim qry As String = "select Top 1 * from CurrentTI where  size='" & size & "' and Currentitem is null and Qty is null order by TrolleyIndex asc, Rackindex asc, slotNo asc"

            Dim cmd2 As New SqlCommand(qry, cn)
            Dim adaptor1 As New SqlDataAdapter(cmd2)
            Dim table2 As New DataTable
            adaptor1.Fill(table2)

            '----marker

            If Uniquid = Nothing Then

                If table2.Rows.Count <= 0 Then

                    Dim msg As String = "no Bin space available to keep this material"
                    Dim script = String.Format("alert('{0}');", msg)
                    ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", script, True)


                    Me.TextBox1.Text = String.Empty
                    Me.TextBox2.Text = String.Empty
                    Me.TextBox1.Focus()
                    Me.Label4.Text = ""

                    Exit Sub


                Else

                    Uniquid = table2.Rows(0)(0)

                End If

            Else
                    Uniquid = Uniquid
                End If


                'Me.Label3.Text = Uniquid ' this line need to be comment in fill button code
                Me.Label3.Visible = True

                Me.TextBox3.Enabled = True
                TextBox3.Focus()
                TextBox1.Enabled = False
                TextBox2.Enabled = False

                Me.Label4.Text = ""

            End If



        'marker


        '--------****************************************************--------

        If Uniquid <> Label3.Text Then


            Dim qry_d As String = "select * from CurrentTI where Uniqueid='" & Label3.Text & "'"
            Dim cmd_d As New SqlCommand(qry_d, cn)
            Dim adaptor_d As New SqlDataAdapter(cmd_d)
            Dim table_d As New DataTable
            adaptor_d.Fill(table_d)

            Dim ex_item, ex_qty, ex_filledby As String
            Dim ex_datetime As DateTime

            ex_item = table_d.Rows(0)("Currentitem")
            ex_qty = table_d.Rows(0)("Qty")
            ex_filledby = table_d.Rows(0)("LastFilledBy")
            ex_datetime = table_d.Rows(0)("LastFilled_DT")


            Dim msg As String = "bin has been occupied while you are passing the entry by " & ex_filledby & " for item " & ex_item & " with Quantity " & ex_qty & " at " & ex_datetime
            Dim script = String.Format("alert('{0}');", msg)
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", script, True)


            TextBox1.Enabled = True
            TextBox2.Enabled = True
            TextBox3.Enabled = False
            Button5.Enabled = False
            Button4.Enabled = True

            Me.TextBox1.Text = String.Empty
            Me.TextBox2.Text = String.Empty
            Me.TextBox1.Focus()
            Me.Label4.Text = ""

            Exit Sub


        Else

            Dim qry_d As String = "select * from CurrentTI where Uniqueid='" & Uniquid & "'"
            Dim cmd_d As New SqlCommand(qry_d, cn)
            Dim adaptor_d As New SqlDataAdapter(cmd_d)
            Dim table_d As New DataTable
            adaptor_d.Fill(table_d)

            Dim ex_item, ex_filledby As String
            Dim ex_qty, qty_to_be_updated As Integer
            Dim ex_datetime As DateTime

            Try
                ex_qty = table_d.Rows(0)("Qty")
            Catch ex As Exception
                ex_qty = 0
            End Try


            qty_to_be_updated = ex_qty + Qty


            Dim exp As Date

            '--------------------------------updating data in current TI-------------------------------------------

            Dim cmd100 As New SqlCommand("select * from expiry_itemmaterial where expiry_itemmaterial='" & itmcode & "'", cn)
            Dim adaptor100 As New SqlDataAdapter(cmd100)
            Dim table100 As New DataTable
            adaptor100.Fill(table100)

            If table100.Rows.Count <= 0 Then



            Else



                If ExpiryDate = "" Then

                    Dim msg As String = "Expiry date is mandatory for this item, please check the labels"
                    Dim script = String.Format("alert('{0}');", msg)
                    ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", script, True)

                    Exit Sub

                Else

                    ExpiryDate = Mid(ExpiryDate, 1, 4) & "-" & Mid(ExpiryDate, 5, 2) & "-" & Mid(ExpiryDate, 7, 2)

                    exp = Convert.ToDateTime(ExpiryDate).ToString("yyyy-MM-dd")

                End If

            End If


            'Dim cmd_e As New SqlCommand("update CurrentTI set ItemUID='" & ItemUID & "',currentitem='" & itmcode & "',qty='" & qty_to_be_updated & "', Lastfilledby='" & Session("userid") & "',lastfilled_dt=getdate(),Uploadno='" & Me.DropDownList1.SelectedItem.Text & "' where uniqueid='" & Uniquid & "'", cn)
            Dim cmd_e As New SqlCommand("update CurrentTI set expiry_date='" & exp.ToString("yyyy-MM-dd") & "', ItemUID='" & ItemUID & "',currentitem='" & itmcode & "',qty='" & qty_to_be_updated & "', Lastfilledby='" & Session("userid") & "',lastfilled_dt=getdate(),Uploadno='" & Me.DropDownList1.SelectedItem.Text & "' where uniqueid='" & Uniquid & "'", cn)

            cn.Open()
            cmd_e.ExecuteNonQuery()
            cn.Close()



            '--------------------------------inserting data in Trolleylaser for history purpose-------------------------------------------

            'Dim updatetype As String = "Warehouse issuence"
            Dim trolleyno As String = Uniquid.Split("-")(0)
            Dim Rackno As String = Uniquid.Split("-")(1)
            Dim Slotno As String = Uniquid.Split("-")(2)

            'Dim cmd4 As New SqlCommand("insert into TrolleyLaser values(cast(getdate() as date), getdate(),'Inv_In','" & Uniquid & "','" & trolleyno & "','" & Rackno & "','" & Slotno & "','" & size & "','" & itmcode & "','" & Qty & "','" & Session("userid") & "',getdate(), NULL, NULL, 'Warehouse','" & Me.DropDownList1.SelectedItem.Text & "','" & ItemUID & "','Inv_In')", cn)
            Dim cmd4 As New SqlCommand("insert into TrolleyLaser values(cast(getdate() as date), getdate(),'Inv_In','" & Uniquid & "','" & trolleyno & "','" & Rackno & "','" & Slotno & "','" & size & "','" & itmcode & "','" & Qty & "','" & Session("userid") & "',getdate(), NULL, NULL, 'Warehouse','" & Me.DropDownList1.SelectedItem.Text & "','" & ItemUID & "','Inv_In','" & exp.ToString("yyyy-MM-dd") & "')", cn)

            cn.Open()
            cmd4.ExecuteNonQuery()
            cn.Close()


            '-----------------------------------------updating status in PicklistStatus Table---------------------------------------

            Dim cmd5 As New SqlCommand("update PicklistStatus set Status1='Inprocess' where Uploadno='" & Me.DropDownList1.SelectedItem.Text & "'", cn)
            cn.Open()
            cmd5.ExecuteNonQuery()
            cn.Close()

            Label3.Text = ""
            Label3.Visible = False
            Label4.Text = "PASS"

            Me.Label4.BackColor = System.Drawing.Color.Yellow
            Me.Label4.ForeColor = System.Drawing.Color.Black


            Me.TextBox1.Text = String.Empty
            Me.TextBox2.Text = String.Empty


            Me.TextBox3.Text = String.Empty

            Me.TextBox1.Enabled = True
            Me.TextBox2.Enabled = True
            Me.TextBox1.Focus()
            Me.TextBox3.Enabled = False


        End If








    End Sub

    Protected Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

        'If Me.TextBox1.Text <> String.Empty And Me.DropDownList3.SelectedItem.Text = "QR Code" Then

        '    Text

        'End If



    End Sub

    Protected Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

        'If Me.TextBox1.Text <> String.Empty And Me.TextBox2.Text <> String.Empty And Me.DropDownList3.SelectedItem.Text = "Barcode / Manual" Then

        '    Button4_Click(sender, e)

        'End If
    End Sub

    Protected Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        'If Me.TextBox1.Text <> String.Empty Then

        '    Button5_Click(sender, e)

        'End If

    End Sub

    Protected Sub DropDownList3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList3.SelectedIndexChanged

    End Sub
End Class