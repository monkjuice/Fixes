using System;

namespace Repository
{
    public class FixesRepository
    {
        public FixesContext Context { get; set; }

        public FixesRepository()
        {
            Context = new FixesContext();
        }

    }
}
