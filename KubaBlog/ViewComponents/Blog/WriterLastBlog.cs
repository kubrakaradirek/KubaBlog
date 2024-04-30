using KubaBlog.BusinessLayer.Concrete;
using KubaBlog.DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace KubaBlog.ViewComponents.Blog
{
	public class WriterLastBlog:ViewComponent
	{
		BlogManager bm = new BlogManager(new EfBlogRepository());
		public IViewComponentResult Invoke()
		{
			var values = bm.GetBlogListByWriter(2);
			return View(values);
		}
	}
}
