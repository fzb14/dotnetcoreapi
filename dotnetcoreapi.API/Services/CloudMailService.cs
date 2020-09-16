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
        private string _from = "abc@company.com";
        private string _to = "rec@company.com";

        public CloudMailService(ILogger<CloudMailService> logger)
        {
            this.logger = logger;
        }

        public void Send(string subject, string msg)
        {
            Debug.WriteLine($"Mail sent from {this._from} to {this._to}, with CloudMailService");
            Debug.WriteLine($"subject:{subject}");
            Debug.WriteLine($"Content:{msg}");

            logger.LogInformation($"Mail sent from {this._from} to {this._to}, with CloudMailService");
            logger.LogInformation($"subject:{subject}");
            logger.LogInformation($"Content:{msg}");

        }
    }
}
