﻿using AppTemplate.Database;
using AppTemplate.Web;
using Core.Tests.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AppTemplate.InterationTesting
{
    public abstract class IntegrationTest : IntegrationTest<DataContext, Startup>
    {
        protected IntegrationTest(TestApplicationFactory<DataContext, Startup> factory) : base(factory)
        {
        }
    }

    [AutoRollback]
    public abstract class IntegrationTest<TDbContex, TStartup>
    where TDbContex : DbContext
    where TStartup : class
    {
        private readonly TestApplicationFactory<TDbContex, TStartup> factory;

        protected virtual bool CreateTransaction => false;

        protected readonly TDbContex DataContext;

        protected readonly IServiceProvider Services;

        private readonly IServiceScope scope;

        protected IntegrationTest(TestApplicationFactory<TDbContex, TStartup> factory)
        {
            this.factory = factory;
            factory.Server.PreserveExecutionContext = true;

            scope = factory.Services.CreateScope();
            Services = scope.ServiceProvider;

            DataContext = scope.ServiceProvider.GetRequiredService<TDbContex>();

        }

        public virtual void Dispose()
        {
            scope?.Dispose();
        }
    }
}
