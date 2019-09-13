<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Yonetim.Master" AutoEventWireup="true" CodeBehind="Yazi.aspx.cs" Inherits="GUNLUK.admin.Yazi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style type="text/css">
    .auto-style1 {
        width: 100%;
    }
         .auto-style2 {
             width: 150px;
         }
         .auto-style4 {
             width: 150px;
             height: 24px;
         }
         .auto-style5 {
             height: 24px;
         }
         .auto-style6 {
             width: 150px;
             height: 28px;
         }
         .auto-style7 {
             height: 28px;
         }
    </style>

    <!--ckeditor ve ckfinder klasörleri sayfayla ilişkilendirildi-->
    <script src="../ckeditor/ckeditor.js"></script>

    <script src="../ckfinder/ckfinder.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:Panel ID="pnlListe" runat="server">
        <table cellspacing="0" class="auto-style1">
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Başlık"></asp:Label>
                    <asp:TextBox ID="txtARA" runat="server"></asp:TextBox>
                    <asp:Button ID="Button1" runat="server" Text="Ara" />
                    <asp:Button ID="Button6" runat="server" Text="Yeni" />
</tr>
            <tr>
                </td>
                <td class="auto-style1">

                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" DataKeyNames="YAZI_REFNO" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AllowPaging="True" PageSize="4">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:CommandField HeaderText="Seç" ShowSelectButton="True" />
                            <asp:BoundField DataField="BASLIK" HeaderText="Başlık" />
                            <asp:BoundField DataField="TARIH" DataFormatString="{0:d}" HeaderText="Tarih" />
                            <asp:BoundField DataField="KATEGORI_ADI" HeaderText="Kategori Adı" />
                            <asp:BoundField DataField="OZET" HeaderText="Özet" />
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
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label1" runat="server" Text="Yazı Refno"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtYAZI_REFNO" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="Label2" runat="server" Text="Başlık"></asp:Label>
                </td>
                <td class="auto-style5">
                    <asp:TextBox ID="txtBASLIK" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBASLIK" ErrorMessage="Başlık Giriniz" ValidationGroup="KayıtFormu"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label4" runat="server" Text="İçerik"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" TextMode="MultiLine" ID="txtICERIK"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtICERIK" ErrorMessage="İçerik Giriniz" ValidationGroup="KayıtFormu"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">
                    <asp:Label ID="Label5" runat="server" Text="Tarih"></asp:Label>
                </td>
                <td class="auto-style7">
                    <asp:TextBox ID="txtTARIH" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtTARIH" ErrorMessage="Tarih Giriniz" ValidationGroup="KayıtFormu"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtTARIH" ErrorMessage="Tarih Formatı Yanlış" ValidationExpression="^(([0-9])|([0-2][0-9])|(3[0-1]))\.(([1-9])|(0[1-9])|(1[0-2]))\.(([0-9][0-9])|([1-2][0,9][0-9][0-9]))$" ValidationGroup="KayitFormu"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="Label6" runat="server" Text="Durumu"></asp:Label>
                </td>
                <td class="auto-style5">
                    <asp:DropDownList ID="ddlDURUMU" runat="server" Height="16px">
                        <asp:ListItem Selected="True" Value="True">Aktif</asp:ListItem>
                        <asp:ListItem Value="False">Pasif</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label7" runat="server" Text="Kategori"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlKATEGORI_REFNO" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label8" runat="server" Text="Tıklanma Sayısı"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtTIKLANMA_SAYISI" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtTIKLANMA_SAYISI" ErrorMessage="Tıklanma Sayısını Giriniz" ValidationGroup="KayıtFormu"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label9" runat="server" Text="Özet"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtOZET" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtOZET" ErrorMessage="Özet Giriniz" ValidationGroup="KayıtFormu"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label10" runat="server" Text="Resim"></asp:Label>
                </td>
                <td>
                    <asp:FileUpload ID="fuRESIM" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <asp:Button ID="Button3" runat="server" Text="Kaydet" Width="78px" OnClick="Button3_Click" ValidationGroup="KayıtFormu" />
                    <asp:Button ID="Button4" runat="server" Text="Vazgeç" OnClick="Button4_Click" />
                    <asp:Button ID="Button5" runat="server" Text="Sil" />
                </td>
            </tr>
        </table>
    </asp:Panel>

    <script>
        <!--ckeditor ve ckfinder klasörleri componentlerle ilişkilendirildi-->
        var editor = CKEDITOR.replace('ContentPlaceHolder1_txtICERIK');
        CKFinder.setupCKEditor(editor, '/ckfinder/');
    </script>

</asp:Content>
