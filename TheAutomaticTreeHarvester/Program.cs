Tree tree = new Tree();

while (true)
    tree.TryGrow();

public class Tree
{
    private Random random = new Random();
    public bool Ripe { get; set; }
    public event Action Ripened;    // event

    public Tree()
    {
        Announcer announcer = new Announcer(this);
        Harvester harvester = new Harvester(this);
    }

    public void TryGrow()
    {
        if (random.NextDouble() < 0.00000001 && !Ripe)
        {
            Ripe = true;
            Ripened();
        }
    }
}

public class Announcer
{
    // announces when a tree has ripened

    public Announcer(Tree tree)
    {
        // attach method to the event
        tree.Ripened += OnRipened;
    }

    private void OnRipened()
    {
        // method
        Console.WriteLine("The tree is ripe.");
    }
}

public class Harvester
{
    // harvests the tree, setting its status back to unripened

    private Tree Tree { get; set; }
    public int Harvests { get; set; }

    public Harvester(Tree tree)
    {
        this.Tree = tree;
        Tree.Ripened += OnRipened;
    }

    private void OnRipened()
    {
        Tree.Ripe = false;
        Harvests += 1;
        Console.WriteLine($"The tree has been harvested {Harvests} times.");
    }
}
