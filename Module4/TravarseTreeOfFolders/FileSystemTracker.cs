using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravarseTreeOfFolders
{
    public class FileSystemTracker : IObservable<FileSystemVisitor>
    {
        public FileSystemTracker()
        {
            observers = new List<IObserver<FileSystemVisitor>>();
        }

        private List<IObserver<FileSystemVisitor>> observers;

        public IDisposable Subscribe(IObserver<FileSystemVisitor> observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);
            return new Unsubscriber(observers, observer);
        }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<FileSystemVisitor>> _observers;
            private IObserver<FileSystemVisitor> _observer;

            public Unsubscriber(List<IObserver<FileSystemVisitor>> observers, IObserver<FileSystemVisitor> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }

            public void Dispose()
            {
                if (_observer != null && _observers.Contains(_observer))
                    _observers.Remove(_observer);
            }
        }

        public void TrackLocation(FileSystemVisitor loc)
        {
            foreach (var observer in observers)
            {
                    observer.OnNext(loc);
            }

        }

        //public void EndTransmission()
        //{
        //    foreach (var observer in observers.ToArray())
        //        if (observers.Contains(observer))
        //            observer.OnCompleted();

        //    observers.Clear();
        //}
    }
}
