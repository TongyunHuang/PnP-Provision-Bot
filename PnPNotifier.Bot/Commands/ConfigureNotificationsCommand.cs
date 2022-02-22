﻿using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Teams;
using Microsoft.Bot.Schema;
using PnPNotifier.Common.Notifications;
using PnPNotifier.Bot.Cards.Managers;
using System.Threading;
using System.Threading.Tasks;

namespace PnPNotifier.Bot.Commands
{
    public class ConfigureNotificationsCommand : BaseCommand
    {
        private readonly NotificationsManager _notificationsManager;
        private readonly ConfigureNotificationsCardManager _cardManager;

        public ConfigureNotificationsCommand(NotificationsManager notificationsManager, ConfigureNotificationsCardManager cardManager)
        {
            _notificationsManager = notificationsManager;
            _cardManager = cardManager;
        }

        public override async Task HandleAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            var channelId = turnContext.Activity.TeamsGetChannelId();

            var notificationsEnabled = await _notificationsManager.IsNotificationsEnabledAsync(channelId); // err

            var card = _cardManager.CreateCard(notificationsEnabled);

            await turnContext.SendActivityAsync(MessageFactory.Attachment(card.ToAttachment()));
        }
    }
}
