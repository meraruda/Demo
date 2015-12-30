using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.Scripts
{
    /// <summary>
    /// GetJSON 的摘要描述
    /// </summary>
    public class GetJSON : IHttpHandler
    {

        List<Department> DEPS = new List<Department>();   

        public void ProcessRequest(HttpContext context)
        {                                      
            DEPS.Add(new Department("3100","Department","3000"));
            DEPS.Add(new Department("3110","Section_A","3100"));
            DEPS.Add(new Department("3111","Group_1","3110"));
            DEPS.Add(new Department("3112","Group_2","3110"));
            DEPS.Add(new Department("3140","Section_B","3100"));
            DEPS.Add(new Department("3141","Group_3","3140"));
            DEPS.Add(new Department("3142","Group_4","3140"));
            DEPS.Add(new Department("3150","Section_C","3100"));
            DEPS.Add(new Department("3151","Group_5","3150"));
            DEPS.Add(new Department("3152","Group_6","3150"));

            List<Department> tree = new List<Department>();

            Department root = DEPS.Where(x => x.P01DEP == DEPS.Min(s => s.P01DEP)).First();

            tree.Add(getChild(root));

            context.Response.ContentType = "application/json";
            context.Response.Charset = "utf-8";
            context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(tree));                                           
        }
        
        public Department getChild (Department pDEP)
        {                        
            List<Department> o = DEPS.Where(x => x.P01UDP == pDEP.P01DEP).ToList();
            
            if(o.Count() > 0)
            {                                
                foreach(Department dep in o)
                {                    
                    getChild(dep);   
                }

                pDEP.Childs = o.ToList(); 
            }

            return pDEP;
        }
        
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }

    public class Department
    {
        public string P01DEP { get; set; }
        public string P01SNM { get; set; }
        public string P01UDP { get; set; }
        public List<Department> Childs { get; set; }

        public Department()
        {

        }

        public Department(string pP01DEP, string pP01SNM, string pP01UDP, List<Department> pChilds = null)
        {
            P01DEP = pP01DEP;
            P01SNM = pP01SNM;
            P01UDP = pP01UDP;
            Childs = pChilds;
        }
    }
}