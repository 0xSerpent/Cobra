using Discord;
using Discord.Webhook;
using Discord.WebSocket;

namespace Helper
{
    public class SerpentEmbed
    {
        public Embed GetEmbed(SerpentEmbeds embedType, string title, string description)
        {
            var embedBuilder = new EmbedBuilder()
            {
                Title = title,
                Description = description
            };

            switch (embedType)
            {
                case SerpentEmbeds.Default:
                    embedBuilder.Color = Color.DarkerGrey;
                    break;

                case SerpentEmbeds.Success:
                    embedBuilder.Color = Color.Green;
                    break;

                case SerpentEmbeds.Error:
                    embedBuilder.Color = Color.Red;
                    break;

                case SerpentEmbeds.Warning:
                    embedBuilder.Color = Color.Orange;
                    break;

                default:
                    embedBuilder.Color = Color.DarkerGrey;
                    break;
            }

            return embedBuilder.Build();
        }
    }
}