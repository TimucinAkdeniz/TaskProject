﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProject.Application.Interfaces;
using TaskProject.Persistance.Context;
using TaskProject.Persistance.Repositories;

namespace TaskProject.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<TaskProjectContext>(opt =>
            {
                opt.UseNpgsql(configuration.GetConnectionString("Local"));
            });

            services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
        }
    }
}
