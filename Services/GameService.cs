
using Microsoft.AspNetCore.Hosting.StaticWebAssets;
using System.Diagnostics.Eventing.Reader;
using System.Text;

namespace GameHUB.Services
{
    public class GameServices : IGameServices
    {
        private readonly ApplicationDBContext _Context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string _imagespath;




        public GameServices(ApplicationDBContext context,IWebHostEnvironment webHostEnvironment)
        {
            _Context = context;
            _webHostEnvironment = webHostEnvironment;
            _imagespath = $"{_webHostEnvironment.WebRootPath}/assets/images/games";
        }



        public IEnumerable<Game> GateAll()
        {
            
            var games = _Context.Games
                .Include(g=> g.cateogry)
                .Include(g=>g.gameDevices)
                .ThenInclude(d=>d.device)
                .AsNoTracking() 
                .ToList();
            
            return games;
        }
        public Game? GetById(int id)
        {
            var games = _Context.Games
                .Include(g => g.cateogry)
                .Include(g => g.gameDevices)
                .ThenInclude(d => d.device)
                .AsNoTracking()
                .SingleOrDefault(d=> d.Id == id);
            return games;
        }



        public async Task create(CreateGameFormViewModel model)
        {
            var coverName = await saveCover(model.Cover);

            Game game = new()
            {
                Name=model.Name,
                Description=model.Description,
                cateogryId=model.cateogryId,
                Cover=coverName,
                gameDevices=model.SelectedDevices.Select(d=> new GameDevice { deviceId =d }).ToList()

            };
            _Context.Add(game);
            _Context.SaveChanges();

        }

      public async Task<Game?> Update(EditGameFormModel model)
      {
            var game = _Context.Games.Include(g => g.gameDevices).SingleOrDefault(g => g.Id == model.Id);
            if (game == null)
            {
                return null;
            }
            var hasNeCover =model.Cover is not null;
            var oldCover = game.Cover;
            game.Name = model.Name;
            game.Description = model.Description;
            game.gameDevices=model.SelectedDevices.Select(d=> new GameDevice { deviceId=d }).ToList();
            game.cateogryId = model.cateogryId;

            if (hasNeCover)
            {
                game.Cover = await saveCover(model.Cover!);
            }

            var effictedRows = _Context.SaveChanges();

            if (effictedRows > 0)
            {
                if (hasNeCover)
                {
                    var cover = Path.Combine(_imagespath, oldCover);
                    File.Delete(cover);
                }
                return game;
            }
            else
            {

                var cover = Path.Combine(_imagespath, game.Cover);
                File.Delete(cover);

                return null;

            }
           


        }
        public bool Delete(int id)
        {
            var isDeleted = false;
            var game = _Context.Games.Find(id);
            if (game is null)
            {
                return isDeleted;
            }
            _Context.Remove(game);

            var effectedRows = _Context.SaveChanges();
            if (effectedRows> 0)
            {
                isDeleted = true;
                var cover = Path.Combine(_imagespath, game.Cover);
                File.Delete(cover);


            }
            return isDeleted;
        }

        private async Task<string> saveCover(IFormFile cover)
        {
            var coverName = $"{Guid.NewGuid()}{Path.GetExtension(cover.FileName)}";

            var path = Path.Combine(_imagespath, coverName);

            using var stream = File.Create(path);
            await cover.CopyToAsync(stream);
            stream.Dispose();
            return coverName;
        }

        
    }
}
