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
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public void CommentAdd(Comment comment)
        {
            _commentDal.Insert(comment);
        }

        public List<Comment> GetCommentWithBlog()
        {
            return _commentDal.GetListWithBlog();
        }

        public List<Comment> GetList(int id)
        {
            return _commentDal.GetListAll(x=>x.BlogId == id);
        }
        public void TDelete(Comment entity)
        {
            _commentDal.Delete(entity);
        }

        public List<Comment> TGetAll()
        {
            throw new NotImplementedException();
        }

        public Comment TGetById(int id)
        {
            return _commentDal.GetById(id);
        }

        public void TUpdate(Comment entity)
        {
            _commentDal.Update(entity);
        }
    }
}
