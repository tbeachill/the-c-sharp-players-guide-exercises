Array rankValues = Enum.GetValues(typeof(Card.CardRank));
Array colourValues = Enum.GetValues(typeof(Card.CardColour));

// print one of every card
foreach (Card.CardColour colour in colourValues)
{
    foreach (Card.CardRank rank in rankValues)
    {
        Card card = new Card(colour, rank);
        Console.WriteLine($"{(card.IsNumber() ? "Number" : "Symbol")}: The {card.Colour} {card.Rank}.");
    }
}

public class Card
{
    public CardColour Colour { get; }
    public CardRank Rank { get; }


    public Card()
    {
        // generate a random card
        Array rankValues = Enum.GetValues(typeof(CardRank));
        Random random = new Random();
        CardRank randomRank = (CardRank)rankValues.GetValue(random.Next(rankValues.Length));

        Array colourValues = Enum.GetValues(typeof(CardColour));
        Random random2 = new Random();
        CardColour randomColour = (CardColour)colourValues.GetValue(random2.Next(colourValues.Length));

        this.Colour = randomColour;
        this.Rank = randomRank;
    }

    public Card(CardColour cardColour, CardRank cardRank)
    {
        // create a specified card
        this.Colour = cardColour;
        this.Rank = cardRank;
    }

    public bool IsSymbol() => Rank == CardRank.Dollar || Rank == CardRank.Percent || Rank == CardRank.Caret || Rank == CardRank.Ampersand;
    public bool IsNumber() => !IsSymbol();

    public enum CardRank { One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Dollar, Percent, Caret, Ampersand }
    public enum CardColour { Red, Green, Blue, Yellow }
}