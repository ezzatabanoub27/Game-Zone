namespace GameHUB.Services
{
    public interface ICateogriesServices
    {
        IEnumerable<SelectListItem> GetSelectList();
    }
}
