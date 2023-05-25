using Application.ResponseModel;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;

namespace ServiceCatalogUI.Controllers
{

    public abstract class ApiControllerBase<TModel>:ControllerBase
    {
        protected IMapper _mapper => HttpContext.RequestServices.GetRequiredService<IMapper>();
        
        protected IValidator<TModel> _validator => HttpContext.RequestServices.GetRequiredService<IValidator<TModel>>();

       
      
    }

}
