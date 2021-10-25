using BlazorFileUpload.Shared;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorFileUpload.Server.Models
{
    public class ReadSelectedFileRepository : IReadSelectedFileRepository
    {
        private readonly AppDbContext appDbContext;

        public ReadSelectedFileRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Employee>> ReadSelectedFile(string strFile)
        {
            var FilePath = $"{Directory.GetCurrentDirectory()}{@"\wwwroot"}" + "\\" + strFile;
            FileInfo fileInfo = new FileInfo(FilePath);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            try
            {
                using (ExcelPackage package = new ExcelPackage(fileInfo))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();
                    int colCount = worksheet.Dimension.End.Column;
                    int rowCount = worksheet.Dimension.End.Row;
                    for (int row = 2; row <= rowCount; row++)
                    {
                        Employee emp = new Employee();
                        for (int col = 1; col <= colCount; col++)
                        {
                            if (col == 1) emp.FirstName = worksheet.Cells[row, col].Value.ToString();
                            else if (col == 2) emp.LastName = worksheet.Cells[row, col].Value.ToString();
                        }
                        appDbContext.Add(emp);
                        appDbContext.SaveChanges();
                    }
                }
               return await appDbContext.Employees.ToListAsync();
            }

            catch (DbUpdateException exception)
            {
                Trace.WriteLine(exception);
                return await appDbContext.Employees.ToListAsync();
            }
            catch (DbEntityValidationException e)
            {
                Trace.WriteLine(e);
                return await appDbContext.Employees.ToListAsync();
            }
            finally
            {
               
            }

        }

     
    }
}
