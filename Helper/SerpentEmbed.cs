using System;
using Discord;
using Discord.Webhook;
using Discord.WebSocket;


namespace Helper {


public class SerpentEmbed {

    public Embed GetEmbed(SerpentEmbeds EmbedType  , string Title , string Description) {

        switch(EmbedType) {
            case SerpentEmbeds.Default:
            return new EmbedBuilder() {
                Title = Title,
                Description = Description,
                Color = Color.DarkerGrey
                



            }.Build();

            case SerpentEmbeds.Success:

             return new EmbedBuilder() {
                Title = Title,
                Description = Description,
                Color = Color.Green




            }.Build();


            case SerpentEmbeds.Error:

             return new EmbedBuilder() {
                Title = Title,
                Description = Description,
                Color = Color.Red




            }.Build();


             case SerpentEmbeds.Warning:

             return new EmbedBuilder() {
                Title = Title,
                Description = Description,
                Color = Color.Orange




            }.Build();


            default:
             return new EmbedBuilder() {
                Title = Title,
                Description = Description,
                Color = Color.DarkerGrey


            }.Build();






            



            
            
        }

    }

}


}