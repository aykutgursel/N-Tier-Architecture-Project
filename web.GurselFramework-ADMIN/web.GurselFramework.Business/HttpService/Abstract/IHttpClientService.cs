namespace web.GurselFramework.Business.HttpService.Abstract
{
    public interface IHttpClientService<T>
    {
        T PostType(string route, object data = null, int userId = -1, string computerName = "");
        T GetType(string route, object data = null, int userId = -1, string computerName = "");
        string FileType(string route, string file);
    }
}
