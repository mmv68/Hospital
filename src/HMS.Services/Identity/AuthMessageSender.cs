using HMS.Common.GuardToolkit;
using HMS.Services.Contracts.Identity;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using HMS.ViewModels.Identity.Settings;
using DNTCommon.Web.Core;

namespace HMS.Services.Identity
{
    /// <summary>
    /// More info: http://www.YaZahra.YaAli/post/2551
    /// And http://www.YaZahra.YaAli/post/2564
    /// </summary>
    public class AuthMessageSender : ISmsSender
    {

        public Task SendSmsAsync(string number, string message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }
}