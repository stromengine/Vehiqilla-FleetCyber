using AdminPortal.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace CompanyPortal.Controllers
{

    [NotMapped]
    public class CaseViewModel : Case
    {
        public HttpPostedFileBase[] Attachments { set; get; }
    }

}