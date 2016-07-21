using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerPublisher
{
    public class PublisherTracker<T>: IObservable<T>
    {
        private List<IObserver<T>> _observers;
        public PublisherTracker()
        {
            _observers = new List<IObserver<T>>();
        }

        public IDisposable Subscribe(IObserver<T> observer)
        {
            if(!_observers.Contains(observer))
                _observers.Add(observer);
            return new Unsubscriber<T>(_observers, observer);
        }
    }
}
