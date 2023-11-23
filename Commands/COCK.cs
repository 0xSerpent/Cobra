/*
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using HtmlAgilityPack;

namespace NiggaBalls
{
    public class PostCmdModule : ModuleBase<SocketCommandContext>
    {
        private readonly Random random = new Random();
        private readonly HttpClient httpClient = new HttpClient();
        private const string Domain = "r34.app";
        private const string Tags = "juuzou_suzuya"


        [Command("fetchpost")];
        public async Task FetchPostAsync()
        {
            string url = $"https://123.app/?domain={Domain}&page=0&tags={Tags}";
            try
            {
                string htmlContent = await httpClient.GetStringAsync(url);
                // this nigga  so retarded :broken_heart: again why r u writing aa scrape cmd nigga this is pysillon copy ok.
                // you'll see
                //pls fix it i wanna fucking compile niga what r u tryna scrape ? imgs!!! grrrr. i see now blud scrapiing femboys.be.sexy
                var htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(htmlContent);
                var imageLinks = new List<string>();
                var imageNodes = htmlDocument.DocumentNode.SelectNodes("/img[@src]")
                if (imageNodes != null)
                {
                    foreach (var imageNode in imageNodes)
                    {
                        string imageUrl = imageNode.GetAttributeValue("src", "");
                        // no image links boooooo
                        if (!string.IsNullOrWhiteSpace(imageUrl) && (imageUrl.EndsWith(".jpg") || imageUrl.EndsWith(".png")))
                        {
                            imageLinks.Add(imageUrl);
                        }
                    }
                }

                if (imageLinks.Count > 0)
                {
                    int randomIndex = random.Next(0, imageLinks.Count);
                    string randomImageUrl = imageLinks[randomIndex];

                    await ReplyAsync(randomImageUrl); // bro wtf
                    
                }
                else
                {
                    await ReplyAsync("waa waa no images found");
                }
            }
            catch (HttpRequestException)
            {
                await ReplyAsync("boowomp something broke"); // broked!!
                
            }
        }
    }
}

*/