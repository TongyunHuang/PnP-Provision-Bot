﻿using Microsoft.Extensions.DependencyInjection;
using System;

namespace PnPNotifier.Bot.Commands
{
    public class CommandsFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public CommandsFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public BaseCommand ResolveCommandHandler(string command)
        {
            switch (command)
            {
                case "Configure PnP notifications": return _serviceProvider.GetRequiredService<ConfigureNotificationsCommand>();
                //case "Configure PnP notifications": throw new Exception($"success here '{command}'");

                default: throw new Exception($"Unable to find a command with key '{command}'");
            }
        }
    }
}
