namespace Resources.Enteties.IRepositories
{
    public interface IDatabaseCleaner
    {
        Task DeleteDbAsync();
        Task CreateDbAsync();
    }
}
