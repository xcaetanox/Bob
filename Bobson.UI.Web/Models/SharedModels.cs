using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bobson.UI.Web.Models
{
    public class LayoutModel
    {
        public IEnumerable<SelectListItem> Propostas { get; set; }
    }
}