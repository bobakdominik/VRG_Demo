using HeightMapApp.Services;

namespace HeightMapApp.Commands
{
    internal class CancelCircleCreationCommand : CommandBase
    {
        private readonly CircleCreator _circleCreator;

        public CancelCircleCreationCommand(CircleCreator circleCreator)
        {
            _circleCreator = circleCreator;
        }

        public override void Execute(object? parameter)
        {
            _circleCreator.ResetCircleCreation();
        }
    }
}
