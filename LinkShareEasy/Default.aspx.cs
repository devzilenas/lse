using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LinkShareEasyLib;
using LinkShareEasyModel;

namespace LinkShareEasy
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Once the user enters a link generate a token.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            //Save request.
            TokenRequest tokenRequest = new TokenRequest() { LinkHref = TextBox1.Text, RequestedOn = DateTime.Now }; 


            //Next assign a token to this request.
            TextBox2.Text = "Token appears here";
        }
    }
}