using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Бипит_8
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public void Get()
        {
            DataTable mainTable = new DataTable();
            if (mainTable.Columns.Count == 0)
            {
                mainTable.Columns.Add("Id", typeof(int));
                mainTable.Columns.Add("ID_oboryd", typeof(string));
                mainTable.Columns.Add("ID_vid_rabot", typeof(string));
                mainTable.Columns.Add("Data_polychen", typeof(DateTime));
                mainTable.Columns.Add("Data_vipolnen", typeof(DateTime));
            }

            using (Vid_rabotContext db = new Vid_rabotContext())
            {
                DataTable vid_rabotTable = new DataTable();
                if (vid_rabotTable.Columns.Count == 0)
                {
                    vid_rabotTable.Columns.Add("Id", typeof(int));
                    vid_rabotTable.Columns.Add("Name_vid_rabot", typeof(string));
                }
                var vid_rabot = db.Vid_rabot;
                foreach (Vid_rabot p in vid_rabot)
                {
                    DataRow row = vid_rabotTable.NewRow();
                    row[0] = p.Id;
                    row[1] = p.Name_vid_rabot;
                    vid_rabotTable.Rows.Add(row);
                }
            }

            using (OborydContext db = new OborydContext())
            {
                DataTable oborydTable = new DataTable();
                if (oborydTable.Columns.Count == 0)
                {
                    oborydTable.Columns.Add("Id", typeof(int));
                    oborydTable.Columns.Add("Model_oboryd", typeof(string));
                }
                var oboryd = db.Oboryd;
                foreach (Oboryd s in oboryd)
                {
                    DataRow row = oborydTable.NewRow();
                    row[0] = s.Id;
                    row[1] = s.Model_oboryd;
                    oborydTable.Rows.Add(row);
                }
            }

            using (RaborContext db = new RaborContext())
            {
                var rabot = db.Rabor;
                foreach (Rabor app in rabot)
                {
                    DataRow row = mainTable.NewRow();
                    row[0] = app.Id;

                    using (OborydContext db1 = new OborydContext())
                    {
                        Oboryd oboryd = db1.Oboryd.Where(s => s.Id == app.ID_oboryd).FirstOrDefault();
                        row[1] = oboryd.Model_oboryd;
                    }

                    using (Vid_rabotContext db2 = new Vid_rabotContext())
                    {
                        var vid_rabot = db2.Vid_rabot.Where(p => p.Id == app.ID_vid_rabot).FirstOrDefault();
                        row[2] = vid_rabot.Name_vid_rabot;
                    }
                    string[] d = app.Data_polychen.ToString().Split(' ');
                    string[] dd = app.Data_vipolnen.ToString().Split(' ');
                    row[3] = d[0];
                    row[4] = dd[0];
                    mainTable.Rows.Add(row);
                }
                GridView1.DataSource = mainTable;
                GridView1.DataBind();
            }
        }

        public void GetData(DateTime d1, DateTime d2)
        {
            DataTable mainTable = new DataTable();
            if (mainTable.Columns.Count == 0)
            {
                mainTable.Columns.Add("Id", typeof(int));
                mainTable.Columns.Add("ID_oboryd", typeof(string));
                mainTable.Columns.Add("ID_vid_rabot", typeof(string));
                mainTable.Columns.Add("Data_polychen", typeof(DateTime));
                mainTable.Columns.Add("Data_vipolnen", typeof(DateTime));
            }

            using (Vid_rabotContext db = new Vid_rabotContext())
            {
                DataTable vid_rabotTable = new DataTable();
                if (vid_rabotTable.Columns.Count == 0)
                {
                    vid_rabotTable.Columns.Add("Id", typeof(int));
                    vid_rabotTable.Columns.Add("Name_vid_rabot", typeof(string));
                }
                var vid_rabot = db.Vid_rabot;
                foreach (Vid_rabot p in vid_rabot)
                {
                    DataRow row = vid_rabotTable.NewRow();
                    row[0] = p.Id;
                    row[1] = p.Name_vid_rabot;
                    vid_rabotTable.Rows.Add(row);
                }
            }

            using (OborydContext db = new OborydContext())
            {
                DataTable oborydTable = new DataTable();
                if (oborydTable.Columns.Count == 0)
                {
                    oborydTable.Columns.Add("Id", typeof(int));
                    oborydTable.Columns.Add("Model_oboryd", typeof(string));
                }
                var oboryd = db.Oboryd;
                foreach (Oboryd s in oboryd)
                {
                    DataRow row = oborydTable.NewRow();
                    row[0] = s.Id;
                    row[1] = s.Model_oboryd;
                    oborydTable.Rows.Add(row);
                }
            }

            using (RaborContext db = new RaborContext())
            {
                var rabot = db.Rabor;
                foreach (Rabor app in rabot)
                {
                    DateTime data = app.Data_polychen;
                    DateTime data2 = app.Data_vipolnen;

                    if ((data >= d1 && data <= d2)|| (data2 >= d1 && data2 <= d2))
                    {
                        DataRow row = mainTable.NewRow();
                        row[0] = app.Id;

                        using (OborydContext db1 = new OborydContext())
                        {
                            Oboryd oboryd = db1.Oboryd.Where(s => s.Id == app.ID_oboryd).FirstOrDefault();
                            row[1] = oboryd.Model_oboryd;
                        }

                        using (Vid_rabotContext db2 = new Vid_rabotContext())
                        {
                            var vid_rabot = db2.Vid_rabot.Where(p => p.Id == app.ID_vid_rabot).FirstOrDefault();
                            row[2] = vid_rabot.Name_vid_rabot;
                        }
                        string[] d = app.Data_polychen.ToString().Split(' ');
                        string[] dd = app.Data_vipolnen.ToString().Split(' ');
                        row[3] = d[0];
                        row[4] = dd[0];
                        mainTable.Rows.Add(row);
                    }
                    
                }
                GridView1.DataSource = mainTable;
                GridView1.DataBind();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Get();
            }
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if(TextBox1.Text =="" || TextBox2.Text == "")
            {
                Get();
            }
            else if (TextBox1.Text != "" || TextBox2.Text != "")
            {
                GetData(DateTime.Parse(TextBox1.Text), DateTime.Parse(TextBox2.Text));
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            using (RaborContext db = new RaborContext())
            {
                foreach (GridViewRow rowInGrid in GridView1.Rows)
                {
                    CheckBox checkBox = (CheckBox)rowInGrid.FindControl("CheckBox1");
                    if (checkBox != null && checkBox.Checked)
                    {
                        int id = int.Parse(GridView1.Rows[rowInGrid.RowIndex].Cells[1].Text);
                        Rabor delId = db.Rabor.Where(s => s.Id == id).FirstOrDefault();
                        if (delId != null)
                        {
                            db.Rabor.Remove(delId);
                            db.SaveChanges();
                        }
                    }
                }
                Response.Redirect("WebForm1.aspx");
            }
                
        }
    }
}