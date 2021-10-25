
using BlazorFileUpload.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorFileUpload.Server.Models
{
    public interface IReadSelectedFileRepository
    {
        Task<IEnumerable<Employee>> ReadSelectedFile(string strFile);
       
    }
}
