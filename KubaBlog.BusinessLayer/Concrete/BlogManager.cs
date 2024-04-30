using KubaBlog.BusinessLayer.Abstract;
using KubaBlog.DataAccessLayer.Abstract;
using KubaBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KubaBlog.BusinessLayer.Concrete
{
	public class BlogManager : IBlogService
	{
		IBlogDal _blogDal;

		public BlogManager(IBlogDal blogDal)
		{
			_blogDal = blogDal;
		}

		public void BlogAdd(Blog Blog)
		{
			_blogDal.Insert(Blog);
		}

		public void BlogDelete(Blog Blog)
		{
			_blogDal.Delete(Blog);
		}

		public void BlogUpdate(Blog Blog)
		{
			_blogDal.Update(Blog);
		}

        public List<Blog> GetBlogLisWithCategory()
        {
            return _blogDal.GetListWithCategory();
        }

        public Blog GetById(int id)
		{
			return _blogDal.GetById(id);
		}
		public List <Blog> GetBlogById(int id) 
		{
			return _blogDal.GetListAll(x => x.BlogId == id);
		}

		public List<Blog> GetList()
		{
			return _blogDal.GetListAll();
		}

		public List<Blog> GetBlogListByWriter(int id)
		{
			return _blogDal.GetListAll(x => x.WriterId == id);
		}
	}
}
