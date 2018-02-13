using Optional.Unsafe;
using Shouldly;
using Xunit;
using Deck;

namespace Deck.UnitTests
{
    public class DeckShould
    {
        [Fact]
        public void DrawCardWhenSingleCardInDeck()
        {
            var placedCard = new Card(CardSuit.Spades, CardValue.Ace);

            var startingDeck = new Deck(placedCard);

            var (drawnCard, deckAfterDraw) = startingDeck.DrawCard();

            drawnCard.Contains(placedCard).ShouldBeTrue($"expected {nameof(placedCard)}");
            deckAfterDraw.HasValue.ShouldBeFalse();
        }

        [Fact]
        public void DrawCardWhenTwoCardsInDeck()
        {
            var firstPlacedCard = new Card(CardSuit.Spades, CardValue.Ace);
            var secondPlacedCard = new Card(CardSuit.Diamonds, CardValue.Ace);
            
            var startingDeck = new Deck(firstPlacedCard, secondPlacedCard);

            var (firstDrawnCard, deckAfterFirstDraw) = startingDeck.DrawCard();
            var (secondDrawnCard, deckAfterSecondDraw) = deckAfterFirstDraw.ValueOrFailure("expected deck").DrawCard();

            
            firstDrawnCard.Contains(secondPlacedCard).ShouldBeTrue($"expected {nameof(firstDrawnCard)}");
            secondDrawnCard.Contains(firstPlacedCard).ShouldBeTrue($"expected {nameof(secondDrawnCard)}");

            deckAfterSecondDraw.HasValue.ShouldBeFalse();
        }

        [Fact]
        public void DrawCardFromEmptyDeck()
        {
            var startingDeck = new Deck();

            var (drawnCard, deckAfterFirstDraw) = startingDeck.DrawCard();
            
            drawnCard.HasValue.ShouldBeFalse();
            deckAfterFirstDraw.HasValue.ShouldBeFalse();
        }
    }
}
