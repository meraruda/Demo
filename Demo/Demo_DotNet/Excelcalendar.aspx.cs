using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Demo
{
    public partial class Excelcalendar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {                          
         
        }

        private static List<Week> Create52Week()
        {
            List<Week> WeekCollection = new List<Week>();
            Week Weekobj = null;
            int Index = 0;

            for (DateTime Date = new DateTime(DateTime.Now.Year, 1, 1); Date <= new DateTime(DateTime.Now.Year, 12, 31); Date = Date.AddDays(1))
            {

                if (Weekobj != null && Weekobj.Month != Date.Month)
                {
                    Index = 1;
                    WeekCollection.Add(Weekobj);
                    Weekobj = new Week(Date.Month, Index);
                }

                if (Date == new DateTime(DateTime.Now.Year, 1, 1) || Date.DayOfWeek == DayOfWeek.Sunday)
                {
                    Index++;
                    Weekobj = new Week(Date.Month, Index);
                }        

                switch (Date.DayOfWeek)
                {
                    case DayOfWeek.Sunday:
                        Weekobj.Sun = Date.Day.ToString();
                        break;
                    case DayOfWeek.Monday:
                        Weekobj.Mon = Date.Day.ToString();
                        break;
                    case DayOfWeek.Tuesday:
                        Weekobj.Tue = Date.Day.ToString();
                        break;
                    case DayOfWeek.Wednesday:
                        Weekobj.Wed = Date.Day.ToString();
                        break;
                    case DayOfWeek.Thursday:
                        Weekobj.Thu = Date.Day.ToString();
                        break;
                    case DayOfWeek.Friday:
                        Weekobj.Fri = Date.Day.ToString();
                        break;
                    case DayOfWeek.Saturday:
                        Weekobj.Sat = Date.Day.ToString();
                        WeekCollection.Add(Weekobj);
                        break;
                    default:
                        break;
                }

                if (Date == new DateTime(DateTime.Now.Year, 12, 31))
                    WeekCollection.Add(Weekobj);
            }
          
            return WeekCollection;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            GridStyle style = null;         

            Hashtable list = new Hashtable();
            list.Add("S1",new GridStyle1());
            list.Add("S2",new GridStyle2());
            list.Add("S3", new GridStyle3());

            style = (GridStyle)list[RadioButtonList1.SelectedValue];

            List<Week> weeks = Create52Week();
            string html = "";

            for (int i = 1; i <= 12; i++)
            {
                var source =
                  from week in weeks
                  where week.Month == i
                  select new
                  {
                      SUN = week.Sun,
                      MON = week.Mon,
                      TUE = week.Tue,
                      WED = week.Wed,
                      THU = week.Thu,
                      FRI = week.Fri,
                      SAT = week.Sat
                  };


                GridView gv = style.Draw();                
                gv.DataSource = source;
                gv.RowDataBound += gv_RowDataBound;

                gv.DataBind();



                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                gv.RenderControl(hw);

                html += string.Format("<table><tr style=\"background-color:{0};color:{1};\" ><td colspan=\"7\" style=\"text-align: center;\">"
                    , System.Drawing.ColorTranslator.ToHtml(gv.HeaderStyle.BackColor)
                    , System.Drawing.ColorTranslator.ToHtml(gv.HeaderStyle.ForeColor)                    
                    ) + i + "月</td></tr></table>";
                html += sw.ToString();
            }
     

            string filename = DateTime.Now.Year.ToString() + "_Calendar";
            string strfileext = ".xls";
     
            HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
            HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + strfileext);
            HttpContext.Current.Response.Write("<meta http-equiv=Content-Type content=text/html;charset=utf-8>");
            HttpContext.Current.Response.Write(html);
            HttpContext.Current.Response.End();

        }

        void gv_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].ForeColor = System.Drawing.ColorTranslator.FromHtml("#8b0000");
                e.Row.Cells[0].Font.Bold = true;
                e.Row.Cells[6].ForeColor = System.Drawing.ColorTranslator.FromHtml("#8b0000");
                e.Row.Cells[6].Font.Bold = true;
            }
        }
    }

    public class Week
    {
        public int Month { get; private set; }
        public int WeekIndex { get; private set; }
        public string Sun { get; set; }
        public string Mon { get; set; }
        public string Tue { get; set; }
        public string Wed { get; set; }
        public string Thu { get; set; }
        public string Fri { get; set; }
        public string Sat { get; set; }

        public Week()
        {

        }

        public Week(int month, int index)
        {
            Month = month;
            WeekIndex = index;
        }
    }

    public interface GridStyle
    {
        GridView Draw();
    }
    public class GridStyle1 : GridStyle
    {
        public GridView Draw()
        {
            GridView gv = new GridView();

            gv.BorderStyle = System.Web.UI.WebControls.BorderStyle.None;
            gv.HeaderStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507CD1");
            gv.HeaderStyle.Font.Bold = true;
            gv.HeaderStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");            
            gv.FooterStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507CD1");
            gv.FooterStyle.Font.Bold = true;
            gv.FooterStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
            gv.AlternatingRowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#e8ecef");
            gv.AlternatingRowStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
            gv.RowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");

            gv.ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
            gv.BorderWidth = Unit.Pixel(1);
            gv.CellPadding = 4;
            gv.GridLines = GridLines.None;
            gv.Font.Size = FontUnit.Smaller;

            return gv;                                             
        }
    }
    public class GridStyle2 : GridStyle
    {
        public GridView Draw()
        {
            GridView gv = new GridView();
            
            gv.HeaderStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#4A3C8C");
            gv.HeaderStyle.Font.Bold = true;
            gv.HeaderStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#F7F7F7");
            gv.FooterStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#B5C7DE");            
            gv.FooterStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#4A3C8C");
            gv.AlternatingRowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#F7F7F7");
            gv.RowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E7E7FF");
            gv.RowStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#4A3C8C");

            gv.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
            gv.BorderColor = System.Drawing.ColorTranslator.FromHtml("#E7E7FF");
            gv.BorderWidth = Unit.Pixel(1);
            gv.BorderStyle = BorderStyle.None;
            gv.CellPadding = 3;
            gv.GridLines = GridLines.Horizontal;
            gv.Font.Size = FontUnit.Smaller;
                                                                     
            return gv;
        }
    }
    public class GridStyle3 : GridStyle
    {                     
        public GridView Draw()
        {
            GridView gv = new GridView();

            gv.BorderStyle = System.Web.UI.WebControls.BorderStyle.None;
            gv.HeaderStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#990000");
            gv.HeaderStyle.Font.Bold = true;
            gv.HeaderStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
            gv.FooterStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#990000");
            gv.FooterStyle.Font.Bold = true;
            gv.FooterStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
            gv.AlternatingRowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
            gv.RowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFBD6");
               gv.RowStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333");

            gv.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333");
            gv.BorderWidth = Unit.Pixel(1);
            gv.CellPadding = 4;
            gv.GridLines = GridLines.None;
            gv.Font.Size = FontUnit.Smaller;

            return gv;
        }
    }
}