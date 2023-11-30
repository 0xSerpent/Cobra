using Discord.Commands;



[Group("!")]


public class Test : ModuleBase<SocketCommandContext>
{

    [Command("nigga")]

    public async Task nigga() {

        await Context.Channel.SendMessageAsync("nigga what");
    }


    
}
