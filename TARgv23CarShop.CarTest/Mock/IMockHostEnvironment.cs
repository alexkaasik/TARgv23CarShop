﻿using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace TARgv23CarShop.CarTest.Mock
{
    public class IMockHostEnvironment : IHostEnvironment
    {
        public string EnvironmentName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ContentRootPath { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IFileProvider ContentRootFileProvider { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
