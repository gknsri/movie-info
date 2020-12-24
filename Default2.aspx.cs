using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(IsPostBack==false)
        {
            OleDbConnection baglanti1 = new OleDbConnection();
            OleDbCommand sorgu1 = new OleDbCommand();
            OleDbDataReader getir1;
            baglanti1.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0; Data Source=" + HttpContext.Current.Request.PhysicalApplicationPath + "vt.mdb";
            baglanti1.Open();
            sorgu1.Connection = baglanti1;
            sorgu1.CommandText = "select filmadi from Tablo1";
            getir1 = sorgu1.ExecuteReader();
            DropDownList1.Items.Add("Bir Film Seçiniz");
            while(getir1.Read())
            { DropDownList1.Items.Add(Convert.ToString(getir1[0]));
            ListBox3.Items.Add(Convert.ToString(getir1[0]));

            }


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
        FileUpload1.SaveAs(Server.MapPath("images/" + afisadi));
        fragmanadi = "fragman" + ebid + ".mp4";
        FileUpload2.SaveAs(Server.MapPath("fragman/" + fragmanadi));
        mansetfotoadi = "manset" + ebid + ".jpg";
        FileUpload3.SaveAs(Server.MapPath("mansetfoto/" + mansetfotoadi));

      
       
        string secimial="h";
        string[] liste1al= new string[3]; 
        int[] liste1uz = ListBox1.GetSelectedIndices();
        OleDbConnection baglanti4 = new OleDbConnection();
        OleDbCommand sorgu4 = new OleDbCommand();


    
       
        if(CheckBox1.Checked==true)
        { secimial = "e"; }
        else
        { secimial = "h"; }


        for (int i = 0; i < liste1uz.Length;i++ )
        { liste1al[i] = ListBox1.Items[liste1uz[i]].Text;
       
        }

        baglanti4.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0; Data Source=" + HttpContext.Current.Request.PhysicalApplicationPath + "vt.mdb";
        baglanti4.Open();
        sorgu4.Connection = baglanti4;
        sorgu4.CommandText = "insert into Tablo1 (id,filmadi,yonetmen,yil,sure,tur1,tur2,tur3,imdb,afis,oyuncular,ozet,fragman,mansetfoto,secim) values (" + ebid + ",'" + TextBox1.Text + "','" + TextBox2.Text + "'," + Convert.ToInt32(TextBox3.Text) + "," + Convert.ToInt32(TextBox4.Text) + ",'" + liste1al[0] + "','" + liste1al[1] + "','" + liste1al[2] + "','" +TextBox5.Text + "','" + afisadi + "','" + TextBox6.Text + "','" + TextBox7.Text + "','" + fragmanadi + "','" + mansetfotoadi + "','" + secimial + "')";
        sorgu4.ExecuteNonQuery();
        baglanti4.Close();
        Button4.Visible = false;
        Label1.Text = "Kayıt tamamlanmıştır.<meta http-equiv='refresh' content='3,url=login.aspx'>";

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedItem.Value != "Bir Film Seçiniz")
        {
            OleDbConnection baglanti1 = new OleDbConnection();
            OleDbCommand sorgu1 = new OleDbCommand();
            OleDbDataReader getir1;
            baglanti1.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0; Data Source=" + HttpContext.Current.Request.PhysicalApplicationPath + "vt.mdb";
            baglanti1.Open();
            sorgu1.Connection = baglanti1;
            sorgu1.CommandText = "select * from Tablo1 where filmadi='" + DropDownList1.SelectedItem.Value + "'";
            getir1 = sorgu1.ExecuteReader();
            getir1.Read();
            TextBox8.Text = Convert.ToString(getir1["filmadi"]);
            TextBox9.Text = Convert.ToString(getir1["yonetmen"]);
            TextBox10.Text = Convert.ToString(getir1["yil"]);
            TextBox11.Text = Convert.ToString(getir1["sure"]);
            ListBox2.SelectionMode = ListSelectionMode.Multiple;
            foreach (ListItem item in ListBox2.Items)
            {
                if (item.Value == Convert.ToString(getir1["tur1"]) || item.Value == Convert.ToString(getir1["tur2"]) || item.Value == Convert.ToString(getir1["tur3"]))
                {
                    item.Selected = true;
                }
            }
            TextBox12.Text = Convert.ToString(getir1["imdb"]);
            TextBox13.Text = Convert.ToString(getir1["oyuncular"]).Replace("^", "'");
            TextBox14.Text = Convert.ToString(getir1["ozet"]).Replace("^","'");
            if (Convert.ToString(getir1["secim"]) == "e")
            { CheckBox2.Checked = true; }
            else
            { CheckBox2.Checked = false; }
        }
        else
        {
            TextBox8.Text = "";
            TextBox9.Text = "";
            TextBox10.Text = "";
            TextBox11.Text = "";
            ListBox2.SelectionMode = ListSelectionMode.Multiple;
            foreach (ListItem item in ListBox2.Items)
            {
                
                    item.Selected = false;
               
            }
            TextBox12.Text = "";
            TextBox13.Text = "";
            TextBox14.Text = "";
           CheckBox2.Checked = false;
        
        
        }

    }
    protected void Button5_Click(object sender, EventArgs e)
    {
            string afisadi, fragmanadi, mansetfotoadi;
            OleDbConnection baglanti2 = new OleDbConnection();
            OleDbCommand sorgu2 = new OleDbCommand();
            OleDbDataReader getir2;
            baglanti2.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0; Data Source=" + HttpContext.Current.Request.PhysicalApplicationPath + "vt.mdb";
            baglanti2.Open();
            sorgu2.Connection = baglanti2;
            sorgu2.CommandText = "select afis,fragman,mansetfoto from Tablo1 where filmadi='" + DropDownList1.SelectedItem.Value + "'";
            getir2 = sorgu2.ExecuteReader();
            getir2.Read();




        afisadi =Convert.ToString(getir2["afis"]);
        FileUpload1.SaveAs(Server.MapPath("images/" + afisadi));
        fragmanadi = Convert.ToString(getir2["fragman"]);
        FileUpload2.SaveAs(Server.MapPath("fragman/" + fragmanadi));
        mansetfotoadi = Convert.ToString(getir2["mansetfoto"]); 
        FileUpload3.SaveAs(Server.MapPath("mansetfoto/" + mansetfotoadi));




        string secimial = "h";
        string[] liste1al = new string[3];
        int[] liste1uz = ListBox1.GetSelectedIndices();
        OleDbConnection baglanti1 = new OleDbConnection();
        OleDbCommand sorgu1 = new OleDbCommand();

        for (int i = 0; i < liste1uz.Length; i++)
        {
            liste1al[i] = ListBox1.Items[liste1uz[i]].Text;

        }
       
        if (CheckBox2.Checked == true)
        { secimial = "e"; }
        else
        { secimial = "h"; }

        
        baglanti1.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0; Data Source=" + HttpContext.Current.Request.PhysicalApplicationPath + "vt.mdb";
        baglanti1.Open();
        sorgu1.Connection = baglanti1;
        sorgu1.CommandText = "update Tablo1 set filmadi='" + TextBox8.Text + "',yonetmen='" + TextBox9.Text + "',yil=" + Convert.ToInt32(TextBox10.Text) + ",sure=" + Convert.ToInt32(TextBox11.Text) + ",tur1='" + liste1al[0] + "',tur2='" + liste1al[1] + "',tur3='" + liste1al[2] + "',imdb='" + TextBox12.Text + "',oyuncular='" + TextBox13.Text.Replace("'", "^") + "',ozet='" + TextBox14.Text.Replace("'", "^") + "',secim='" + secimial + "' where filmadi='" + DropDownList1.SelectedItem.Value + "'";
        sorgu1.ExecuteNonQuery();
        baglanti1.Close();
        Button5.Visible = false;
        Label2.Text = "Güncelleme tamamlanmıştır.<meta http-equiv='refresh' content='3,url=login.aspx'>";
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        
        OleDbConnection baglanti2 = new OleDbConnection();
        OleDbCommand sorgu2 = new OleDbCommand();
        
        baglanti2.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0; Data Source=" + HttpContext.Current.Request.PhysicalApplicationPath + "vt.mdb";
        baglanti2.Open();
        sorgu2.Connection = baglanti2;
        sorgu2.CommandText = "delete from Tablo1 where filmadi='"+ListBox3.SelectedItem.Value+"'";
        sorgu2.ExecuteNonQuery();
        baglanti2.Close();
        Button6.Visible = false;
        Label3.Text = "Silme tamamlanmıştır.<meta http-equiv='refresh' content='3,url=login.aspx'>";
    }
}