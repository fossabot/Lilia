﻿using System.Threading.Tasks;
using Discord.Interactions;
using Lilia.Services;
using Serilog;

namespace Lilia.Modules;

public class OwnerModule : InteractionModuleBase<ShardedInteractionContext>
{
	[SlashCommand("shutdown", "Shutdown the bot")]
	[RequireOwner]
	public async Task OwnerShutdownCommand()
	{
		await Context.Interaction.DeferAsync();

		Log.Logger.Warning("Shutting down");

		await Context.Interaction.ModifyOriginalResponseAsync(x =>
			x.Content = "Goodbye");

		LiliaClient.Cts.Cancel();
	}
}
