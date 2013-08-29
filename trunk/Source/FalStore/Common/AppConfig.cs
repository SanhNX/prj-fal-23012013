using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Common
{
    public static class AppConfig
    {
        /// <summary>
        /// ConnectionString
        /// </summary>
        public static readonly string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
    
    }
}
