using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public static FMOD.Studio.EventInstance musicHouse;
    public static FMOD.Studio.EventInstance musicTown;
    public static FMOD.Studio.EventInstance musicTitle;
    public static FMOD.Studio.EventInstance musicForest;
    public static FMOD.Studio.EventInstance musicTree;
    public static FMOD.Studio.EventInstance musicWin;
    public static UnityEngine.SceneManagement.Scene scene;

    int buildIndex;

    bool once = false;

    // Start is called before the first frame update
    void Start()
    {
        buildIndex = scene.buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        if (once == false)
        {
            if (buildIndex == 0)
            {
                musicTitle = RuntimeManager.CreateInstance(Music_bank.MusicTitle);
                musicTitle.start();
            }
            else if (buildIndex == 1)
            {
                musicHouse = RuntimeManager.CreateInstance(Music_bank.MusicHouse);
                musicHouse.start();
            }
            else if (buildIndex == 2)
            {
                musicTown = RuntimeManager.CreateInstance(Music_bank.MusicTown); 
                musicTown.start();
            }
            else if (buildIndex == 3)
            {
                musicForest = RuntimeManager.CreateInstance(Music_bank.MusicForest);
                musicForest.start();
            }
            else if (buildIndex == 4)
            {
                musicTree = RuntimeManager.CreateInstance(Music_bank.MusicTree);
                musicTree.start();
            }
            else if (buildIndex == 5)
            {
                musicWin = RuntimeManager.CreateInstance(Music_bank.MusicWin);
                musicWin.start();
            }

            once = true;
        }
    }
}
