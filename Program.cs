using System;
using Discord;
using Discord.Webhook;
using Discord.WebSocket;
using Discord.Commands;
using Events;
using System.Reflection;


// hi stealth
public class Program {

    public DiscordSocketClient? Client;
    private DiscordSocketConfig GetSerpentConfig() {

        return new DiscordSocketConfig() {GatewayIntents = GatewayIntents.All};
    }
    public async Task MainAsync() {
        string Token = File.ReadAllText("./token.txt").Trim();
        
        Client = new DiscordSocketClient(GetSerpentConfig());
        
       

        Client.Log += Events.Logging.Log;
        Client.Ready += Events.Logging.Ready;
        Client.MessageReceived += Events.Messaging.MessageReceive;
        Client.InteractionCreated += Events.Logging.HandleInteractions;

        await Client.LoginAsync(TokenType.Bot,Token);

        await Client.StartAsync();
        
        await Task.Delay(-1);

    }
    public static Task Main() => new Program().MainAsync();



};