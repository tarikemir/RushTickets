using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushTickets.Persistence.Configurations
{
    public static class TicketConfigurations
    {
        public static string GetString(string key)
        {
            ConfigurationManager configurationManager = new();

            string path = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName}/Infrastructure/RushTickets.Persistence";


            configurationManager.SetBasePath(path);
            configurationManager.AddJsonFile("PrivateInformations.json");
            return configurationManager.GetSection(key).Value;
        }
    }
}
