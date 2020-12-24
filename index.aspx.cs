using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int k = 1;
        System.Data.OleDb.OleDbConnection baglanti = new System.Data.OleDb.OleDbConnection();
        System.Data.OleDb.OleDbCommand sorgu = new System.Data.OleDb.OleDbCommand();
        System.Data.OleDb.OleDbDataReader getir;
        baglanti.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0; Data Source=" + HttpContext.Current.Request.PhysicalApplicationPath + "vt.mdb";
        baglanti.Open();
        sorgu.Connection = baglanti;
        sorgu.CommandText = "select id,mansetfoto from Tablo1 where secim='e'";
        getir = sorgu.ExecuteReader(); 
        while(getir.Read())
        {
            if (k == 1)
            { sliderust.Attributes.CssStyle.Value = "background:url(mansetfoto/"+Convert.ToString(getir[1])+")"; }
            ListBox1.Items.Add(Convert.ToString(getir[1]));
            k++;
        }
        
           


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
            gecici = gecici + "<div class='minifilm'><div class='minifilmafis'><img src='afis/" + getir2["afis"] + "' width='35' height='52'></div><div class='minifilmadi'><a href='Default.aspx?id=" + getir2["id"] + "'>" + getir2["filmadi"] + "</a></div><div class='minifilmyonetmen'>" + getir2["yonetmen"] + "</div></div>";
            baglanti2.Close();

        }

        son5.InnerHtml = gecici;



        Random a = new Random();
        int[] sayilar = new int[10];
        int uretilensayi, j = 0, uzunluk;
        string kisafilmadi="";
        while (j < 10)
        {
            uretilensayi = a.Next(1, ebid + 1);
            if (sayilar.Contains(uretilensayi) == false)/*contains içeriyor mu diye soruyor*/
            {
                sayilar[j] = uretilensayi;
                j++;
            }

        }

        gecici = "";
        for (int i = 0; i < 10; i++)
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
            kisafilmadi = Convert.ToString(getir2["filmadi"]);
            uzunluk = kisafilmadi.Length;
            if (uzunluk > 27)
            { kisafilmadi = kisafilmadi.Substring(0, 24)+"..."; }
            gecici = gecici + "<div class='orta2film'><div class='orta2filmafis'><a href='Default.aspx?id=" + getir2["id"] + "'><img src='afis/" + getir2["afis"] + "' width='190' height='280'></a></div><div class='orta2filmadi'><a href='Default.aspx?id=" + getir2["id"] + "'>" + kisafilmadi + "</a></div><div class='orta2filmyonetmen'>" + getir2["yonetmen"] + "</div></div>";
            baglanti2.Close();

        }

        orta2.InnerHtml = gecici;
    }
}