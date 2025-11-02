using KYCCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYCCore.Models
{
    public class Email
    {
        public bool Preferred { get; init; }
        public string? EmailAddress { get; init; }
    }
}
