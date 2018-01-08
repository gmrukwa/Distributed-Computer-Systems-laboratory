using System.ComponentModel;

namespace PolslMacrocourse.DcsLab.StateMachine
{
    /// <summary>
    /// Interface of a state in state machine.
    /// </summary>
    /// <typeparam name="T">Type of state subject.</typeparam>
    public interface IState<T>
    {
        void Notify(object sender, PropertyChangedEventArgs eventArgs);

        bool ChangesState(T sender, string updatedPropertyName);

        IState<T> GetNext(T sender, string updatedPropertyName);
    }
}
