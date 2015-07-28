using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Web.Services;

public partial class TEST_D3TEST : System.Web.UI.Page
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
     

        //LightORM TT36F = new LightORM(WebConfigurationManager.ConnectionStrings["AS400"].ConnectionString, _Type: ConnectType.ODBC);

        //TT36F.SQLStr = @"SELECT C30NM1 AS C30NM1, COUNT(*) AS C1 FROM TT36F.RDMC10 JOIN TT36F.RDMC30 ON C30KD ='01' AND BIGARA = C30NO GROUP BY C30NM1 ";

        //var obj = TT36F.GetDataByDapper();

        //foreach (var o in obj)
        //{
        //    XAxis += string.Format("\"{0}\",", o.C30NM1);
        //    YAxis += string.Format("{0},", o.C1);
        //}

        //XAxis = XAxis.Remove(XAxis.Length - 1);
        //YAxis = YAxis.Remove(YAxis.Length - 1);
      
        //TT36F.SQLStr = @"SELECT TRIM(C30NM1) AS name, COUNT(*) AS value FROM TT36F.RDMC10 JOIN TT36F.RDMC30 ON C30KD ='01' AND BIGARA = C30NO GROUP BY C30NM1 ";

        //obj = TT36F.GetDataByDapper<Serial>();

        //rtn = "[";

        //foreach (var o in obj)
        //{
        //    rtn += "{name:'" + o.name + "', value:" + o.value + "},";
        //}

        //rtn = rtn.Remove(rtn.Length - 1) + "]";      
    }

    [WebMethod]
    public static string GetData()
    {
        LightORM TT36F = new LightORM(WebConfigurationManager.ConnectionStrings["AS400"].ConnectionString, _Type: ConnectType.ODBC);

        TT36F.SQLStr = @"SELECT TRIM(C30NM1) AS name, COUNT(*) AS value FROM TT36F.RDMC10 JOIN TT36F.RDMC30 ON C30KD ='01' AND BIGARA = C30NO GROUP BY C30NM1"/* UNION SELECT '北美洲' name, 0 value FROM TT36F.RDMC10 UNION SELECT '南美洲' name, 0 value FROM TT36F.RDMC10"*/;

        var obj = TT36F.GetDataByDapper<Serial>();
        
    
        return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
    }

    public static string GetNameMap(string _geofile)
    {
        LightORM TTWEB = new LightORM(WebConfigurationManager.ConnectionStrings["TEST_TTWEB"].ConnectionString, _Type: ConnectType.SQLClient);

        TTWEB.SQLStr = string.Format(@"SELECT EnglishName ,ChineseName FROM TTWEB.dbo.GeoReferTable WHERE MapType = '{0}'",_geofile);

        var obj = TTWEB.GetDataByDapper<NameContainer>();

        if (obj.Count() > 0)
        {

            string rtn = "";

            foreach (var o in obj)
            {         
                rtn += "'" + o.EnglishName + "':'" + o.ChineseName + "',";
            }

            rtn = rtn.Remove(rtn.Length - 1) + "";

            return rtn;
        }
        else
        {
            return "";
        }
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