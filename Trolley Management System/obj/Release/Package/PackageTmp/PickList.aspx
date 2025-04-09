<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="PickList.aspx.vb" Inherits="Trolley_Management_System.PickList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 110px;
        }
        .auto-style3 {
            width: 13px;
        }
        .auto-style4 {
            width: 270px;
        }
        .auto-style5 {
            width: 110px;
            height: 26px;
        }
        .auto-style6 {
            width: 13px;
            height: 26px;
        }
        .auto-style7 {
            width: 270px;
            height: 26px;
        }
        .auto-style8 {
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <table class="auto-style1">
            <tr>
                <td class="auto-style5">GRN No</td>
                <td class="auto-style6">:</td>
                <td class="auto-style7">
                    <asp:TextBox ID="TextBox1" runat="server" Width="179px"></asp:TextBox>
                </td>
                <td class="auto-style8"></td>
                <td class="auto-style8"></td>
            </tr>
            <tr>
                <td class="auto-style2">Vendor Invoice No</td>
                <td class="auto-style3">:</td>
                <td class="auto-style4">
                    <asp:TextBox ID="TextBox2" runat="server" Width="179px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">Select File</td>
                <td class="auto-style3">:</td>
                <td class="auto-style4">
                    <asp:FileUpload ID="FileUpload1" runat="server" Width="275px" />
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style4">
                    <asp:Button ID="Button1" runat="server" Text="Upload" Width="97px" />
                </td>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </form>
</asp:Content>
