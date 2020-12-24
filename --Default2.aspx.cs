using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            OleDbConnection baglanti = new OleDbConnection();
            OleDbCommand sorgu = new OleDbCommand();
            OleDbDataReader getir;
            baglanti.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0; Data Source=" + HttpContext.Current.Request.PhysicalApplicationPath + "vt.mdb";
            baglanti.Open();
            sorgu.Connection = baglanti;
            sorgu.CommandText = "select filmadi from Tablo1";
            getir = sorgu.ExecuteReader();
            while(getir.Read())
            {
                DropDownList1.Items.Add(Convert.ToString(getir[0]));
            }
            baglanti.Close();


        }


    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        Panel2.Visible = false;
        Panel3.Visible = false;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        Panel2.Visible = true;
        Panel3.Visible = false;
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        Panel2.Visible = false;
        Panel3.Visible = true;
    }

    protected void Button4_Click(object sender, EventArgs e)
    {

        string afisadi,fragmanadi,mansetfotoadi;
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
        ebid++;
        afisadi = "afis" + ebid + ".jpg";
        FileUpload1.SaveAs(Server.MapPath("afis/" + afisadi));
        fragmanadi = "fragman" + ebid + ".mp4";
        FileUpload2.SaveAs(Server.MapPath("fragman/" + fragmanadi));
        mansetfotoadi = "manset" + ebid + ".jpg";
        FileUpload3.SaveAs(Server.MapPath("mansetfoto/" + mansetfotoadi));

        string [] liste1al = new string [3];
        int [] liste1uz = ListBox1.GetSelectedIndices();/*seçililerin sayısı*/
        string secimal;

        OleDbConnection baglanti = new OleDbConnection();
        OleDbCommand sorgu = new OleDbCommand();
        if(CheckBox1.Checked==true)
        {
            secimal="e";
        }
        else
        {
            secimal="h";
        }
        for (int i = 0; i < liste1uz.Length; i++) 
        {
            liste1al[i] = ListBox1.Items[liste1uz[i]].Text;
        }        
        baglanti.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0; Data Source=" + HttpContext.Current.Request.PhysicalApplicationPath + "vt.mdb";
        baglanti.Open();
        sorgu.Connection = baglanti;
        sorgu.CommandText = "insert into Tablo1 (id,filmadi,yonetmen,yil,sure,tur1,tur2,tur3,imdb,afis,oyuncular,ozet,fragman,mansetfoto,secim) values('"+ebid+"','"+TextBox1.Text+"','"+TextBox2.Text+"','"+Convert.ToInt32(TextBox3.Text)+"','"+Convert.ToInt32(TextBox4.Text)+"','"+liste1al[0]+"','"+liste1al[1]+"','"+liste1al[2]+"','"+TextBox5.Text+"','"+afisadi+"','"+TextBox6.Text+"','"+TextBox7.Text+"','"+fragmanadi+"','"+mansetfotoadi+"','"+secimal+"')";
        sorgu.ExecuteNonQuery();                
        baglanti.Close();

        Button4.Visible=false;
        Label1.Text="Kayıt Tamamlanmıştır. <meta http-equiv='refresh' content='3,url=Default2.aspx' />";

        

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        OleDbConnection baglanti = new OleDbConnection();
        OleDbCommand sorgu = new OleDbCommand();
        OleDbDataReader getir;
        baglanti.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0; Data Source=" + HttpContext.Current.Request.PhysicalApplicationPath + "vt.mdb";
        baglanti.Open();
        sorgu.Connection = baglanti;
        sorgu.CommandText = "select * from Tablo1 where filmadi='"+DropDownList1.SelectedItem.Value+"'";
        getir = sorgu.ExecuteReader();
        getir.Read();
        ListBox2.SelectionMode = ListSelectionMode.Multiple;
        TextBox8.Text = Convert.ToString(getir["filmadi"]);
        TextBox9.Text = Convert.ToString(getir["yonetmen"]);
        TextBox10.Text = Convert.ToString(getir["yil"]);
        TextBox11.Text = Convert.ToString(getir["sure"]);
        TextBox12.Text = Convert.ToString(getir["imdb"]);
        TextBox13.Text = Convert.ToString(getir["oyuncular"]);
        TextBox14.Text = Convert.ToString(getir["ozet"]);

        foreach(ListItem turler in ListBox2.Items)
        {
            if (turler.Value == Convert.ToString(getir["tur1"]) || turler.Value == Convert.ToString(getir["tur2"]) || turler.Value == Convert.ToString(getir["tur3"]))
            {
                turler.Selected = true;
            }

        }
        
    }

    
}