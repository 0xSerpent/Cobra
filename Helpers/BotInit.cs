using Discord;
using Discord.WebSocket;


namespace Cobra.Helpers.Initializer;



public static class CobraInitializor {



    public static string token = "MTE1NjcwNjg0NDk4Nzg5NTkwOA.G8tFCH.cc-ExZULvbYw1Jru4zjHYDMZB7DWKuo6kYoIb8";

    public static async Task Initialize(DiscordSocketClient CobraClient) {


        await CobraClient.LoginAsync(TokenType.Bot , token);
        await CobraClient.StartAsync();


        

    }
}

