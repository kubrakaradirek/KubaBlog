﻿using KubaBlog.BusinessLayer.Abstract;
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
            throw new NotImplementedException();
        }

        public List<Comment> GetList(int id)
        {
            return _commentDal.GetListAll(x=>x.BlogId == id);
        }
    }
}
