

using GameHUB.Services;

namespace GameHUB.Controllers
{
    public class GamesController : Controller
    {
        private readonly ICateogriesServices _cateogriesServices;
        private readonly IDevicesServices _devicesServices;
        private readonly IGameServices _gameServices;


        public GamesController(
            ICateogriesServices cateogriesServices,
            IDevicesServices devicesServices, IGameServices gameServices)
        {
            _cateogriesServices = cateogriesServices;
            _devicesServices = devicesServices;
            _gameServices = gameServices;
        }
        public IActionResult Index()
        {
            var games = _gameServices.GateAll();
            return View(games);
        }
        public IActionResult Details (int id)
        {
            var game = _gameServices.GetById(id);

            if (game is null)
            {
                return NotFound();
            }
            return View(game);
        }

        [HttpGet]
        public IActionResult Create()
        {
            CreateGameFormViewModel viewModel = new()
            {
                Cateogries = _cateogriesServices.GetSelectList(),
            Devices = _devicesServices.GetDevices()

            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var game = _gameServices.GetById(id);

            if (game is null)
            {
                return NotFound();
            }
            EditGameFormModel viewmodel = new()
            {
                Id=game.Id,
                Name=game.Name,
                Description=game.Description,
                cateogryId=game.cateogryId,
                SelectedDevices=game.gameDevices.Select(d=> d.deviceId).ToList(),
                Cateogries=_cateogriesServices.GetSelectList(),
                Devices=_devicesServices.GetDevices(),
                CurrentCover=game.Cover
            };
            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Create(CreateGameFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Cateogries = _cateogriesServices.GetSelectList();
                model.Devices = _devicesServices.GetDevices();


                return View(model);
            }
            await _gameServices.create(model);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditGameFormModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Cateogries = _cateogriesServices.GetSelectList();
                model.Devices = _devicesServices.GetDevices();


                return View(model);
            }

          var game =  await _gameServices.Update(model);
            if (game is null)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpDelete]
        public IActionResult Delete (int id)
        {
            var isDeleted = _gameServices.Delete(id);
           
            return isDeleted ? Ok(): BadRequest();
        }

    }



    

}
