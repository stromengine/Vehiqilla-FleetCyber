using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;
using System.Web.Script.Serialization;

namespace AdminPortal.Models
{

    public class NameValue
    {
        public int? ID { set; get; }
        public string StringID { set; get; }
        public string Name { set; get; }

        public string Value { set; get; }

        public static string Serialize(NameValue data)
        {
            string json = new JavaScriptSerializer().Serialize(data);
            return json;
        }

        public static NameValue Deserialize(string Json)
        {
            NameValue NM = null;
            try
            {
                NM = new JavaScriptSerializer().Deserialize<NameValue>(Json);
            }
            catch
            {
                NM = null;
            }
            return NM;
        }
    }
    [NotMapped]
    public class CompanyViewModel:Company
    {
      
    }
    [NotMapped]
    public class CategoryViewModel:Category
    {

    }
    [NotMapped]
    public class SupplierViewModel:Supplier
    {
       
    }
    [NotMapped]
    public class OemViewModel : Oem
    {

    }
    [NotMapped]
    public class AppViewModel : ECUApp
    {
        public int Category_ID { get; set; }
        public int Company_ID { get; set; }
        public int Oem_ID { get; set; }
        public int Supplier_ID { get; set; }
    }
}