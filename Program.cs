// See https://aka.ms/new-console-template for more 

using Discord;
using Discord.WebSocket;



namespace DiscordBotOnDotNet // Note: actual namespace depends on the project name.
{
    public class Program
    {
        private readonly DiscordSocketClient _client;

        private const string _token = "OTI2MDY0MjE0NzczMjE1MjYy.Yc2Ogg.vA0lU-Puy7YjkXfBHn__eGbSxxY";

        public Program()
        {
            _client = new DiscordSocketClient();
            
            _client.Log += LogAsync;
            _client.Ready += ReadyAsync;
            _client.MessageReceived += MessageRecieveTask;
        }
        public static void Main(string[] args)
        {
            new Program().MainAsync().GetAwaiter().GetResult();
        }

        public async Task MainAsync()
        {
            await _client.LoginAsync(TokenType.Bot, _token);
            await _client.StartAsync();

            await Task.Delay(Timeout.Infinite);
        }

        private Task LogAsync(LogMessage log)
        {
            Console.WriteLine(log.ToString());
            return Task.CompletedTask;
        }

        private Task ReadyAsync()
        {
            Console.WriteLine($"{_client.CurrentUser} is connected!");
            
            return Task.CompletedTask;
        }

        private async Task MessageRecieveTask(SocketMessage message)
        {
            if (message.Author.Id == _client.CurrentUser.Id)
            {
                return;
            }

            if (message.Content == "!ping")
            {
                Console.WriteLine("Got ping!");
                await message.Channel.SendMessageAsync("pong!");
            }
        }
    }
}







