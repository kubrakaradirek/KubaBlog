using ClosedXML.Excel;
using KubaBlog.Areas.Admin.Models;
using KubaBlog.DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;

namespace KubaBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class BlogController : Controller
    {
        //Excellden bilgi çekmek için
        public IActionResult ExportStaticExcelBlogList()
        {
            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Blog Listesi");
                workSheet.Cell(1, 1).Value = "Blog Id";
                workSheet.Cell(1, 2).Value = "Blog Adı";

                int BlogRowCount = 2;
                foreach (var item in GetBlogList())
                {
                    workSheet.Cell(BlogRowCount, 1).Value = item.Id;
                    workSheet.Cell(BlogRowCount,2).Value=item.BlogName;
                    BlogRowCount++;
                }
                using(var stream=new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content=stream.ToArray();
                    return File(content,"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet","Calisma1.xlsx");
                }
            };
        }
        public IActionResult ExportDinamicExcelBlogList()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi");
                worksheet.Cell(1, 1).Value = "BlogID";
                worksheet.Cell(1, 2).Value = "Blog Adı";
                int BlogRowCount = 2;
                foreach (var item in GetDinamicBlogList())
                {
                    worksheet.Cell(BlogRowCount, 1).Value = item.Id;
                    worksheet.Cell(BlogRowCount, 2).Value = item.BlogName;
                    BlogRowCount++;
                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var context = stream.ToArray();
                    return File(context, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Dosya.xlsx");
                }
            }
        }
        public List<BlogModel> GetDinamicBlogList()
        {
            var bm = new List<BlogModel>();
            using (var c = new Context())
            {
                bm = c.Blogs.Select(x => new BlogModel
                {
                    Id = x.BlogId,
                    BlogName = x.BlogTitle
                }).ToList();
            }
            return bm;
        }
        public List<BlogModel> GetBlogList()
        {
            List<BlogModel> bm = new List<BlogModel>
            {
                new BlogModel {Id=1,BlogName="C# Programlamaya Giriş"},
                new BlogModel {Id=2,BlogName="Tesla Firmasının Araçları"},
                new BlogModel {Id=3,BlogName="2020 Olimpiyatları"}
            };
            return bm;
        }
        public IActionResult BlogListExcel()
        {
            return View();
        }
    }
}
