using HeightMapApp.Services;

namespace HeightMapApp.Commands
{
    /// <summary>
    /// Command to add a circle to the height map.
    /// </summary>
    internal class AddCircleCommand : CommandBase
    {
        private readonly CircleCreator _circleCreator;

        /// <summary>
        /// Constructor for AddCircleCommand.
        /// </summary>
        /// <param name="circleCreator">Circle creator</param>
        public AddCircleCommand(CircleCreator circleCreator)
        {
            this._circleCreator = circleCreator;
        }

        /// <summary>
        /// Executes the command to start circle creation.
        /// </summary>
        /// <param name="parameter"></param>
        public override void Execute(object? parameter)
        {
            _circleCreator.StartCircleCreation();
        }
    }
}
