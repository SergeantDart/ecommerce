using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using API.Dtos;
using Microsoft.Extensions.Configuration;
using AutoMapper;

namespace API.Helpers
{
    public class ProductUrlResolver : IValueResolver<Product, ProductToReturnDto, string>
    {

        private readonly IConfiguration _config;

        public ProductUrlResolver(IConfiguration config) {
            _config = config;
        }
        public string Resolve(Product source, ProductToReturnDto destination, string destMamber, ResolutionContext context) {
            if (!string.IsNullOrEmpty(source.PictureUrl)) {
                return _config["ApiUrl"] + source.PictureUrl;
            }
            return null;
        }
    }
}