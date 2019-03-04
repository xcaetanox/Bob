using System;
using System.ComponentModel;
using System.Collections.Generic;
using Bobson.Core.DTO;
using System.ComponentModel.DataAnnotations;

namespace Bobson.UI.Web
{
    public class ConfigEmailViewModel
    {
        public IEnumerable<System.Web.Mvc.SelectListItem> Roles { get; set; }
        
        [DisplayName("Regra de Acesso")]
        public string Role { get; set; }

        public string UserId { get; set; }

    }
}

