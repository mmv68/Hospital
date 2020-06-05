using System.ComponentModel;

using AutoMapper;
using HMS.DataLayer.Context;
using HMS.Services.Contracts.App;
using HMS.Services.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HMS.Controllers
{
    [Authorize(Policy = ConstantPolicies.DynamicPermission)]
    [DisplayName("مدیریت و نگهداری اطلاعات مالی")]
    public class PersonPeymentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IPersonPaymentService _personPaymentService;
        private readonly IMapper _mapper;
        public PersonPeymentController(ApplicationDbContext context, IPersonPaymentService personPaymentService, IMapper mapper)
        {
            _context = context;
            _personPaymentService = personPaymentService;
            _mapper = mapper;
        }
        [DisplayName("لیست اطلاعات بانکی")]
        public IActionResult Index(int id, string title)
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
