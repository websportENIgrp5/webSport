﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Web.WebPages.OAuth;
using WUI.Models;

namespace WUI
{
    public static class AuthConfig
    {
        public static void RegisterAuth()
        {
            // Pour permettre aux utilisateurs de ce site de se connecter à l’aide de leur compte à partir d’autres sites tels que Microsoft, Facebook et Twitter,
            // vous devez mettre à jour ce site. Pour plus d’informations, consultez la page http://go.microsoft.com/fwlink/?LinkID=252166

            //OAuthWebSecurity.RegisterMicrosoftClient(
            //    clientId: "3b69bf20-e814-4a76-b378-a53fe7ef106c",
            //    clientSecret: "gSOVbo61usqTOqJ6hist2Bs");

            //OAuthWebSecurity.RegisterTwitterClient(
            //    consumerKey: "",
            //    consumerSecret: "");

            //OAuthWebSecurity.RegisterFacebookClient(
            //    appId: "",
            //    appSecret: "");

            //OAuthWebSecurity.RegisterGoogleClient();
        }
    }
}
