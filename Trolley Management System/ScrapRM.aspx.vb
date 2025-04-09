Imports System.IO
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Web
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports System.Collections.Generic


Public Class ScrapRM
    Inherits System.Web.UI.Page

    Public Connstr As String = ConfigurationManager.ConnectionStrings("DBCS").ToString
    Dim cn As New SqlConnection(Connstr)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.Session("Userid") Is Nothing Then
            Response.Redirect("~/Default.aspx")
        End If

        If Not IsPostBack Then

            Label1.Visible = False
            GetItemData()
            GetSMTData()

        End If
    End Sub



    Sub GetItemData()

        cn.Open()

        Dim cmd As New SqlCommand("select Itemcode from Itemcode", cn)
        Dim sdt As New SqlDataAdapter(cmd)
        Dim dt As New DataTable()
        sdt.Fill(dt)

        cn.Close()

        Me.DropDownList1.DataSource = dt
        Dim i As Integer
        For i = 0 To dt.Rows.Count - 1
            Me.DropDownList1.Items.Add(dt.Rows(i)(0).ToString)
        Next i

    End Sub


    Sub GetSMTData()

        cn.Open()

        Dim cmd As New SqlCommand("select SmtLine from SmtLine", cn)
        Dim sdt As New SqlDataAdapter(cmd)
        Dim dt As New DataTable()
        sdt.Fill(dt)

        cn.Close()

        Me.DropDownList2.DataSource = dt
        Dim i As Integer
        For i = 0 To dt.Rows.Count - 1
            Me.DropDownList2.Items.Add(dt.Rows(i)(0).ToString)
        Next i

    End Sub


End Class