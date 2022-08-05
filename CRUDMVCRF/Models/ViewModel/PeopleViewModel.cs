using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CRUDMVCRF.Models.ViewModel
{
    public class PeopleViewModel
    {
        public int Id { get; set; }
        [DisplayName("Nombre")]
        public string Name { get; set; }
        [DisplayName("edad")]
        public int?  Age { get; set; }

    }

}