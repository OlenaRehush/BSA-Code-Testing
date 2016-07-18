using NUnit.Framework;
using TechTalk.SpecFlow;

namespace BookHelper.Specs
{
    [Binding]
    public class BookPagesCalculationSteps
    {
        private Book _book;
        private int _result;

        [Given(@"I have created a book with (.*) pages")]
        public void GivenIHaveCreatedABookWithPages(int pages)
        {
            _book = new Book(pages);
        }
        
        [Given(@"I have added page range from (.*) to (.*)")]
        public void GivenIHaveAddedPageRangeFromTo(int from, int to)
        {
            _book.AddRange(from, to);
        }
        
        [When(@"I ask how many pages left")]
        public void WhenIAskHowManyPagesLeft()
        {
            _result = _book.HowManyPagesLeft();
        }
        
        [Then(@"the book shows (.*) pages")]
        public void ThenTheBookShowsPages(int left)
        {
            Assert.That(_result, Is.EqualTo(left));
        }
    }
}
