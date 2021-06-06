using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Proiect.Models
{
    [Serializable]
    [XmlRoot("product")]
    class ProductImportMedaData
    {

        [XmlElement("id")]
        public string Id { get; set; }
       
        [XmlElement("name")]
        public string Name { get; set; }
         [XmlElement("price")]
        public Nullable<decimal> Price { get; set; }

        [XmlElement("quantity")]
        public Nullable<int> Quantity { get; set; }


    }
    [MetadataType(typeof(ProductImportMedaData))]
    public partial class ProductImport
    { }
}
