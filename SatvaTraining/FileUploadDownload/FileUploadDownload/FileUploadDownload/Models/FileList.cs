using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace FileUploadDownload.Models
{
    public class FileList
    {
      
        [Required]
        [DataType(DataType.Upload)]
        public HttpPostedFileBase File { get; set; }
        
    }
}