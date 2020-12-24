<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        /***** RESET *****/
html, body, div, span, applet, object, iframe, h1, h2, h3, h4, h5, h6, p, blockquote, pre, a, abbr, acronym, address, big, cite, code,del, dfn, em, font, img, ins, kbd, q, s, samp,
small, strike, sub, sup, tt, var, b, u, i, center,dl, dt, dd, ol, ul, li,fieldset, form, label, legend,table, caption, tbody, tfoot, thead, tr {
	margin: 0;
	padding: 0;
	border: 0;
	outline: 0;
	/*font-size: 100%;
	vertical-align: baseline;*/
	
}
html, body {height:100%;}
body {line-height: 1;margin:0 auto}
ol, ul {list-style: none;}
blockquote, q {quotes: none;}
blockquote:before, blockquote:after, q:before, q:after {content: '';content: none;}
table {border-collapse: collapse;border-spacing: 0;}
textarea {overflow:auto;}

/***** RESET *****/

#sol { width:215px; height:600px; float:left; background:url(images/logo.jpg) no-repeat; margin:20px 0 0 20px    }
#sag { width:600px; height:600px; float:left; margin:20px 0 0 10px   }
#kullanici { width:215px; height:50px; margin:60px 0 0 0   }
#menu { width:215px; height:200px; margin:5px 0 0 0   }
#Button1,#Button2,#Button3 { border:none; background:#429edd; opacity:0.8}
        .auto-style1 {
            height: 25px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="sol">
    <div id="kullanici"> </div> 
    <div id="menu"> 
        <asp:Button ID="Button1" runat="server" Height="40px" Text="Yeni Film Ekle" Width="215px" OnClick="Button1_Click" />
        <br />
        <br />
        <asp:Button ID="Button2" runat="server" Height="40px" Text="Film Düzenle" Width="215px" OnClick="Button2_Click" />
        <br />
        <br />
        <asp:Button ID="Button3" runat="server" Height="40px" Text="Film Sil" Width="215px" OnClick="Button3_Click" />
        </div> 
    </div>
    <div id="sag"> 
        <asp:Panel ID="Panel1" runat="server" Height="600px" Width="600px" Visible="False">
            <table style="width:100%;">
                <tr>
                    <td colspan="2" style="height:30px; font:bold 14px tahoma">Yeni Film Ekle</td>
                    <td></td>
                    
                </tr>
                <tr>
                    <td style="height:25px">Film Adı</td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </td>
                   
                </tr>
                <tr>
                    <td style="height:25px">Yönetmen</td>
                    <td>
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    </td>
                   
                </tr>
                <tr>
                    <td class="auto-style1">Filmin Yılı</td>
                    <td class="auto-style1">
                        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                    </td>
                    
                </tr>
                <tr>
                    <td style="height:25px">Filmin Süresi</td>
                    <td>
                        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                    </td>
                  
                </tr>
                <tr>
                    <td style="height:25px">Filmin Türü</td>
                    <td>
                        <asp:ListBox ID="ListBox1" runat="server" Height="120px" Width="180px" SelectionMode="Multiple">
                            <asp:ListItem>Aile</asp:ListItem>
                            <asp:ListItem>Aksiyon</asp:ListItem>
                            <asp:ListItem>Animasyon</asp:ListItem>
                            <asp:ListItem>Belgesel</asp:ListItem>
                            <asp:ListItem>Bilim Kurgu</asp:ListItem>
                            <asp:ListItem>Biyografi</asp:ListItem>
                            <asp:ListItem>Dram</asp:ListItem>
                            <asp:ListItem>Fantastik</asp:ListItem>
                            <asp:ListItem>Gerilim</asp:ListItem>
                            <asp:ListItem>Gizem</asp:ListItem>
                            <asp:ListItem>Komedi</asp:ListItem>
                            <asp:ListItem>Korku</asp:ListItem>
                            <asp:ListItem>Macera</asp:ListItem>
                            <asp:ListItem>Müzik</asp:ListItem>
                            <asp:ListItem>Suç</asp:ListItem>
                            <asp:ListItem>Romantik</asp:ListItem>
                            <asp:ListItem>Savaş</asp:ListItem>
                            <asp:ListItem>Spor</asp:ListItem>
                            <asp:ListItem>Tarih</asp:ListItem>
                            <asp:ListItem>Western</asp:ListItem>
                        </asp:ListBox>
                    </td>
                 
                </tr>
                <tr>
                    <td style="height:25px">Imdb Puanı</td>
                    <td>
                        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                    </td>
                 
                </tr>
                <tr>
                    <td style="height:25px">Afiş</td>
                    <td>
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                    </td>
                
                </tr>
                <tr>
                    <td style="height:25px">Oyuncular</td>
                    <td>
                        <asp:TextBox ID="TextBox6" runat="server" Height="90px" TextMode="MultiLine" Width="400px"></asp:TextBox>
                    </td>
                   
                </tr>
                <tr>
                    <td style="height:25px">Özet</td>
                    <td>
                        <asp:TextBox ID="TextBox7" runat="server" Height="90px" TextMode="MultiLine" Width="400px"></asp:TextBox>
                    </td>
                    
                </tr>
                <tr>
                    <td style="height:25px">Fragman</td>
                    <td>
                        <asp:FileUpload ID="FileUpload2" runat="server" />
                    </td>
                   
                </tr>
                <tr>
                    <td style="height:25px">Manşet Foto</td>
                    <td>
                        <asp:FileUpload ID="FileUpload3" runat="server" />
                    </td>
                   
                </tr>
                <tr>
                    <td style="height:25px">Editörün Seçimi</td>
                    <td>
                        <asp:CheckBox ID="CheckBox1" runat="server" />
                    </td>
                    
                </tr>
                <tr>
                    <td style="height:25px">&nbsp;</td>
                    <td>
                        <asp:Button ID="Button4" runat="server" Text="Ekle" OnClick="Button4_Click" />
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small" ForeColor="#00CC00"></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="Panel2" runat="server" Height="600px" Width="600px" Visible="False">
            <table style="width:100%;">
                <tr>
                    <td style="height:30px; font:bold 14px tahoma">Film Düzenle</td>
                    <td>
                        <asp:DropDownList ID="DropDownList1" runat="server" Width="250px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    
                </tr>
                <tr>
                    <td style="height:25px">Film Adı</td>
                    <td>
                        <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                    </td>
                   
                </tr>
                <tr>
                    <td style="height:25px">Yönetmen</td>
                    <td>
                        <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
                    </td>
                   
                </tr>
                <tr>
                    <td class="auto-style1">Filmin Yılı</td>
                    <td class="auto-style1">
                        <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
                    </td>
                    
                </tr>
                <tr>
                    <td style="height:25px">Filmin Süresi</td>
                    <td>
                        <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
                    </td>
                  
                </tr>
                <tr>
                    <td style="height:25px">Filmin Türü</td>
                    <td>
                        <asp:ListBox ID="ListBox2" runat="server" Height="120px" Width="180px">
 <asp:ListItem>Aile</asp:ListItem>
                            <asp:ListItem>Aksiyon</asp:ListItem>
                            <asp:ListItem>Animasyon</asp:ListItem>
                            <asp:ListItem>Belgesel</asp:ListItem>
                            <asp:ListItem>Bilim Kurgu</asp:ListItem>
                            <asp:ListItem>Biyografi</asp:ListItem>
                            <asp:ListItem>Dram</asp:ListItem>
                            <asp:ListItem>Fantastik</asp:ListItem>
                            <asp:ListItem>Gerilim</asp:ListItem>
                            <asp:ListItem>Gizem</asp:ListItem>
                            <asp:ListItem>Komedi</asp:ListItem>
                            <asp:ListItem>Korku</asp:ListItem>
                            <asp:ListItem>Macera</asp:ListItem>
                            <asp:ListItem>Müzik</asp:ListItem>
                            <asp:ListItem>Suç</asp:ListItem>
                            <asp:ListItem>Romantik</asp:ListItem>
                            <asp:ListItem>Savaş</asp:ListItem>
                            <asp:ListItem>Spor</asp:ListItem>
                            <asp:ListItem>Tarih</asp:ListItem>
                            <asp:ListItem>Western</asp:ListItem>


                        </asp:ListBox>
                    </td>
                 
                </tr>
                <tr>
                    <td style="height:25px">Imdb Puanı</td>
                    <td>
                        <asp:TextBox ID="TextBox12" runat="server"></asp:TextBox>
                    </td>
                 
                </tr>
                <tr>
                    <td style="height:25px">Afiş</td>
                    <td>
                        <asp:FileUpload ID="FileUpload4" runat="server" />
                    </td>
                
                </tr>
                <tr>
                    <td style="height:25px">Oyuncular</td>
                    <td>
                        <asp:TextBox ID="TextBox13" runat="server" Height="90px" TextMode="MultiLine" Width="400px"></asp:TextBox>
                    </td>
                   
                </tr>
                <tr>
                    <td style="height:25px">Özet</td>
                    <td>
                        <asp:TextBox ID="TextBox14" runat="server" Height="90px" TextMode="MultiLine" Width="400px"></asp:TextBox>
                    </td>
                    
                </tr>
                <tr>
                    <td style="height:25px">Fragman</td>
                    <td>
                        <asp:FileUpload ID="FileUpload5" runat="server" />
                    </td>
                   
                </tr>
                <tr>
                    <td style="height:25px">Manşet Foto</td>
                    <td>
                        <asp:FileUpload ID="FileUpload6" runat="server" />
                    </td>
                   
                </tr>
                <tr>
                    <td style="height:25px">Editörün Seçimi</td>
                    <td>
                        <asp:CheckBox ID="CheckBox2" runat="server" />
                    </td>
                    
                </tr>
                <tr>
                    <td style="height:25px">&nbsp;</td>
                    <td>
                        <asp:Button ID="Button5" runat="server" Text="Düzenle" OnClick="Button5_Click" />
                        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small" ForeColor="#00CC00"></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="Panel3" runat="server" Height="600px" Width="600px" Visible="False">
            <table style="width:100%;">
                <tr>
                    <td style="height:30px; font:bold 14px tahoma">Film Sil</td>
                    <td>
                        &nbsp;</td>
                    
                </tr>
                <tr>
                    <td style="height:25px">Film Adı</td>
                    <td>
                        <asp:ListBox ID="ListBox3" runat="server" Height="150px" Width="250px"></asp:ListBox>
                    </td>
                   
                </tr>
                <tr>
                    <td style="height:25px">&nbsp;</td>
                    <td>
                        <asp:Button ID="Button6" runat="server" Text="Sil" OnClick="Button6_Click" />
                        <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small" ForeColor="#00CC00"></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        </div>
    </form>
</body>
</html>
