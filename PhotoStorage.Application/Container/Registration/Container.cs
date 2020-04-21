﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using PhotoStorage.Common.Interfaces;

namespace PhotoStorage.Application.Container.Registration
{
    public static class Container
    {
        public static void RegisterModules(IServiceCollection services)
        {
            foreach (var module in GetRegistrationModules())
            {
                module.Register(services);
            }
        }

        private static IEnumerable<IRegistrationModule> GetRegistrationModules()
        {
            return typeof(Container)
                .Assembly
                .GetTypes()
                .Where(t => typeof(IRegistrationModule).IsAssignableFrom(t) && t.IsClass)
                .Select(t => (IRegistrationModule)Activator.CreateInstance(t));
        }
    }
}
