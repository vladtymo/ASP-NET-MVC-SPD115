namespace AspNet_MVC_SPD115.Helpers
{
    public interface IFileService
    {
        Task<string> SaveFileAsync(IFormFile file);
    }
}
