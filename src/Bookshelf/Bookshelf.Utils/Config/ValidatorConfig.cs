using Microsoft.Extensions.Configuration;
using System;

namespace Bookshelf.Utils.Config
{
    public class ValidatorConfig
    {
        public int MaxPageSize { get; set; }

        private const string ValidatorConfigPrefix = "ValidatorConfig:";
        public ValidatorConfig(IConfiguration configuration)
        {
            SetFields(configuration);
        }

        private void SetFields(IConfiguration configuration)
        {
            if (string.IsNullOrEmpty(configuration[$"{ValidatorConfigPrefix}MaxPageSize"]) 
                || !int.TryParse(configuration[$"{ValidatorConfigPrefix}MaxPageSize"], out int maxPageSize))
                throw new ArgumentException("MaxPageSize is empty");
            MaxPageSize = maxPageSize;
        }
    }
}
