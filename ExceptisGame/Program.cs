Random r = new Random();
int oatmealCookie = r.Next(0, 9);
List<int> selectionList = new List<int> { };

while (true)
{
    try { MakeSelection(); }
    catch (Exception ex)
    {
        Console.WriteLine(ex);
        Console.WriteLine("You lose.");
    }
}


void MakeSelection()
{
    // make a selection, check if it is oatmeal, then add selection to the selection list

    int selection;
    do
    {
        Console.Write($"Player {selectionList.Count % 2 + 1}: ");
        int.TryParse(Console.ReadLine(), out selection);
    }
    while (selectionList.Contains(selection));

    if (selection == oatmealCookie)
        throw new Exception("Oatmeal");

    selectionList.Add(selection);
}
