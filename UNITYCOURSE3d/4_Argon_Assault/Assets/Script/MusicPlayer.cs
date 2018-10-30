using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

    private static bool created = false;
    void Awake()
    {
        int numMusicPlayer= FindObjectsOfType<MusicPlayer>().Length;
        print("Number of music player in this scene " + numMusicPlayer);
        if (numMusicPlayer > 1)
            Destroy(gameObject);
        else
            DontDestroyOnLoad(this.gameObject);
        
    }

}
