using OptionDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PollApi.Models
{
    public class PollRequest
    {
        public int ID { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public List<Option> options { get; set; }
    }
}