using KubaBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KubaBlog.BusinessLayer.Abstract
{
	public interface IBlogService:IGenericService<Blog>
	{
		List<Blog> GetBlogLisWithCategory();
		List<Blog> GetBlogListByWriter(int id);
	}
}
