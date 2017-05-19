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
            TextBox1.Attributes.Add("placeholder", "Paste link here");
            LinkButton1.Attributes.Add("data-placement", "button");
            LinkButton1.Attributes.Add("type", "button");

            TextBox1.Focus();
        }

        /// <summary>
        /// Once the user enters a link generate a token.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            //Save request.
            TokenRequest tokenRequest = new TokenRequest() { LinkHref = TextBox1.Text, RequestedOn = DateTime.Now, TokenTypeId = Convert.ToInt32(RadioButtonList1.SelectedValue), TokenTypeText = RadioButtonList1.SelectedItem.Text};
            TokenFactory tf = new TokenFactory();
            IToken    token = tf.GetToken(tokenRequest);

            //Next assign a token to this request.
            TextBox2.Text = token.TokenText;
        }

        protected void RadioButtonList1_DataBound(object sender, EventArgs e)
        {
            RadioButtonList1.SelectedIndex = 0;
        }
    }
}