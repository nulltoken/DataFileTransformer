using System;
using System.Collections.Generic;

namespace DataFileTransformer
{
    public abstract class CompositeBase<T> : IComposable<T>
    {
        private readonly IList<T> _components;

        protected CompositeBase(IEnumerable<T> components)
        {
            if (components == null)
            {
                throw new ArgumentNullException("components");
            }

            EnsureNoNullEntryIn(components);

            _components = new List<T>(components);
        }

        protected IEnumerable<T> Components
        {
            get { return _components; }
        }

        #region IComposable<T> Members

        public IComposable<T> ComposeWith(T component)
        {
            if (Equals(component, default(T)))
            {
                throw new ArgumentNullException("component");
            }

            var components = new List<T>(_components);
            components.Add(component);

            return BuildComposite(components);
        }

        public abstract T Build();

        #endregion

        private static void EnsureNoNullEntryIn(IEnumerable<T> components)
        {
            foreach (T component in components)
            {
                if (!Equals(component, default(T)))
                {
                    continue;
                }

                throw new ArgumentException("Null or empty component are not allowed.", "components");
            }
        }

        protected abstract CompositeBase<T> BuildComposite(IEnumerable<T> components);
    }
}