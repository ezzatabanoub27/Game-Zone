
using Microsoft.EntityFrameworkCore;

namespace GameHUB.Services
{
    
    public class CateogriesServices : ICateogriesServices
    {
        private readonly ApplicationDBContext _Context;
        public CateogriesServices(ApplicationDBContext context)
        {
            _Context = context;
        }
        public IEnumerable<SelectListItem> GetSelectList()
        {
            return _Context.Cateogries
                .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).OrderBy(x => x.Text)
                .AsNoTracking()
                .ToList();

        }
    }
}
