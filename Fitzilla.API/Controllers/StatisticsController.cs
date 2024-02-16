using AutoMapper;
using Fitzilla.DAL.IRepository;
using Fitzilla.DAL.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fitzilla.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StatisticsController(IUnitOfWork unitOfWork, IMapper mapper) : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
}
