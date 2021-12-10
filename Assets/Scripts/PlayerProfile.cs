using UnityEngine;
public class PlayerProfile : MonoBehaviour
{
    private static PlayerProfile instance;
    private int _playerHealth = 100;
    private int _playerMana = 100;

    public static PlayerProfile Instance
    {
        get { return instance; }
    }
    public int playerHealth
    {
        get { return _playerHealth;}
        set{_playerHealth = value;}
    }

    public int playerMana
    {
        get { return _playerMana; }
        set { _playerMana = value; }
    }
    
    private void Awake()
    {
        //If there is an instance and the instance is not this instance; destroy this instance.
        if (instance != null  && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }
}
