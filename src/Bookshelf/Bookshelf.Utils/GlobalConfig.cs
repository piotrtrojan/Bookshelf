using Microsoft.Extensions.Configuration;
using System;

namespace Bookshelf.Utils
{
    public class GlobalConfig
    {
        public string CommandConnectionString { get; private set; }
        public string QueryConnectionString { get; private set; }
        public string IdentityConnectionString { get; private set; }
        public string JwtKey { get; private set; }
        public int JwtExpireDays { get; private set; }
        public string JwtIssuer { get; private set; }
        public string JwtAudience { get; private set; }
        public bool AddSwagger { get; private set; }

        public GlobalConfig(IConfiguration configuration)
        {
            SetFields(configuration);
        }

        private void SetFields(IConfiguration configuration)
        {
            if (string.IsNullOrEmpty(configuration["CommandConnectionString"]))
                throw new ArgumentException("CommandConnectionString is empty");
            if (string.IsNullOrEmpty(configuration["QueryConnectionString"]))
                throw new ArgumentException("QueryConnectionString is empty");
            if (string.IsNullOrEmpty(configuration["IdentityConnectionString"]))
                throw new ArgumentException("IdentityConnectionString empty");
            if (string.IsNullOrEmpty(configuration["JwtKey"]))
                throw new ArgumentException("JwtKey is empty");
            if (string.IsNullOrEmpty(configuration["JwtExpireDays"]) || !int.TryParse(configuration["JwtExpireDays"], out int jwtExpireDays))
                throw new ArgumentException("JwtExpireDays is empty");
            if (string.IsNullOrEmpty(configuration["JwtIssuer"]))
                throw new ArgumentException("JwtIssuer is empty");
            if (string.IsNullOrEmpty(configuration["JwtAudience"]))
                throw new ArgumentException("JwtAudience is empty");
            if (string.IsNullOrEmpty(configuration["AddSwagger"]) || !bool.TryParse(configuration["AddSwagger"], out bool addSwagger))
                throw new ArgumentException("AddSwagger is empty");

            CommandConnectionString = configuration["CommandConnectionString"];
            QueryConnectionString = configuration["QueryConnectionString"];
            IdentityConnectionString = configuration["IdentityConnectionString"];
            JwtKey = configuration["JwtKey"];
            JwtExpireDays = jwtExpireDays;
            JwtIssuer = configuration["JwtIssuer"];
            JwtAudience = configuration["JwtAudience"];
            AddSwagger = addSwagger;
        }
    }
}
