using Unity.VisualScripting;
using UnityEngine;

public class HeartCounter : MonoBehaviour

{
    public static HeartCounter Instance;
    public int heartCounter = 3;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else { 
            Destroy(gameObject);
        }
    }

    public void Spotted() {
        if (heartCounter > 0) {
            heartCounter--;
            print("strike");
        }
    
    }


}
