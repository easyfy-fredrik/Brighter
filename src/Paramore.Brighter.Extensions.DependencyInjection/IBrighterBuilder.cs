﻿using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Paramore.Brighter.Extensions.DependencyInjection
{
    /// <summary>
    /// Constructs Brighter message mappers and handlers
    /// </summary>
    public interface IBrighterBuilder
    {
        /// <summary>
        /// Scan the assemblies provided for implementations of IHandleRequests, IHandleRequestsAsync, IAmAMessageMapper and register them with ServiceCollection
        /// </summary>
        /// <param name="assemblies">The assemblies to scan</param>
        /// <returns></returns>
        IBrighterBuilder AutoFromAssemblies(params Assembly[] assemblies);
        
        /// <summary>
        /// Register handers with the built in subscriber registry
        /// </summary>
        /// <param name="registerHandlers">A callback to register handlers</param>
        /// <returns>This builder, allows chaining calls</returns>
        IBrighterBuilder Handlers(Action<IAmASubscriberRegistry> registerHandlers);
        
        /// <summary>
        /// Scan the assemblies provided for implementations of IHandleRequests and register them with ServiceCollection
        /// </summary>
        /// <param name="assemblies">The assemblies to scan</param>
        /// <returns>This builder, allows chaining calls</returns>
        IBrighterBuilder HandlersFromAssemblies(params Assembly[] assemblies);
        
        /// <summary>
        /// Scan the assemblies provided for implementations of IHandleRequestsAsyn and register them with ServiceCollection
        /// </summary>
        /// <param name="registerHandlers">A callback to register handlers</param>
        /// <returns>This builder, allows chaining calls</returns>
        IBrighterBuilder AsyncHandlers(Action<IAmAnAsyncSubcriberRegistry> registerHandlers);
        
        /// <summary>
        /// Scan the assemblies provided for implementations of IHandleRequests and register them with ServiceCollection 
        /// </summary>
        /// <param name="assemblies">The assemblies to scan</param>
        /// <returns>This builder, allows chaining calls</returns>
        IBrighterBuilder AsyncHandlersFromAssemblies(params Assembly[] assemblies);
        
        /// <summary>
        /// Register message mappers
        /// </summary>
        /// <param name="registerMappers">A callback to register mappers</param>
        /// <returns>This builder, allows chaining calls</returns>
        IBrighterBuilder MapperRegistry(Action<ServiceCollectionMessageMapperRegistry> registerMappers);
        
        /// <summary>
        /// Scan the assemblies provided for implementations of IAmAMessageMapper and register them with ServiceCollection
        /// </summary>
        /// <param name="assemblies">The assemblies to scan</param>
        /// <returns>This builder, allows chaining calls</returns>
        IBrighterBuilder MapperRegistryFromAssemblies(params Assembly[] assemblies);

        /// <summary>
        /// The IoC container to populate
        /// </summary>
        IServiceCollection Services { get; }
    }
}
