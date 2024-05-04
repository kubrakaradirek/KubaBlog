using KubaBlog.DataAccessLayer.Abstract;
using KubaBlog.DataAccessLayer.Concrete;
using KubaBlog.DataAccessLayer.Repositories;
using KubaBlog.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KubaBlog.DataAccessLayer.EntityFramework
{
    public class EfMessageRepository:GenericRepository<Message>,IMessageDal
    {
       
    }
}
