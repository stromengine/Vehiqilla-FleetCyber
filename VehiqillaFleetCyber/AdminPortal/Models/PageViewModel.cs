using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    public class CompanyViewModel
    {
        public int ID { set; get; }
        public string Name { set; get; }
        public string Abbreviation { set; get; }
        [StringLength(250)]
        public string DisplayName { set; get; }

        public string logo { set; get; }
        [StringLength(250)]
        public string Address { set; get; }
        [StringLength(250)]
        public string Country { set; get; }
        public string Email { set; get; }
        public string Url { set; get; }

        public ICollection<ApplicationUser> Users { get; set; }

        public Company toModel()
        {
            Company c = new Company();
            c.Name = this.Name;
            c.Address = this.Address;
            c.Country = this.Country;
            c.Email = this.Email;
            c.Url = this.Url;
            c.ID = this.ID;
            return c;
        }

    }
}