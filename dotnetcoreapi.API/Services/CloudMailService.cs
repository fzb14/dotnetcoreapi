using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetcoreapi.API.Services
{
    public class CloudMailService : IMailService
    {
        private readonly ILogger<CloudMailService> logger;
        private readonly IConfiguration configuration;

        public CloudMailService(ILogger<CloudMailService> logger, IConfiguration configuration)
        {
            this.logger = logger;
            this.configuration = configuration;
        }

        public void Send(string subject, string msg)
        {
            Debug.WriteLine($"Mail sent from {configuration["mailSettings:mailFrom"]} to {configuration["mailSettings:mailTo"]}, with CloudMailService");
            Debug.WriteLine($"subject:{subject}");
            Debug.WriteLine($"Content:{msg}");

            logger.LogInformation($"Mail sent from {configuration["mailSettings:mailFrom"]} to {configuration["mailSettings:mailTo"]}, with CloudMailService");
            logger.LogInformation($"subject:{subject}");
            logger.LogInformation($"Content:{msg}");

        }
    }
}
