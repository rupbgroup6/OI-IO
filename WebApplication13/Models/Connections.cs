using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication13.Models
{
    public class Connections
    {
        private string profileA;
        private string profileB;

        public string ProfileB { get => profileB; set => profileB = value; }
        public string ProfileA { get => profileA; set => profileA = value; }
    }
}