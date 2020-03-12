using Microsoft.Extensions.Configuration;
using System;

namespace Bookshelf.Utils.Config
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

        private const string GlobalConfigPrefix = "GlobalConfig:";

        public GlobalConfig(IConfiguration configuration)
        {
            SetFields(configuration);
        }

        private void SetFields(IConfiguration configuration)
        {
            if (string.IsNullOrEmpty(configuration[$"{GlobalConfigPrefix}CommandConnectionString"]))
                throw new ArgumentException("CommandConnectionString is empty");
            if (string.IsNullOrEmpty(configuration[$"{GlobalConfigPrefix}QueryConnectionString"]))
                throw new ArgumentException("QueryConnectionString is empty");
            if (string.IsNullOrEmpty(configuration[$"{GlobalConfigPrefix}IdentityConnectionString"]))
                throw new ArgumentException("IdentityConnectionString empty");
            if (string.IsNullOrEmpty(configuration[$"{GlobalConfigPrefix}JwtKey"]))
                throw new ArgumentException("JwtKey is empty");
            if (string.IsNullOrEmpty(configuration[$"{GlobalConfigPrefix}JwtExpireDays"])
                || !int.TryParse(configuration[$"{GlobalConfigPrefix}JwtExpireDays"], out int jwtExpireDays))
                throw new ArgumentException("JwtExpireDays is empty");
            if (string.IsNullOrEmpty(configuration[$"{GlobalConfigPrefix}JwtIssuer"]))
                throw new ArgumentException("JwtIssuer is empty");
            if (string.IsNullOrEmpty(configuration[$"{GlobalConfigPrefix}JwtAudience"]))
                throw new ArgumentException("JwtAudience is empty");
            if (string.IsNullOrEmpty(configuration[$"{GlobalConfigPrefix}AddSwagger"])
                || !bool.TryParse(configuration[$"{GlobalConfigPrefix}AddSwagger"], out bool addSwagger))
                throw new ArgumentException("AddSwagger is empty");

            CommandConnectionString = configuration[$"{GlobalConfigPrefix}CommandConnectionString"];
            QueryConnectionString = configuration[$"{GlobalConfigPrefix}QueryConnectionString"];
            IdentityConnectionString = configuration[$"{GlobalConfigPrefix}IdentityConnectionString"];
            JwtKey = configuration[$"{GlobalConfigPrefix}JwtKey"];
            JwtExpireDays = jwtExpireDays;
            JwtIssuer = configuration[$"{GlobalConfigPrefix}JwtIssuer"];
            JwtAudience = configuration[$"{GlobalConfigPrefix}JwtAudience"];
            AddSwagger = addSwagger;
        }
    }
}
