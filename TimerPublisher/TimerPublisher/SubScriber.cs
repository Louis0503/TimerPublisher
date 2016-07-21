using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerPublisher
{
    public class SubScriber<T>: IObserver<T>
    {
        private IDisposable unsubscriber;

        public SubScriber()
        {

        }

        public virtual void Subscribe(IObservable<T> provider)
        {
            if(provider != null)
                unsubscriber = provider.Subscribe(this);
        }

        public virtual void OnCompleted()
        {
            this.Unsubscribe();
        }
        public virtual void OnNext(T value)
        {
        }
        public virtual void OnError(Exception e)
        {
            throw new SubScriberException(e.Message + this.GetType().ToString());
        }

        private void Unsubscribe()
        {
            unsubscriber.Dispose();
        }

        public class SubScriberException : Exception
        {
            internal SubScriberException(string errorMessage):base(errorMessage)
            {
            }
        }
    }
}
