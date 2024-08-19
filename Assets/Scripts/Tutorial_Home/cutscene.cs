using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutscene : MonoBehaviour
{
    public bool doTheThing;

    public GameObject witch;

    void Update()
    {
        witch.GetComponent<townIngredientCollect>().shrink();
    }
}
