using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    

    public void PlayButton()
    {
        GameGenerator.Singleton.Init();
    }
}
