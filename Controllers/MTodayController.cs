using EyeDropsDev.EData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using System.Xml;

namespace EyeDropsDev.Controllers
{
    public class Dosage
    {
      public  String Time;
      public String Drug;
    }
    public class MTodayController : ApiController
    {
        // GET api/mtoday
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/mtoday/5
        public HttpResponseMessage Get(int id)
        {
            EDrpsXmlHelper ehelper = new EDrpsXmlHelper();
            if (User.Identity.IsAuthenticated)
            {
                ehelper.SDocLocation = "http://www.diamondstardevelopment.com/EData/"+User.Identity.Name+"_Drugs.xml";
                ehelper.TDocLocation = "http://www.diamondstardevelopment.com/EData/" + User.Identity.Name + "_Schedule.xml";
                ehelper.load();
                XmlNodeList dosages = ehelper.getDay(2).Item(0).ChildNodes;

                List<Dosage> holder = new List<Dosage>
                {
                };
                for (int i = 0; i < dosages.Count; i++)
                {
                    XmlNodeList dos = dosages.Item(i).ChildNodes;

                        holder.Add(new Dosage{Time = dos.Item(0).InnerText, Drug = dos.Item(1).InnerText});
                }
              

                return Request.CreateResponse(HttpStatusCode.OK, new JavaScriptSerializer().Serialize(holder));
            }
          return Request.CreateResponse(HttpStatusCode.OK,new JavaScriptSerializer().Serialize( new string[] { "failed"}));
        }

        // POST api/mtoday
        public void Post([FromBody]string value)
        {
        }

        // PUT api/mtoday/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/mtoday/5
        public void Delete(int id)
        {
        }
    }
}
