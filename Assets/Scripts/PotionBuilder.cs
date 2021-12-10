class PotionBuilder
{
    public PotionBuilder(int health = 0, int mana = 0)
    {
        PlayerProfile.Instance.playerHealth += 100;
    }

    public PotionBuilder(int mana)
    {
        PlayerProfile.Instance.playerMana += 100;
    }

     PotionBuilder _potion = new PotionBuilder();
}