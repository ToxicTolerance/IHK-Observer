using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace IhkObserver.Observer.Classes
{
    [XmlRoot("Configuration")]
    public class XmlConfig
    {

        #region [Fields]
        private XmlConfig _config;
        #endregion

        #region[Properties]
        [XmlElement("Identifkationsnummer")]
        public string IdentNr { get; set; }

        [XmlElement("Prueflingsnummer")]
        public string PrueflingsNr { get; set; }
        #endregion

        #region [Constructor]
        public XmlConfig()
        {

        }
        public XmlConfig(string idNr, string prNr)
        {
            IdentNr = idNr;
            PrueflingsNr = prNr;
        }
        #endregion

        public void CreateXmlConfig(string idNr, string prNr)
        {
            #region [Argument Null Check ]
            ValidateArguments(idNr, prNr);
            #endregion


            _config = new XmlConfig(idNr, prNr);

        }

        public bool LoadXmlConfig(string path)
        {
            bool result = false;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(XmlConfig));

                _config = serializer.Deserialize(File.OpenRead(path)) as XmlConfig;

                result = true;
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        public void SaveXmlConfig(string FileName)
        {
            try
            {
                using (var writer = new System.IO.StreamWriter(FileName))
                {
                    var serializer = new XmlSerializer(this.GetType());
                    serializer.Serialize(writer, _config);
                    writer.Flush();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void ValidateArguments(string idNr, string prNr)
        {
            #region [Argument Null Check ]
            if (string.IsNullOrWhiteSpace(idNr))
            {
                throw new ArgumentNullException("idNr is null");
            }

            if (string.IsNullOrWhiteSpace(prNr))
            {
                throw new ArgumentNullException("prNr is null");
            }
            #endregion
        }
    }
}

