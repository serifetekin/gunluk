<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Yonetim.Master" AutoEventWireup="true" CodeBehind="Kullanici.aspx.cs" Inherits="GUNLUK.admin.Kullanici" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style1 {
        width: 100%;
    }
    .auto-style4 {
        width: 149px;
    }
    .auto-style5 {
        margin-top: 0px;
        margin-bottom: 0px;
    }
    .auto-style6 {
        width: 149px;
        height: 24px;
    }
    .auto-style7 {
        height: 24px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="pnlListe" runat="server">
        <table cellspacing="0" class="auto-style1">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Kullanıcı Adı:"></asp:Label>
                    <asp:TextBox ID="txtAra" runat="server"></asp:TextBox>
                    <asp:Button ID="Button1" runat="server" Text="Ara" Height="26px" OnClick="Button1_Click" Width="35px" />
                    <asp:Button ID="Button2" runat="server" Text="Yeni" OnClick="Button2_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" AllowPaging="True" CssClass="auto-style5" DataKeyNames="KULLANICI_REFNO" OnPageIndexChanging="GridView1_PageIndexChanging" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" PageSize="5">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:CommandField HeaderText="Seç" ShowSelectButton="True" />
                            <asp:BoundField DataField="KULLANICI_REFNO" HeaderText="Kullanıcı Refno" />
                            <asp:BoundField DataField="KULLANICI_ADI" HeaderText="Kullanıcı Adı" />
                            <asp:BoundField DataField="DURUMU" HeaderText="Durumu" />
                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnlKayit" runat="server" Visible="False">
        <table cellspacing="0" class="auto-style1">
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="Label2" runat="server" Text="Kullanıcı Refno"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtKULLANICI_REFNO" runat="server" MaxLength="20" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="Label3" runat="server" Text="Kullanıcı Adı"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtKULLANICI_ADI" runat="server" MaxLength="20"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtKULLANICI_ADI" ErrorMessage="Kullanıcı Adı Giriniz" ValidationGroup="KayitFormu"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="Label4" runat="server" Text="Parola"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPAROLA" runat="server" MaxLength="20"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPAROLA" ErrorMessage="Parola Giriniz" ValidationGroup="KayitFormu"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">
                    <asp:Label runat="server" Text="Durumu"></asp:Label>
                </td>
                <td class="auto-style7">
                    <asp:DropDownList ID="ddlDURUMU" runat="server">
                        <asp:ListItem Selected="True" Value="True">Aktif</asp:ListItem>
                        <asp:ListItem Value="False">Pasif</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td>
                    <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Kaydet" ValidationGroup="KayitFormu" />
                    <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Vazgeç" />
                    <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" OnClientClick="return confirm(&quot;Kayit Silinsin Mi?&quot;)" Text="Sil" />
                </td>
            </tr>
        </table>
</asp:Panel>
</asp:Content>
