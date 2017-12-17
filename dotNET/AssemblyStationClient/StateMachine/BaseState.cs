using System;
using System.ComponentModel;
using Spectre.Mvvm.Base;

namespace AssemblyStationClient.StateMachine
{
    /// <summary>
    /// Base state for a state machine.
    /// </summary>
    /// <typeparam name="T">Type of changing object</typeparam>
    /// <seealso cref="IState{T}" />
    abstract class BaseState<T> : IState<T> where T : PropertyChangedNotification
    {
        public void Notify(object sender, PropertyChangedEventArgs eventArgs)
        {
            if (!(sender is T))
            {
                throw new ArgumentException($"Expected type {typeof(T).FullName}, got {sender.GetType().FullName}.");
            }
            Notify((T) sender, eventArgs.PropertyName);
        }

        private void Notify(T vm, string updatedPropertyName)
        {
            if (ChangesState(vm, updatedPropertyName))
            {
                vm.PropertyChanged -= Notify;
                var next = GetNext(vm, updatedPropertyName);
                vm.PropertyChanged += next.Notify;
            }
        }

        public abstract bool ChangesState(T vm, string updatedPropertyName);

        public abstract IState<T> GetNext(T vm, string updatedPropertyName);
    }
}
