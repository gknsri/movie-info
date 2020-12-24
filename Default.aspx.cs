using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
        int gelensayi = Convert.ToInt32(Request.QueryString["id"]);
        if (gelensayi == 0)
        {
            gelensayi = 1;
        }
        string turleritopla = "";
        int say;
        OleDbConnection baglanti4 = new OleDbConnection();
        OleDbCommand sorgu4 = new OleDbCommand();
        OleDbDataReader getir4;
        baglanti4.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0; Data Source=" + HttpContext.Current.Request.PhysicalApplicationPath + "vt.mdb";
        baglanti4.Open();
        sorgu4.Connection = baglanti4;
        sorgu4.CommandText = "select * from Tablo1 where id=" + gelensayi;
        getir4 = sorgu4.ExecuteReader();
        if (getir4.HasRows)
        {
            getir4.Read();
            afis.InnerHtml = "<img src='afis/" + getir4["afis"] + "' width='214' height='317'>";/*fotoyu getirme yolu*/
            filmadi.InnerHtml = Convert.ToString(getir4["filmadi"]);
            yonetmen.InnerHtml = Convert.ToString(getir4["yonetmen"]);
            yil.InnerHtml = Convert.ToString(getir4["yil"]);
            sure.InnerHtml = Convert.ToString(getir4["sure"]) + "dk";
            oyuncular.InnerHtml = Convert.ToString(getir4["oyuncular"]);
            ozet.InnerHtml = Convert.ToString(getir4["ozet"]);
            imdb.InnerHtml = Convert.ToString(getir4["imdb"]);
            if (Convert.ToString(getir4["tur1"]) != null)
            {
                turleritopla = turleritopla + Convert.ToString(getir4["tur1"]) + ",";

            }
            if (Convert.ToString(getir4["tur2"]) != null)
            {
                turleritopla = turleritopla + Convert.ToString(getir4["tur2"]) + ",";

            }
            if (Convert.ToString(getir4["tur3"]) != null)
            {
                turleritopla = turleritopla + Convert.ToString(getir4["tur3"]) + ",";
            }
            say = turleritopla.Length;/*türlerin karakter sayısnı topluyor(sondaki virgüller için)*/
            say = say - 2;
            turleritopla = turleritopla.Substring(0, say);/*belli bir metinden istediğimiz kısmı alırız*/
            tur.InnerHtml = turleritopla;
            FlashVideo1.VideoURL = "fragman/" + Convert.ToString(getir4["fragman"]);
        }
        baglanti4.Close();



        string gecici = "";
        int ebid;
        OleDbConnection baglanti1 = new OleDbConnection();
        OleDbCommand sorgu1 = new OleDbCommand();
        OleDbDataReader getir1;
        baglanti1.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0; Data Source=" + HttpContext.Current.Request.PhysicalApplicationPath + "vt.mdb";
        baglanti1.Open();
        sorgu1.Connection = baglanti1;
        sorgu1.CommandText = "select max(id) from Tablo1";
        getir1 = sorgu1.ExecuteReader();
        getir1.Read();
        ebid = Convert.ToInt32(getir1[0]);
        baglanti1.Close();
        for (int i = ebid; i > ebid - 5; i--)
        {
            OleDbConnection baglanti2 = new OleDbConnection();
            OleDbCommand sorgu2 = new OleDbCommand();
            OleDbDataReader getir2;
            baglanti2.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0; Data Source=" + HttpContext.Current.Request.PhysicalApplicationPath + "vt.mdb";
            baglanti2.Open();
            sorgu2.Connection = baglanti2;
            sorgu2.CommandText = "select id,filmadi,yonetmen,afis from Tablo1 where id=" + i;
            getir2 = sorgu2.ExecuteReader();
            getir2.Read();
            gecici = gecici + "<div class='minifilm'><div class='minifilmafis'><img src='afis/" + getir2["afis"] + "' width='35' height='52'></div><div class='minifilmadi'><a href='default.aspx?id=" + getir2["id"] + "'>" + getir2["filmadi"] + "</a></div><div class='minifilmyonetmen'>" + getir2["yonetmen"] + "</div></div>";
            baglanti2.Close();
        }
        
        sagic1.InnerHtml = gecici;
        gecici = "";
        Random a=new Random();
        int[] sayilar = new int[5];
        int uretilensayi, j = 0;
        while (j < 5)
        {
            uretilensayi = a.Next(1, ebid+1);
            if (sayilar.Contains(uretilensayi)==false)
            {
                sayilar[j] = uretilensayi;
                j++;
            }
        }
        for (int i = 0; i < 5; i++)
        {
            OleDbConnection baglanti2 = new OleDbConnection();
            OleDbCommand sorgu2 = new OleDbCommand();
            OleDbDataReader getir2;
            baglanti2.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0; Data Source=" + HttpContext.Current.Request.PhysicalApplicationPath + "vt.mdb";
            baglanti2.Open();
            sorgu2.Connection = baglanti2;
            sorgu2.CommandText = "select id,filmadi,yonetmen,afis from Tablo1 where id=" + sayilar[i];
            getir2 = sorgu2.ExecuteReader();
            getir2.Read();
            gecici = gecici + "<div class='minifilm'><div class='minifilmafis'><img src='afis/" + getir2["afis"] + "' width='35' height='52'></div><div class='minifilmadi'><a href='default.aspx?id=" + getir2["id"] + "'>" + getir2["filmadi"] + "</a></div><div class='minifilmyonetmen'>" + getir2["yonetmen"] + "</div></div>";
            baglanti2.Close();
        }
        sagic2.InnerHtml = gecici;
        gecici = "";
        OleDbConnection baglanti3 = new OleDbConnection();
        OleDbCommand sorgu3 = new OleDbCommand();
        OleDbDataReader getir3;
        baglanti3.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0; Data Source=" + HttpContext.Current.Request.PhysicalApplicationPath + "vt.mdb";
        baglanti3.Open();
        sorgu3.Connection = baglanti3;
        sorgu3.CommandText = "select id,filmadi,yonetmen,afis,imdb from Tablo1 order by imdb DESC";
        getir3 = sorgu3.ExecuteReader();
        for (int i = 0; i < 5; i++)
        {
            getir3.Read();
            gecici = gecici + "<div class='minifilm'><div class='minifilmafis'><img src='afis/" + getir3["afis"] + "' width='35' height='52'></div><div class='minifilmadi'><a href='default.aspx?id=" + getir3["id"] + "'>" + getir3["filmadi"] + "</a><span style='font:11px tahoma;color:#808080;'> (" + getir3["imdb"] + ")</span></div><div class='minifilmyonetmen'>" + getir3["yonetmen"] + "</div></div>";
            sagic3.InnerHtml = gecici;
        }
    }
    
}