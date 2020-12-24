<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register assembly="ASPNetFlashVideo.NET4" namespace="ASPNetFlashVideo" tagprefix="ASPNetFlashVideo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
       #ust{ width:968px; height:33px; border:1px solid #333; margin:10px auto; background:url(images/ust-banner.png) no-repeat; font:20px ravie; color:#fff; padding:85px 0 0 10px; text-shadow:0 1px 1px #333 }
       #orta{width:980px;height:950px;margin:0 auto}
       #sol{width:670px;height:950px;float:left;}
       #sag{width:300px;height:950px;float:left;margin-left:10px;}
       #alt{width:978px;height:118px;margin:10px auto;background:url(images/alt-banner.png) no-repeat}
       #afis{width:214px;height:317px;float:left;}
       #kunye{width:446px;height:317px;float:left;margin-left:10px;}
       #ozet{width:656px;height:186px;float:left;font:13px tahoma;background:#eee;text-align:center;margin-top:10px;padding:7px;}
       #fragman{width:670px;height:410px;float:left;margin-top:10px;overflow: hidden;}
       #filmadi{width:auto;height:auto;padding:10px;background:#eee;margin-bottom:7px;font:21px tahoma;text-align:right;}
       #yonetmen{width:auto;height:auto;padding:6px;background:#eee;margin-bottom:7px;font:16px tahoma;text-align:right;}
       #yil{width:auto;height:auto;padding:6px;background:#eee;margin-bottom:7px;font:14px tahoma;text-align:right;}
       #tur{width:auto;height:auto;padding:6px;background:#eee;margin-bottom:7px;font:14px tahoma;text-align:right;}
       #sure{width:auto;height:auto;padding:6px;background:#eee;margin-bottom:7px;font:14px tahoma;text-align:right;}
       #imdb{width:auto;height:auto;padding:6px;background:#eee;margin-bottom:7px;font:14px tahoma;text-align:right;}
       #oyuncular{width:auto;height:auto;padding:7px;background:#eee;margin-bottom:7px;font:12px tahoma;text-align:right;}
       #sagic1{width:300px;height:267px;margin-bottom:6px;background:url(images/se.jpg) no-repeat;padding-top:43px;}
       #sagic2{width:300px;height:267px;margin-bottom:6px;background:url(images/rg.jpg) no-repeat;padding-top:43px;}
       #sagic3{width:300px;height:267px;margin-bottom:6px;background:url(images/ip.jpg) no-repeat;padding-top:43px;}
       .minifilm{height:52px;width:300px;padding-bottom:2px;text-align:right}
       .minifilmafis{width:35px;height:52px;float:left;}
       .minifilmadi{width:255px;height:20px;float:left;margin:5px 0 0 10px;font:bold 16px tahoma;color:#004c66}
       .minifilmadi a{font:bold 16px tahoma;color:#004c66;text-decoration:none;}
       .minifilmadi a:hover{text-decoration:underline;}
       .minifilmyonetmen{width:255px;height:15px;float:left;margin:2px 0 0 10px;font:bold 13px tahoma;color:#808080}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="ust" runat="server">FİLM MAKİNESİ</div>
    <div runat="server" id="orta">
        <div runat="server" id="sol">
            <div runat="server" id="afis"></div>
            <div runat="server" id="kunye">
                <div runat="server" id="filmadi"></div>
                <div runat="server" id="yonetmen"></div>
                <div runat="server" id="yil"></div>
                <div runat="server" id="tur"></div>
                <div runat="server" id="sure"></div>
                <div runat="server" id="oyuncular"></div>
                <div runat="server" id="imdb"></div>
            </div>
            <div runat="server" id="ozet"></div>
            <div runat="server" id="fragman">
                <ASPNetFlashVideo:FlashVideo ID="FlashVideo1" runat="server" Height="410px" Width="670px">
                </ASPNetFlashVideo:FlashVideo>
            </div>
        </div>
        <div runat="server" id="sag">
            <div runat="server" id="sagic1"></div>
            <div runat="server" id="sagic2"></div>
            <div runat="server" id="sagic3"></div>
        </div>
    </div>
    <div runat="server" id="alt"></div>
    </form>
</body>
</html>
