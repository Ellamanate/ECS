using System.Collections.Generic;

namespace LamaGamma.Services
{
    public enum Identity
    {
        General = 0,
    }

    public class GameIdentifierService
    {
        private readonly Dictionary<Identity, int> _identifiers = new Dictionary<Identity, int>();

        public int Next(Identity identity)
        {
            int last = _identifiers.ContainsKey(identity) ? _identifiers[identity] : 1;
            int next = ++last;

            _identifiers[identity] = next;

            return next;
        }
    }
}
