using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPal.Application.Features.Ingredients.Requests.Commands
{
    public class DeleteIngredientCommand : IRequest
    {
        public int Id { get; set; }
    }
}
