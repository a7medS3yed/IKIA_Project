using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BLL.Service.Attachment
{
    public interface IAttachement
    {
        public string? Upload(IFormFile file, string folderName);
        public bool Delete(string filePath);
    }
}
