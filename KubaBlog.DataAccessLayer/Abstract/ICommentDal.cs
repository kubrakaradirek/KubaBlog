using KubaBlog.EntityLayer.Concrete;

namespace KubaBlog.DataAccessLayer.Abstract
{
    public interface ICommentDal : IGenericDal<Comment>
    {
        List<Comment> GetListWithBlog();
    }
}
