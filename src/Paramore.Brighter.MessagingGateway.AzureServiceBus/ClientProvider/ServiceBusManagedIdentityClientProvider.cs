﻿using System;
using Azure.Identity;
using Azure.Messaging.ServiceBus;
using Azure.Messaging.ServiceBus.Administration;

namespace Paramore.Brighter.MessagingGateway.AzureServiceBus.ClientProvider
{
    
    /// <summary>
    /// Provides Azure Service Bus Clients using Managed Identity Credentials.
    /// </summary>
    public class ServiceBusManagedIdentityClientProvider : IServiceBusClientProvider
    {
        private readonly string _fullyQualifiedNameSpace;

        /// <summary>
        /// Initializes an implementation is <see cref="IServiceBusClientProvider"/> using Managed Identity for Authentication.
        /// </summary>
        /// <param name="fullyQualifiedNameSpace">The Fully Qualified Namespace i.e. my-servicebus.azureservicebus.net</param>
        /// <exception cref="ArgumentNullException">Throws is the namespace is null</exception>
        public ServiceBusManagedIdentityClientProvider(string fullyQualifiedNameSpace)
        {
            if (string.IsNullOrEmpty(fullyQualifiedNameSpace))
            {
                throw new ArgumentNullException(nameof(fullyQualifiedNameSpace),
                    "Configuration is null, ensure this is set in the constructor.");
            }
            
            _fullyQualifiedNameSpace = fullyQualifiedNameSpace;
        }
        
        /// <summary>
        /// Provides an Azure Service Bus Client
        /// </summary>
        /// <returns>Azure Service Bus Client</returns>
        public ServiceBusClient GetServiceBusClient()
        {
            return new ServiceBusClient(_fullyQualifiedNameSpace, new ManagedIdentityCredential());
        }
        /// <summary>
        /// Provides an Azure Service Bus Administration Client
        /// </summary>
        /// <returns>Azure Service Bus Administration Client</returns>
        public ServiceBusAdministrationClient GetServiceBusAdministrationClient()
        {
            return new ServiceBusAdministrationClient(_fullyQualifiedNameSpace, new ManagedIdentityCredential());
        }
    }
}