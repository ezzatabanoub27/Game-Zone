
using Microsoft.EntityFrameworkCore;

namespace GameHUB.Services
{
    public class DevicesServices : IDevicesServices
    {
        private readonly ApplicationDBContext _Context;
        public DevicesServices(ApplicationDBContext context)
        {
            _Context = context;
        }
        public IEnumerable<SelectListItem> GetDevices()
        {
            return _Context.Devices
                .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).OrderBy(x => x.Text)
                .AsNoTracking()
                .ToList();
        }
    }
}
