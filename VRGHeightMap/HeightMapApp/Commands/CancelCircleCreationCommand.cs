using HeightMapApp.Services;

namespace HeightMapApp.Commands
{
    /// <summary>
    /// Command to cancel the creation of a circle.
    /// </summary>
    internal class CancelCircleCreationCommand : CommandBase
    {
        private readonly CircleCreator _circleCreator;

        /// <summary>
        /// Constructor for CancelCircleCreationCommand.
        /// </summary>
        /// <param name="circleCreator">Circle creator</param>
        public CancelCircleCreationCommand(CircleCreator circleCreator)
        {
            _circleCreator = circleCreator;
        }

        /// <summary>
        /// Executes the command to cancel the creation of a circle.
        /// </summary>
        /// <param name="parameter"></param>
        public override void Execute(object? parameter)
        {
            _circleCreator.ResetCircleCreation();
        }
    }
}
