<%@ Page Title="" Language="C#" MasterPageFile="~/AnaSayfa.Master" AutoEventWireup="true" CodeBehind="iletisim.aspx.cs" Inherits="GUNLUK.iletişim" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 156px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="iletisimformu">
        İLETİŞİM FORMU
    </div>
    
    <table cellspacing="0" class="auto-style1">
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label1" runat="server" Text="Adı Soyadı"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtADI_SOYADI" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label2" runat="server" Text="Mail"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtMAIL" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label3" runat="server" Text="Konu"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtKONU" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label4" runat="server" Text="Mesaj"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtMESAJ" runat="server" Rows="10" TextMode="MultiLine" Width="100%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Mail Gönder" />
                <asp:Label ID="lblSONUC" runat="server" Text="lblSonuc"></asp:Label>
            </td>
        </tr>
    </table>

</asp:Content>
