// create three sword instances and write out each sword

Sword swordA = new Sword(Material.Iron, Gemstone.None, 5, 1);
Sword swordB = swordA with { material = Material.Bronze };
Sword swordC = swordA with { gemstone = Gemstone.Amber, length = 4.5f };

Console.WriteLine(swordA + "\n" + swordB + "\n" + swordC);


public record Sword(Material material, Gemstone gemstone, float length, float crossguardWidth);

public enum Material { Wood, Bronze, Iron, Steel, Binarium };
public enum Gemstone { None, Emerald, Amber, Sapphire, Diamond, Bitstone };