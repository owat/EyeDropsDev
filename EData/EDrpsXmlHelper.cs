using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace EyeDropsDev.EData
{
    public class EDrpsXmlHelper
    {

        public EDrpsXmlHelper()
        {
            this.tdoc = new XmlDocument();
            this.sdoc = new XmlDocument();
        }
        //this is the xml document used for data storage
        private XmlDocument sdoc;
        private XmlDocument tdoc;

        //this denotes the relative location of the xml document
        private string sdocLocation;
        private string tdocLocation;

        //this is the accessor for the XML document
        public XmlDocument SDoc
        {
            get
            {
                return sdoc;
            }

        }


        //this is the accessor for the XML document
        public XmlDocument TDoc
        {
            get
            {
                return tdoc;
            }

        }

        //this is the accessor for the XML document
        public String SDocLocation
        {
            get
            {
                return sdocLocation;
            }
            set
            {
                this.sdocLocation = value;
            }
        }
        //this is the accessor for the XML document
        public String TDocLocation
        {
            get
            {
                return tdocLocation;
            }
            set
            {
                this.tdocLocation = value;
            }
        }

        public void load()
        {
            SDoc.Load(sdocLocation);
            TDoc.Load(tdocLocation);
        }

        public XmlNode getSchedule()
        {
            return TDoc.SelectSingleNode("/schedule");
        }

        public XmlNode getDrugs()
        {
            return SDoc.SelectSingleNode("/drugs");
        }
       public  XmlNodeList getUserDrugs()
        {
            SDoc.Load(sdocLocation);
            XmlNode drugs = getDrugs();
            return drugs.SelectNodes("drug");

        }

        public XmlNodeList getDay(int day)
        {
            TDoc.Load(tdocLocation);
            XmlNode schedule = getSchedule();
            switch (day)
            {
                case 1:
                    {
                        return schedule.SelectNodes("sunday");
                        break;
                    }
                case 2:
                    {
                        return schedule.SelectNodes("monday");
                        break;
                    }
                case 3:
                    {
                        return schedule.SelectNodes("tuesday");
                        break;
                    }
                case 4:
                    {
                        return schedule.SelectNodes("wednesday");
                        break;
                    }
                case 5:
                    {
                        return schedule.SelectNodes("thursdayday");
                        break;
                    }
                case 6:
                    {
                        return schedule.SelectNodes("friday");
                        break;
                    }
                case 7:
                    {
                        return schedule.SelectNodes("saturday");
                        break;
                    }
            }
            return null;
        }
    }
}