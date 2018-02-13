using System.Collections.Immutable;
using System.Linq;
using Optional;

namespace Deck
{
    public class Deck
    {
        private readonly ImmutableStack<Card> _cardsInDeck;

        public Deck(params Card[] cards)
        {
            _cardsInDeck = cards.Aggregate(ImmutableStack<Card>.Empty, (current, card) => current.Push(card));
        }

        public (Option<Card> card, Option<Deck> deck) DrawCard()
        {            
            if (_cardsInDeck.IsEmpty)
            {
                return (Option.None<Card>(), Option.None<Deck>());
            }

            var drawnCard = _cardsInDeck.Peek().Some();
            var cardsInNextDeck = _cardsInDeck.Pop();

            if (cardsInNextDeck.IsEmpty)
            {
                return (drawnCard, Option.None<Deck>());
            }

            var nextDeck = new Deck(cardsInNextDeck.ToArray()).Some();

            return (drawnCard, nextDeck);
        }
    }
}