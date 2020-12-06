using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Бипит_8
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
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
                    DropDownList1.DataSource = oborydTable;
                    DropDownList1.DataTextField = "Model_oboryd";
                    DropDownList1.DataValueField = "Id";
                    DropDownList1.DataBind();
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
                    DropDownList2.DataSource = vid_rabotTable;
                    DropDownList2.DataTextField = "Name_vid_rabot";
                    DropDownList2.DataValueField = "Id";
                    DropDownList2.DataBind();
                }
            }

            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (RaborContext db = new RaborContext())
            {
                Rabor app = new Rabor() 
                {
                    ID_oboryd = int.Parse(DropDownList1.Text),
                    ID_vid_rabot = int.Parse(DropDownList2.Text), 
                    Data_polychen = DateTime.Parse(TextBox1.Text),
                    Data_vipolnen = DateTime.Parse(TextBox2.Text)
                };
                db.Rabor.Add(app);
                db.SaveChanges();
            }
            Response.Redirect("WebForm1.aspx");
        }
    }
}