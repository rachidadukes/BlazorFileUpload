using BlazorFileUpload.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorFileUpload.Client.Services
{
    public interface IReadSelectedFileService
    {
       
        Task<IEnumerable<Employee>> ReadSelectedFile(string strFile);

        
    }
}
