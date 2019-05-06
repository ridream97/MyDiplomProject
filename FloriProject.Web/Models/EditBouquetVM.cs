using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FloriProject.Web.Models
{
    public class EditBouquetVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public byte[] Photo { get; set; }

        public HttpPostedFileBase NewPhoto { get; set; }
    }
}   