using Api.Commands.Product;
using Api.Entities;
using Api.Requests.Product;
using Api.Responses.Product;
using AutoMapper;

namespace Api.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductRequest, CreateProductCommand>();
            CreateMap<Product, ProductDto>();
        }
    }
}
