<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Yonetim.Master" AutoEventWireup="true" CodeBehind="Yorum.aspx.cs" Inherits="GUNLUK.Yorum" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 158px;
        }
        .auto-style3 {
            width: 158px;
            height: 24px;
        }
        .auto-style4 {
            height: 24px;
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
                    <asp:Label ID="Label1" runat="server" Text="İçerik"></asp:Label>
                    <asp:TextBox ID="txtARA" runat="server"></asp:TextBox>
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Ara" />
                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Yeni" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="YORUM_REFNO" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanging="GridView2_PageIndexChanging" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" Width="100%" AllowPaging="True" PageSize="4">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:CommandField HeaderText="Seç" ShowSelectButton="True" />
                            <asp:BoundField DataField="AD_SOYAD" HeaderText="Adı Soyadı" />
                            <asp:BoundField DataField="TARIH" HeaderText="Tarih" DataFormatString="{0:d}" />
                            <asp:BoundField DataField="ICERIK" HeaderText="İçerik" />
                            <asp:BoundField DataField="BASLIK" HeaderText="Başlık" />
                            <asp:BoundField DataField="MAIL" HeaderText="Mail" />
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
                <td>
                    <asp:Label ID="Label10" runat="server" Text="KAYIT FORMU"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label2" runat="server" Text="Yorum Refno"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtYORUM_REFNO" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="Label3" runat="server" Text="Başlık"></asp:Label>
                </td>
                <td class="auto-style4">
                    <asp:DropDownList ID="ddlYAZI_REFNO" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label4" runat="server" Text="Mail"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtMAIL" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMAIL" ErrorMessage="Mail Giriniz" ValidationGroup="Kayıt Formu"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label5" runat="server" Text="Adı Soyadı"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtAD_SOYAD" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtAD_SOYAD" ErrorMessage="Ad Soyad Giriniz" ValidationGroup="Kayıt Formu"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label6" runat="server" Text="Durumu"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlDURUMU" runat="server">
                        <asp:ListItem Selected="True" Value="True">Aktif</asp:ListItem>
                        <asp:ListItem Value="False">Pasif</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label7" runat="server" Text="Tarih"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtTARIH" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtTARIH" ErrorMessage="Tarih Giriniz" ValidationGroup="Kayıt Formu"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtTARIH" ErrorMessage="Tarih Formatı Yanlış" ValidationExpression="^(([0-9])|([0-2][0-9])|(3[0-1]))\.(([1-9])|(0[1-9])|(1[0-2]))\.(([0-9][0-9])|([1-2][0,9][0-9][0-9]))$" ValidationGroup="KayitFormu"></asp:RegularExpressionValidator>

                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label8" runat="server" Text="IP"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtIP" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtIP" ErrorMessage="IP Giriniz" ValidationGroup="Kayıt Formu"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label9" runat="server" Text="İçerik"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtICERIK" runat="server" TextMode="MultiLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtIP" ErrorMessage="İçerik Giriniz" ValidationGroup="Kayıt Formu"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Kaydet" ValidationGroup="Kayıt Formu" />
                    <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Vazgeç" />
                    <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Sil" />
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
