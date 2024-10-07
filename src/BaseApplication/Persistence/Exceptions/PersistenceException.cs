using System.Globalization;

namespace Persistence.Exceptions
{
    public class PersistenceException : Exception
    {
        public List<string> Errors { get; }
        public PersistenceException() : base("Persistence Invalid")
        {
            Errors = new List<string>();
        }

        public PersistenceException(string failureMessage) : this()
        {
            Errors.Add(failureMessage);
        }
        public PersistenceException(IEnumerable<string> failures): this()
        {
            Errors.AddRange(failures);
        }
    }
}
