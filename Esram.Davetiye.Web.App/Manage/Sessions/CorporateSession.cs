using Esram.Davetiye.Web.App.Models.Entities;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Esram.Davetiye.Web.App.Manage.Sessions
{
    public static class CorporateSession
    {
        public static void SetCorporate(this ISession session, string key, Corporate value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static Corporate GetCorporate(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? null : JsonConvert.DeserializeObject<Corporate>(value);
        }

        public static Corporate Corporate { get; set; }
    }
}
