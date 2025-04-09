<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="WH_Issuence.aspx.vb" Inherits="Trolley_Management_System.WH_Issuence" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
  
    
    
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style4 {
            width: 138px;
            height: 23px;
        }
        .auto-style5 {
            width: 240px;
            height: 23px;
        }
        .auto-style6 {
            height: 23px;
        }
        .auto-style7 {
            width: 138px;
        }
        .auto-style8 {
            width: 240px;
        }
        .auto-style9 {
            width: 138px;
            height: 5px;
        }
        .auto-style10 {
            width: 240px;
            height: 5px;
        }
        .auto-style11 {
            height: 5px;
        }
        .auto-style12 {
            width: 138px;
            height: 30px;
        }
        .auto-style13 {
            width: 240px;
            height: 30px;
        }
        .auto-style14 {
            height: 30px;
        }
        .auto-style15 {
            width: 14px;
        }
        .auto-style16 {
            width: 14px;
            height: 23px;
        }
        .auto-style17 {
            width: 14px;
            height: 30px;
        }
        .auto-style18 {
            width: 14px;
            height: 5px;
        }
        .auto-style19 {
            width: 138px;
            height: 28px;
        }
        .auto-style20 {
            width: 14px;
            height: 28px;
        }
        .auto-style21 {
            width: 240px;
            height: 28px;
        }
        .auto-style22 {
            height: 28px;
        }
        .auto-style23 {
            width: 138px;
            height: 16px;
        }
        .auto-style24 {
            width: 14px;
            height: 16px;
        }
        .auto-style25 {
            width: 240px;
            height: 16px;
        }
        .auto-style26 {
            height: 16px;
        }
        .auto-style31 {
            width: 138px;
            height: 20px;
        }
        .auto-style32 {
            width: 14px;
            height: 20px;
        }
        .auto-style33 {
            width: 240px;
            height: 20px;
        }
        .auto-style34 {
            height: 20px;
        }
        .auto-style35 {
            width: 138px;
            height: 11px;
        }
        .auto-style36 {
            width: 14px;
            height: 11px;
        }
        .auto-style37 {
            width: 240px;
            height: 11px;
        }
        .auto-style38 {
            height: 11px;
        }
        .auto-style39 {
            font-size: small;
        }
        .auto-style40 {
            width: 231px;
            height: 23px;
        }
        .auto-style41 {
            width: 231px;
        }
        .auto-style42 {
            width: 231px;
            height: 28px;
        }
        .auto-style43 {
            width: 231px;
            height: 11px;
        }
        .auto-style44 {
            width: 231px;
            height: 30px;
        }
        .auto-style45 {
            width: 231px;
            height: 20px;
        }
        .auto-style46 {
            width: 231px;
            height: 5px;
        }
        .auto-style47 {
            width: 231px;
            height: 16px;
        }
        .auto-style52 {
            width: 138px;
            height: 25px;
        }
        .auto-style53 {
            width: 14px;
            height: 25px;
        }
        .auto-style54 {
            width: 240px;
            height: 25px;
        }
        .auto-style55 {
            width: 231px;
            height: 25px;
        }
        .auto-style56 {
            height: 25px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <table class="auto-style1">
        <tr>
            <td class="auto-style4">Upload No</td>
            <td class="auto-style16">
                :</td>
            <td class="auto-style5">
                <asp:DropDownList ID="DropDownList1" runat="server" Height="17px" Width="170px">
                </asp:DropDownList>
            </td>
            <td class="auto-style40"></td>
            <td class="auto-style6"></td>
            <td class="auto-style6"></td>
        </tr>
        <tr>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style15">
                &nbsp;</td>
            <td class="auto-style8">
                <asp:Button ID="Button1" runat="server" Text="Get WH Area" Width="168px" CssClass="auto-style39" />
            </td>
            <td rowspan="2" class="auto-style41">
                <asp:Label ID="Label3" runat="server" Font-Size="XX-Large" Text="Label" CssClass="auto-style39"></asp:Label>
            </td>
            <td rowspan="3">
                <asp:Label ID="Label4" runat="server" Font-Size="XX-Large" Text="Label" CssClass="auto-style39"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style8">
            </td>
            <td></td>
        </tr>
        <tr>
            <td class="auto-style19">Scan Type</td>
            <td class="auto-style20">
                :</td>
            <td class="auto-style21">
                <asp:DropDownList ID="DropDownList3" runat="server" Height="17px" Width="170px">
                    <asp:ListItem>----Scan Type----</asp:ListItem>
                    <asp:ListItem>QR Code</asp:ListItem>
                    <asp:ListItem>Barcode / Manual</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="auto-style42">
                <asp:TextBox ID="TextBox3" runat="server" Width="165px" AutoPostBack="true"></asp:TextBox>
            </td>
            <td class="auto-style22"></td>
        </tr>
        <tr>
            <td class="auto-style35">&nbsp;</td>
            <td class="auto-style36">
                &nbsp;</td>
            <td class="auto-style37">
                <asp:Button ID="Button3" runat="server" Text="Confirm Scanning process" Width="170px" />
            </td>
            <td class="auto-style43">
                <asp:Button ID="Button5" runat="server" Text="Fill" Width="105px" />
            </td>
            <td class="auto-style38"></td>
            <td class="auto-style38"></td>
        </tr>
        <tr>
            <td class="auto-style12"></td>
            <td class="auto-style17">
                </td>
            <td class="auto-style13">
                &nbsp;</td>
            <td class="auto-style44"></td>
            <td class="auto-style14"></td>
            <td class="auto-style14"></td>
        </tr>
        <tr>
            <td class="auto-style31">
                <asp:Label ID="Label1" runat="server" Text="QR_Material_Code"></asp:Label>
            </td>
            <td class="auto-style32">
                :</td>
            <td class="auto-style33">
                <asp:TextBox ID="TextBox1" runat="server" Width="163px" AutoPostBack="true"></asp:TextBox>
            </td>
            <td class="auto-style45"></td>
            <td class="auto-style34"></td>
            <td class="auto-style34"></td>
        </tr>
        <tr>
            <td class="auto-style9">
                <asp:Label ID="Label2" runat="server" Text="Quantity"></asp:Label>
            </td>
            <td class="auto-style18">
                :</td>
            <td class="auto-style10">
                <asp:TextBox ID="TextBox2" runat="server" Width="163px" AutoPostBack="true"></asp:TextBox>
            </td>
            <td class="auto-style46"></td>
            <td class="auto-style11"></td>
            <td class="auto-style11"></td>
        </tr>
        <tr>
            <td class="auto-style19"></td>
            <td class="auto-style20">
                </td>
            <td class="auto-style21">
                <asp:Button ID="Button4" runat="server" Text="Show Slot" Width="90px" />
            </td>
            <td class="auto-style42"></td>
            <td class="auto-style22"></td>
            <td class="auto-style22"></td>
        </tr>
        <tr>
            <td class="auto-style52"></td>
            <td class="auto-style53"></td>
            <td class="auto-style54"></td>
            <td class="auto-style55"></td>
            <td class="auto-style56"></td>
            <td class="auto-style56"></td>
        </tr>
        <tr>
            <td class="auto-style4"></td>
            <td class="auto-style16"></td>
            <td class="auto-style5">
                &nbsp;</td>
            <td class="auto-style40"></td>
            <td class="auto-style6"></td>
            <td class="auto-style6"></td>
        </tr>
        <tr>
            <td class="auto-style23"></td>
            <td class="auto-style24"></td>
            <td class="auto-style25"></td>
            <td class="auto-style47"></td>
            <td class="auto-style26"></td>
            <td class="auto-style26"></td>
        </tr>
        <tr>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style15">&nbsp;</td>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style41">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    </form>
</asp:Content>
