using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using EindopdrachtBackEnd.Services;
using EindopdrachtBackEnd.Models;


namespace EindOpdrachtBackend.Test
{
    public class CustomApiWebApplicationFactory: WebApplicationFactory<EindopdrachtBackEnd.Startup>
    {
     
    }
}