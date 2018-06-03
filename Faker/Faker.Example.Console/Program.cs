﻿using Faker.Example.Console.Models.Services;
using Faker.Example.Console.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Example.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new CompanyService();

            var HomeViewModel = new HomeViewModel(service);

            HomeViewModel.ExecuteUpdateAsync(null).Wait();            
        }
    }
}
