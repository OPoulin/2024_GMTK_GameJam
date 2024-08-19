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

    public static bool once = false;

    static MusicManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this; // In first scene, make us the singleton.
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
            Destroy(gameObject); // On reload, singleton already set, so destroy duplicate.
    }

// Start is called before the first frame update
void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scene = SceneManager.GetActiveScene();
        if (once == false)
        {
            if (scene.name == "TitleScreen")
            {
                musicTitle = RuntimeManager.CreateInstance(Music_bank.MusicTitle);
                musicTitle.start();
                print("Music Title start");
            }
            else if (scene.name == "HomeStart")
            {
                musicHouse = RuntimeManager.CreateInstance(Music_bank.MusicHouse);
                musicHouse.start();
                print("Music House start");
            }
            else if (scene.name == "TownMarket")
            {
                musicTown = RuntimeManager.CreateInstance(Music_bank.MusicTown); 
                musicTown.start();
                print("Music Town start");
            }
            else if (scene.name == "Forest")
            {
                musicForest = RuntimeManager.CreateInstance(Music_bank.MusicForest);
                musicForest.start();
                print("Music Forest start");
            }
            else if (scene.name == "Tree")
            {
                musicTree = RuntimeManager.CreateInstance(Music_bank.MusicTree);
                musicTree.start();
                print("Music Tree start");
            }
            else if (scene.name == "YouWin")
            {
                musicWin = RuntimeManager.CreateInstance(Music_bank.MusicWin);
                musicWin.start();
                print("Music Win start");
            }
            else
            {
               Debug.Log("Music start fail");
            }

            once = true;
        }

        if (scene.buildIndex != buildIndex)
        {
            buildIndex = scene.buildIndex;
            musicTitle.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            musicHouse.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            musicTown.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            musicForest.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            musicTree.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            musicWin.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            once = false;
        }
    }
}
