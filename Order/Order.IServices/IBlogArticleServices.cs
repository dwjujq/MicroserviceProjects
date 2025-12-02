using Order.IServices.BASE;
using Order.Model.Models;
using Order.Model.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Order.IServices
{
    public interface IBlogArticleServices :IBaseServices<BlogArticle>
    {
        Task<List<BlogArticle>> GetBlogs();
        Task<BlogViewModels> GetBlogDetails(long id);

    }

}
