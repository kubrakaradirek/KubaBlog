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
    public class EfMessage2Reposiyory : GenericRepository<Message2>, IMessage2Dal
    {
        public List<Message2> GetListWithMessageByWriter(int id)
        {
            using (var c = new Context())
            {
                return c.Message2s.Include(x => x.SenderUser).Where(x => x.ReceiverId == id).ToList();
            }
        }
    }
}
