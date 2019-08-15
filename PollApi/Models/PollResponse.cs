using OptionDataAccess;
using PollDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PollApi.Models
{
    public class PollResponse
    {
        public List<Poll> _pollDetails { get; set; }
        public List<Option> _optionDetails { get; set; }
    }
}