using Inventory.IServices.BASE;
using Inventory.Model.Models;
using Inventory.Model.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inventory.IServices
{
    public interface IBlogArticleServices :IBaseServices<BlogArticle>
    {
        Task<List<BlogArticle>> GetBlogs();
        Task<BlogViewModels> GetBlogDetails(long id);

    }

}
