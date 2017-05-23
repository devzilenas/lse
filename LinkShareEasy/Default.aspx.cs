using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LinkShareEasyLib;
using LinkShareEasyModel;
using LinkShareEasyADO;

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
            TokenRequest tokenRequest = new TokenRequest() 
            {
                LinkHref = TextBox1.Text
                , RequestedOn = DateTime.Now
                , TokenTypeId = Convert.ToInt32(RadioButtonList1.SelectedValue)
                , TokenTypeText = RadioButtonList1.SelectedItem.Text 
            };

            //Save token request 
            ADOTokenRequest atr = new ADOTokenRequest();
            tokenRequest = atr.Insert(tokenRequest);
 
            Token token;
            switch (tokenRequest.TokenTypeText)
            {
                case "Numeric":
                    token = new TokenGenerator().MakeNumeric(tokenRequest);
                    break;
                default:
                    throw new NotImplementedException(String.Format("Token type {0}", tokenRequest.TokenTypeText));                  
            }

            tokenRequest.TokenId = token.TokenId;
            atr.UpdateTokenId(tokenRequest);

            //Next assign a token to this request.
            TextBox2.Text = token.TokenText;
        }

        protected void RadioButtonList1_DataBound(object sender, EventArgs e)
        {
            RadioButtonList1.SelectedIndex = 0;
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            ADOLinkRequest alr = new ADOLinkRequest();

            LinkRequest lr = alr.Insert(
                new LinkRequest()
            { 
                RequestedOn = DateTime.Now,
                Token = TextBox3.Text                
            });

            //Get a link for the token.
                //Let's get token
            ADOToken at = new ADOToken(); 
            Token token = at.FindValid(lr.Token);

            if (token == null || token.IsExpired)
            {
                Response.Redirect("TokenNotValid.aspx");
                return;
            }

            ADOTokenType att = new ADOTokenType();
            TokenType tt = att.ById(token.TokenTypeId); 

            //Now get Token request for this token.
            ADOTokenRequest atr = new ADOTokenRequest();
            TokenRequest tr = atr.FindFor(token);
            
            bool expired = tr.RequestedOn.AddSeconds(token.ValidForDurationSeconds) <= DateTime.Now;
            
            if (expired)
                //Token request is too late.
            {
                Response.Redirect("TokenExpired.aspx");
                return; 
            }
            else
            { 
                //Expire token
                at.Expire(token);

                //Make token available again
                switch (tt.TokenTypeText)
                {
                    case "Numeric":
                        ADONumericToken ant = new ADONumericToken();
                        ant.SetUsed(token.TokenText, false);
                        break;
                    case "Alpha":
                        break;
                }

                Response.Redirect(String.Format("Transfer.aspx?url={0}", Server.UrlEncode(tr.LinkHref)));
                return;
            } 
        } 
    }
}