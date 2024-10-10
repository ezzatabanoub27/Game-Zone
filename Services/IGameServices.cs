namespace GameHUB.Services
{
    public interface IGameServices
    {
        Task create(CreateGameFormViewModel model);
        IEnumerable<Game> GateAll();
        Game? GetById (int id);

        Task<Game?> Update(EditGameFormModel model);
        bool Delete(int id);
    }
}
