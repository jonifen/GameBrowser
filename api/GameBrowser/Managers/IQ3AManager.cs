using GameBrowser.Models.Q3A;

namespace GameBrowser.Managers
{
    public interface IQ3AManager
    {
        ServerDetails GetServerDetails(string ipAddress, int port);
    }
}