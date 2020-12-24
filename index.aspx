<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

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
        .ust{ width:968px; height:33px; border:1px solid #333; margin:10px auto 0 auto; background:url(images/ust-banner.png) no-repeat; font:20px ravie; color:#fff; padding:85px 0 0 10px; text-shadow:0 1px 1px #333 }
        .orta1{ width:978px; height:317px; margin:10px auto 0 auto; }
        #slider { width:670px; height:317px; float:left }
        #son5 {  width:300px; height:267px; margin:0 0 0 8px; background:url(images/se.jpg) no-repeat; padding:43px 0 0 0; float:left }
        #orta2{ width:978px; height:670px; margin:10px auto 0 auto; }
        #alt { width:978px; height:118px; border:1px solid #333; margin:10px auto 0 auto;background:url(images/alt-banner.png) no-repeat}
        #sliderust{width:670px;height:268px;}
        #slideralt{width:670px;height:49px;background:black;}
        #slideraltic{width:440px;height:49px;margin:0 auto}
        .sayi{width:40px;height:35px;background:black;float:left;font:bold 18px arial;text-align:center;color:white;padding:14px 0 0 0;cursor:pointer;}
        .minifilm { width:300px; height:52px; margin:0 0 2px 0;}
        .minifilmafis { width:35px; height:52px; float:left; margin:0 0 2px 0;}
        .minifilmadi { width:255px; height:20px; float:left; margin:5px 0 0 10px;  text-align:right }
            .minifilmadi a {font:bold 16px tahoma; color:#004c66; text-decoration:none}
            .minifilmadi a:hover {font:bold 16px tahoma; color:#004c66; text-decoration:underline}
        .minifilmyonetmen { width:255px; height:15px; float:left; margin:2px 0 0 10px;font:13px tahoma; color:#808080; text-align:right}
        .orta2film {width:190px; height:325px; margin:10px 5px 0 0; float:left  }
        .orta2filmafis { width:190px; height:280px}
        .orta2filmadi { width:190px; height:25px; text-align:right}
        .orta2filmyonetmen { width:190px; height:20px; font:13px tahoma; color:#808080; text-align:right; overflow:hidden}
        .orta2filmadi a {font:bold 13px tahoma; color:#004c66; text-decoration:none}
        .orta2filmadi a:hover {color:#004c66; text-decoration:underline}
        .gizle { display:none  }
    </style>

<script type="text/javascript">
    var degistir;
    function degis(x) {
        window.clearInterval(degistir);
        
        var resimler = new Array();
        var j = 1;
       

        var mansetfotolist = document.getElementById('<%=ListBox1.ClientID%>')
        var mansetfotolistuzunluk = mansetfotolist.options.length;

        for (var i = 0; i < mansetfotolistuzunluk; i++) {
            resimler[j] =  mansetfotolist.options[i].value;
            j++;
        }

        for (var i = 1; i <= 10; i++) {
            if (x == i) {
                document.getElementById("sliderust").style.background = "url(mansetfoto/" + resimler[i] + ")";
                document.getElementById("sayi" + x).style.background = "red";
            }
            else { document.getElementById("sayi" + i).style.background = "black"; }
        }
    }
    function basla(z) {
        
        var j=1;
        var s = z;
        var resimler = new Array();
       
       
       
        var mansetfotolist = document.getElementById('<%=ListBox1.ClientID%>')
        var mansetfotolistuzunluk = mansetfotolist.options.length;
        
        for (var i = 0; i < mansetfotolistuzunluk; i++) {
            resimler[j] = mansetfotolist.options[i].value;
            j++;
        }
    
                
        
        
        
        degistir = window.setInterval(function () {
            document.getElementById("sliderust").style.background = "url(mansetfoto/" + resimler[s]+")";


            for (var i = 1; i <= 10; i++) {
                if (s == i) {

                    document.getElementById("sayi" + s).style.background = "red";
                }
                else { document.getElementById("sayi" + i).style.background = "black"; }
            }

            s++;
            if (s == 11) {
                s = 1;
            }

        }, 1000);

    }

</script>




</head>
<body  onload="basla(1)">
    <form id="form1" runat="server">
    <div class="ust">FİLM MAKİNESİ</div>
    <div class="orta1">
    <div id="slider">
<div id="sliderust" runat="server"></div>
<div id="slideralt">
<div id="slideraltic">
<ul>
<li class="sayi" id="sayi1" onmouseover="degis(1)" onmouseout="basla(1)">1</li>
<li class="sayi" id="sayi2" onmouseover="degis(2)" onmouseout="basla(2)">2</li>
<li class="sayi" id="sayi3" onmouseover="degis(3)" onmouseout="basla(3)">3</li>
<li class="sayi" id="sayi4" onmouseover="degis(4)" onmouseout="basla(4)">4</li>
<li class="sayi" id="sayi5" onmouseover="degis(5)" onmouseout="basla(5)">5</li>
<li class="sayi" id="sayi6" onmouseover="degis(6)" onmouseout="basla(6)">6</li>
<li class="sayi" id="sayi7" onmouseover="degis(7)" onmouseout="basla(7)">7</li>
<li class="sayi" id="sayi8" onmouseover="degis(8)" onmouseout="basla(8)">8</li>
<li class="sayi" id="sayi9" onmouseover="degis(9)" onmouseout="basla(9)">9</li>
<li class="sayi" id="sayi10" onmouseover="degis(10)" onmouseout="basla(10)">10</li>
</ul>
</div></div>

    </div>
    <div id="son5" runat="server"></div>
    </div>
    <div id="orta2" runat="server"></div>
    <div id="alt"></div>
        <asp:ListBox ID="ListBox1" runat="server" CssClass="gizle" ></asp:ListBox>
    </form>
</body>
</html>
