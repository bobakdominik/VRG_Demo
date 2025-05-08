using HeightMapApp.Models;
using HeightMapApp.Services;

namespace HeightMapApp.Commands
{
    internal class DeleteCircleCommand : CommandBase
    {
        private readonly CircleRepository _circleRepository;

        public DeleteCircleCommand(CircleRepository circleRepository)
        {
            _circleRepository = circleRepository;
        }

        public override void Execute(object? parameter)
        {
            var circle = parameter as TwoPointCircle;
            if (circle != null)
            {
                _circleRepository.RemoveCircle(circle);
            }
        }
    }
}
