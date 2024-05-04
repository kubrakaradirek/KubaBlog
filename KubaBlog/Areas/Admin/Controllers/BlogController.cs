using ClosedXML.Excel;
using KubaBlog.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace KubaBlog.Areas.Admin.Controllers
{
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
    }
}
