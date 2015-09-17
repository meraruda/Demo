using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Demo.EChart
{
    public partial class MapChart : System.Web.UI.Page
    {
        //protected string XAxis;
        //protected string YAxis;
        //protected string rtn;
        protected string AREA
        {
            get
            {
                string ar = Request["AR"] ?? "";

                switch (ar)
                {
                    case "亞洲":
                        return "asia.geo";
                    case "歐洲":
                        return "europe.geo";
                    case "非洲":
                        return "africa.geo";
                    case "大洋洲":
                        return "oceania.geo";
                    case "南美洲":
                        return "south-america.geo";
                    case "北美洲":
                        return "north-america.geo";
                    case "Taiwan":
                        return "tw-all.geo";
                    case "Japan":
                        return "jp-all.geo";
                    case "China":
                        return "cn-all.geo";
                    case "Malaysia":
                        return "my-all.geo";
                    case "Russia":
                        return "ru-all-disputed.geo";
                    default:
                        return "world-continents.geo";
                }

            }
        }
        protected string URL
        {
            get
            {
                if (Request.Url.Query.Length > 0)
                    return this.Request.Url.AbsoluteUri.Replace(Request.Url.Query, "");
                else
                    return this.Request.Url.AbsoluteUri;
            }
        }

        protected string NameMap
        {
            get
            {
                return GetNameMap(AREA);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string GetData()
        {
            return "[{\"name\":\"南美洲\",\"value\":1727},{\"name\":\"大洋洲\",\"value\":380},{\"name\":\"歐洲\",\"value\":196},{\"name\":\"北美洲\",\"value\":100},{\"name\":\"亞洲\",\"value\":1427},{\"name\":\"非洲\",\"value\":177}]";
        }

        public static string GetNameMap(string _geofile)
        {
            return "'Africa':'非洲','Asia':'亞洲','Europe':'歐洲','North America':'北美洲','Oceania':'大洋洲','South America':'南美洲'";
        }
    }

    public class Serial
    {
        public string name { get; set; }
        public int value { get; set; }

        public Serial()
        {

        }

        public Serial(string _name, int _value)
        {
            name = _name;
            value = _value;
        }
    }

    public class NameContainer
    {
        public string EnglishName { get; set; }
        public string ChineseName { get; set; }

        public NameContainer()
        {

        }
    }
}