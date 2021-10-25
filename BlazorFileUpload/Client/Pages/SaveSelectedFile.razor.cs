using BlazorFileUpload.Client.Services;
using BlazorFileUpload.Shared;
using BlazorFileUpload.Shared.Models;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorFileUpload.Client.Pages
{
    public partial class SaveSelectedFile
    {
       // [Parameter]
        public List<Employee> Employees { get; set; }
        private string UploadMessage = "No file(s) uploaded";
        [Inject]
        public IReadSelectedFileService ExcelFileService { get; set; }
        private async Task UploadOneFile(Microsoft.AspNetCore.Components.Forms.IBrowserFile file)
        {
            long maxFileSize = 1024 * 1024 * 15;
            using (var ms = new MemoryStream())
            {
                await file.OpenReadStream(maxFileSize).CopyToAsync(ms);

                var uploadedFile = new UploadedFile();
                uploadedFile.FileName = file.Name;
                uploadedFile.FileContent = ms.ToArray();

                await Http.PostAsJsonAsync<UploadedFile>(Configuration["ApiBaseUrl"] +
                    "FileUpload/PostFile", uploadedFile);
                UploadMessage = file.Name + " was uploaded";
            }
        }

        private async Task SaveContentFile(Microsoft.AspNetCore.Components.Forms.IBrowserFile file)
        {
           
            Employees = (await ExcelFileService.ReadSelectedFile(file.Name)).ToList();
        }

       
        

    }
}
