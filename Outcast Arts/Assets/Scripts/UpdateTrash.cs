using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateTrash : MonoBehaviour
{
    public Slider trashBar;

    private int currentPlayerTrash = 0;

    public void IncreaseTheBar()
    {
        currentPlayerTrash += 5;
        trashBar.value = currentPlayerTrash;

        if (trashBar.value >= trashBar.maxValue)
        {
            //StartCoroutine(ExecuteAfterTime(2));
        }
    }
}
