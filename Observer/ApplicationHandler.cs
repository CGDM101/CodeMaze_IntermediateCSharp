using System;
using System.Collections.Generic;

namespace Observer
{
    // The provider.
    public class ApplicationHandler : IObserver<Application>
    {
        private readonly List<IObserver<Application>> _observers;
        public List<Application> Applications { get; set; }

        public ApplicationHandler()
        {
            _observers = new List<IObserver<Application>>();
            Applications = new List<Application>();
        }
        
        public IDisposable Subscribe(IObserver<Application> observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);

                foreach (var item in Applications)
                    observer.OnNext(item);

            }

            return new Unsubscriber(_observers, observer);
        }

        public void AddApplication(Application app)
        {
            Applications.Add(app);

            foreach (var observer in _observers)
                observer.OnNext(app);
        }

        public void CloseApplications()
        {
            foreach (var observer in _observers)
                observer.OnCompleted();

            _observers.Clear();
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(Application value)
        {
            throw new NotImplementedException();
        }
    }
}
