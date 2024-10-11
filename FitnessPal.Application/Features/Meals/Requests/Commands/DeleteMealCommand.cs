using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPal.Application.Features.Meals.Requests.Commands
{
    public class DeleteMealCommand : IRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
    }
}
