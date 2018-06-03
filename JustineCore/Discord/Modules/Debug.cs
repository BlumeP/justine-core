using Discord;
using Discord.Commands;
using Discord.WebSocket;
using ImageMagick;
using JustineCore.Configuration;
using JustineCore.Discord.Features.Payloads;
using JustineCore.Discord.Preconditions;
using JustineCore.Discord.Providers.UserData;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JustineCore.Discord.Modules
{
    public class Debug : ModuleBase<SocketCommandContext>
    {
        private GlobalUserDataProvider _gudp;

        public Debug(GlobalUserDataProvider gudp)
        {
            _gudp = gudp;
        }

        [Command("OnAdventure")]
        [RequireOwner]
        public async Task DebugCmd(IGuildUser target)
        {
            var tName = target.Nickname??target.Username;
            
            if(!_gudp.GlobalDataExists(target.Id))
            {
                await ReplyAsync($"{tName} - No consent");
                return;
            }

            var onAdventure = _gudp.GetGlobalUserData(target.Id).RpgAccount.OnAdventure;

            await ReplyAsync($"{tName} - OnAdventure: {onAdventure}");
        }

        [Command("dbg-s")]
        [RequireOwner]
        public async Task TestingS()
        {
            await Context.Channel.SendFileAsync(new MemoryStream(Utility.GetMissionSuccessImage(Context.User, Utility.Random.Next(0, 100), Utility.Random.Next(0, 100), Utility.Random.Next(0, 100), Utility.Random.Next(0, 100))), "t.jpg");
        }

        [Command("dbg-f")]
        [RequireOwner]
        public async Task TestingF()
        {
            await Context.Channel.SendFileAsync(new MemoryStream(Utility.GetMissionFailureImage(Context.User, Utility.Random.Next(0, 100), Utility.Random.Next(0, 100), Utility.Random.Next(0, 100), Utility.Random.Next(0, 100))), "t.jpg");
        }
    }
}
