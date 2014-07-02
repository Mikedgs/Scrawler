using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Scrawler.Controllers
{
    public class ChatController : Controller
    {
        [HttpGet]
        public void Index(int id)
        {
            // look up id in chatroom db
            // redirect to action using that id so user does not see original url
            
        }

        public void Other()
        {
            // do something
        }
    }
}