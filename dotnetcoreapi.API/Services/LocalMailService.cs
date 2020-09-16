using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetcoreapi.API.Services
{
    public class LocalMailService
    {
        private readonly ILogger<LocalMailService> logger;
        private string _from = "abc@company.com";
        private string _to = "rec@company.com";

        public LocalMailService(ILogger<LocalMailService> logger)
        {
            this.logger = logger;
        }

        public void Send(string subject, string msg)
        {
            Debug.WriteLine($"Mail sent from {this._from} to {this._to}, with LocalMailService");
            Debug.WriteLine($"subject:{subject}");
            Debug.WriteLine($"Content:{msg}");

            logger.LogInformation($"Mail sent from {this._from} to {this._to}, with LocalMailService");
            logger.LogInformation($"subject:{subject}");
            logger.LogInformation($"Content:{msg}");

        }
    }
}
