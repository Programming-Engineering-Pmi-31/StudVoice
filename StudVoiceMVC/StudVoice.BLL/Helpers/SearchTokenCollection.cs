using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace StudVoice.BLL.Helpers
{
    public class SearchTokenCollection : IEnumerable<string>
    {
        private readonly IEnumerable<string> _source;

        public SearchTokenCollection(string input)
        {
            _source = input
                .Split(new[] { ' ', ',', '.' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim().ToUpperInvariant());
        }

        public IEnumerator<string> GetEnumerator() => _source.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)_source).GetEnumerator();
    }
}
