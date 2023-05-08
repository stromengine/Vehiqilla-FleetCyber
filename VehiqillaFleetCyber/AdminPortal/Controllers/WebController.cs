using AdminPortal.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using System.Web.Routing;

namespace AdminPortal.Controllers
{
    [Authorize]
    public partial class WebController : ApiController
    {
       
    }
}