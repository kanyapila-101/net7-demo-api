using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ErrorOr;
using MediatR;
using net7_demo_api.Dtos;
using net7_demo_api.Entities;

namespace net7_demo_api.Handlers.Queries
{
    public class GetUserByIdQuery : IRequest<ErrorOr<UserDto>>
    {
        public int Id { get; }
        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
    }
    //public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, ErrorOr<UserDto>>
    //{
    //    //private readonly IUnitOfWork _uow;
    //    //private readonly IMapper _mapper;

    //    //public GetUserByIdQueryHandler(IUnitOfWork uow, IMapper mapper)
    //    //{
    //    //    _uow = uow;
    //    //    _mapper = mapper;
    //    //}

    //    //public async Task<ErrorOr<UserDto>> Handle(GetUserByIdQuery request,
    //    //    CancellationToken cancellationToken)
    //    //{
    //    //    var user = await _uow.Repository().GetById<UserModel>(request.Id);
    //    //    if (user is null)
    //    //        return Error.NotFound(code: "User not found", description:"Please enter the existing User Id" );

    //    //    return _mapper.Map<UserDto>(user);
    //    //}
    //}
}