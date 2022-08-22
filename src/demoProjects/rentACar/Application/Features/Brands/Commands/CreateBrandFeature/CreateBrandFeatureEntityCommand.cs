using Application.Features.Brands.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.CreateBrandFeature
{
    public class CreateBrandFeatureEntityCommand : IRequest<CreatedBrandFeatureEntityDto>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;
        public CreateBrandFeatureEntityCommand(IMapper mapper, IBrandRepository brandRepository)
        {
            _mapper = mapper;
            _brandRepository = brandRepository;
        }
        public async Task<CreatedBrandFeatureEntityDto> Handle(CreateBrandFeatureEntityCommand request, CancellationToken cancellationToken)
        {

            Brand mappedSomeFeatureEntity = _mapper.Map<Brand>(request);
            Brand createdBrandFeatureEntity = await _brandRepository.AddAsync(mappedSomeFeatureEntity);
            CreatedBrandFeatureEntityDto createdSomeFeatureEntityDto = _mapper.Map<CreatedBrandFeatureEntityDto>(createdBrandFeatureEntity);
            return createdSomeFeatureEntityDto;
        }
    }
}
