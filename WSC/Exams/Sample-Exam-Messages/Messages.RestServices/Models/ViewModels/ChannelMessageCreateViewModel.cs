using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Messages.RestServices.Models.ViewModels
{
    public class ChannelMessageCreateViewModel
    {
        public int Id { get; set; }

        public string Message { get; set; }
    }
}