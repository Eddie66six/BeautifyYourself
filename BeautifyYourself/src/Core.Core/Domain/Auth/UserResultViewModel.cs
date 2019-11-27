using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Core.Domain.Auth
{
    public class UserResultViewModel
    {
        public string token { get; set; }
        public dynamic user { get; set; }
    }
}
