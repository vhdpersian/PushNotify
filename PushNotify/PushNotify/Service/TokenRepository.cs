using PushNotify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PushNotify.Service
{
    public class TokenRepository
    {
        private static TokenRepository tokenRegisterRepository;
        private List<TokenRegister> list_token;
        public static TokenRepository GetInstanse()
        {
            if (tokenRegisterRepository == null)
            {
                tokenRegisterRepository = new TokenRepository();

            }
            return tokenRegisterRepository;
        }

        public void AddToken(String id_token)
        {
            var ctx = HttpContext.Current;
            if (ctx.Cache["token"] == null)
            {
                list_token = new List<TokenRegister>();
                list_token.Add(new TokenRegister { Id_Token = id_token });
                ctx.Cache["token"] = list_token;
            }
            else
            {
                list_token = (List<TokenRegister>)ctx.Cache["token"];
                var token= list_token.FirstOrDefault(r => r.Id_Token == id_token);

                // update
                if (token != null)
                {
                    token.Id_Token = id_token+"duplicate";
                    ctx.Cache["token"] = list_token;
                }
                // insert
                else
                {
                    list_token.Add(new TokenRegister { Id_Token = id_token });
                    ctx.Cache["token"] = list_token;
                }
            }
             
        }

        public List<String> GetToken()
        {
            List<String> tokens = new List<string>();
            var ctx = HttpContext.Current;
            var list_token = (List<TokenRegister>)ctx.Cache["token"];
            foreach (var item in list_token)
            {
                tokens.Add(item.Id_Token);
            }

            return tokens;
        }
        
    }
}