using HeightMapApp.Models;
using HeightMapApp.Services;

namespace HeightMapApp.Commands
{
    /// <summary>
    /// Command to delete a circle from the repository.
    /// </summary>
    internal class DeleteCircleCommand : CommandBase
    {
        private readonly CircleRepository _circleRepository;

        /// <summary>
        /// Constructor for DeleteCircleCommand.
        /// </summary>
        /// <param name="circleRepository">Circle repository</param>
        public DeleteCircleCommand(CircleRepository circleRepository)
        {
            _circleRepository = circleRepository;
        }

        /// <summary>
        /// Executes the command to delete a circle from the repository.
        /// </summary>
        /// <param name="parameter"></param>
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
