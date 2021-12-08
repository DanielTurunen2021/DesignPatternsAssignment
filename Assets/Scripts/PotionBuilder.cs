class PotionBuilder
{
    public PotionBuilder(int health, int mana = 0)
    {
        PlayerProfile.Instance.playerHealth += 100;
    }

    public PotionBuilder(int mana)
    {
        PlayerProfile.Instance.playerMana += 100;
    }

    //private var potion = new PotionBuilder(int health: 100, int mana: 100);

}