using System.Collections.Generic;

namespace BookHelper
{
    internal class Book
    {
        private readonly List<PagesRange> _readPages = new List<PagesRange>();

        public readonly int PagesCount;

        public Book(int pagesCount)
        {
            PagesCount = pagesCount;
        }

        public void AddRange(int from, int to)
        {
            _readPages.Add(new PagesRange(from, to));
        }

        public int HowManyPagesLeft()
        {
            // TODO 3: Improve/fix the code here.
            var readPages = 0;

            bool[] read = new bool[PagesCount];
            for (var i = 0; i < PagesCount; i++)
                read[i] = false;

                for (var page = 0; page < PagesCount; page++)
                {
                    foreach (var range in _readPages)
                    {
                        if (page >= range.From && page <= range.To && read[page]==false)
                        {
                            readPages++;
                            read[page] = true;
                        }
                    }
                }

            var leftPages = PagesCount - readPages;
            return leftPages;
        }
    }
}
