using Bookshelf.Contract.Base;
using Bookshelf.Utils;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Bookshelf.Application
{
    /// <summary>
    /// Contains extensions of <see cref="IServiceCollection">IServiceCollection</see> to register QueryHandlers and CommandHandlers.
    /// Additionally, registers class decorators.
    /// </summary>
    public static class RegisterDependencies
    {
        /// <summary>
        /// Registers Decorators, QueryHandlers and CommandHandlers.
        /// </summary>
        /// <param name="services"></param>
        public static void RegisterCommandQueryHandlers(this IServiceCollection services)
        {
            services.AddSingleton<AppExecutor>();

            var handlers = typeof(RegisterDependencies).Assembly.GetTypes()
                .Where(q => q.GetInterfaces().Any(y => IsHandlerInterface(y)))
                .Where(x => x.Name.EndsWith("Handler"))
                .ToList();

            foreach (var type in handlers)
            {
                AddHandler(services, type);
            }
        }

        private static bool IsHandlerInterface(Type type)
        {
            if (!type.IsGenericType)
                return false;
            var typeDefinition = type.GetGenericTypeDefinition();
            return typeDefinition == typeof(ICommandHandler<>) || typeDefinition == typeof(IQueryHandler<,>);
        }

        private static void AddHandler(IServiceCollection services, Type type)
        {
            var attributes = type.GetCustomAttributes(false);
            var pipeline = attributes
                .Select(x => ToDecorator(x))
                .Concat(new[] { type })
                .Reverse()
                .ToList();
            var interfaceType = type.GetInterfaces().Single(x => IsHandlerInterface(x));
            var factory = BuildPipeline(pipeline, interfaceType);
            services.AddTransient(interfaceType, factory);
        }

        private static Type ToDecorator(object attribute)
        {
            var type = attribute.GetType();
            //if (type == typeof(CommandLogAtribute))
            //    return typeof(CommandLogDecorator<>);

            // other decorators/attributes goes here.
            throw new ArgumentException($"Unknown Decorator registred: {type.Name}.");

        }

        private static Func<IServiceProvider, object> BuildPipeline(ICollection<Type> pipeline, Type interfaceType)
        {
            var ctors = pipeline
                .Select(q =>
                {
                    Type type = q.IsGenericType ? q.MakeGenericType(interfaceType.GenericTypeArguments) : q;
                    return type.GetConstructors().Single();
                })
                .ToList();
            object func(IServiceProvider provider)
            {
                object current = null;
                foreach (ConstructorInfo ctor in ctors)
                {
                    List<ParameterInfo> paramsInfo = ctor.GetParameters().ToList();
                    object[] parameters = GetParameters(paramsInfo, provider);
                    current = ctor.Invoke(parameters);
                }
                return current;
            }
            return func;
        }

        private static object[] GetParameters(List<ParameterInfo> parameterInfos, IServiceProvider provider)
        {
            var result = new object[parameterInfos.Count];
            for (int i = 0; i < parameterInfos.Count; i++)
            {
                result[i] = GetParamter(parameterInfos[i], provider);
            }
            return result;
        }

        private static object GetParamter(ParameterInfo parameterInfo, IServiceProvider provider)
        {
            var parameterType = parameterInfo.ParameterType;
            object service = provider.GetService(parameterType);
            if (service != null)
                return service;
            throw new ArgumentException($"The type {parameterType} not found.");
        }
    }
}
