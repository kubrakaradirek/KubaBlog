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
    public class NewsLetterManager : INewsLetterService
    {
        INewsLetterDal _newsLetterDal;

        public NewsLetterManager(INewsLetterDal newsLetterDal)
        {
            _newsLetterDal = newsLetterDal;
        }

        public void AddNewsLetter(NewsLetter newsLetter)
        {
            _newsLetterDal.Insert(newsLetter);
        }
    }
}
