using System.Windows.Input;

namespace HeightMapApp.Commands
{
    /// <summary>
    /// Base class for commands in the application.
    /// </summary>
    internal abstract class CommandBase : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public abstract void Execute(object? parameter);

        protected virtual void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
