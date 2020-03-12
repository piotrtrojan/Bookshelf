using System;
using Microsoft.Extensions.Configuration;

namespace Bookshelf.Utils.Config
{
    public class LibraryConfig
    {
        public int MaxLoanDays { get; set; }
        private const string LibraryConfigPrefix = "LibraryConfig:";

        public LibraryConfig(IConfiguration configuration)
        {
            SetFields(configuration);
        }

        private void SetFields(IConfiguration configuration)
        {
            if (string.IsNullOrEmpty(configuration[$"{LibraryConfigPrefix}MaxLoanDays"]) 
                || !int.TryParse(configuration[$"{LibraryConfigPrefix}MaxLoanDays"], out int maxLoanDays))
                throw new ArgumentException("MaxLoanDays is empty");
            MaxLoanDays = maxLoanDays;
        }
    }
}
