namespace Deck
{
    public class Card
    {
        private readonly CardSuit _suit;
        private readonly CardValue _value;

        public Card(CardSuit suit, CardValue value)
        {
            _suit = suit;
            _value = value;
        }

        public override string ToString() => $"{_value} {_suit}";


        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return true; 
            }

            switch (obj)
            {
                case Card otherCard:
                    return Equals(otherCard);
                default:
                    return false;
            }
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((int) _suit * 397) ^ (int) _value;
            }
        }

        protected bool Equals(Card other)
        {
            return _suit == other._suit && _value == other._value;
        }
    }
}