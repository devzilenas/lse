using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LinkShareEasyADO;
using System.Data;
using LinkShareEasyModel;

namespace LinkShareEasy
{
    public partial class Transfer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void AdRotator_AdCreated(object sender, AdCreatedEventArgs e)
        {
            ADOLinkShareEasyConfig alsec = new ADOLinkShareEasyConfig();

            //Let's add http if not present.
            UriBuilder ub = new UriBuilder(Server.UrlDecode(Request.Params["url2"]));
            if (String.IsNullOrEmpty(ub.Scheme))
            {
                ub.Scheme = "http";
            }

            Response.AddHeader("REFRESH", String.Format("{0:d};url={1}", alsec.Find().TransferAfterSeconds, ub.Uri));
        }
    }
}