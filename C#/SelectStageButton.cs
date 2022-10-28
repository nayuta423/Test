using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectStageButton : MonoBehaviour
{
    public TextMeshProUGUI stageText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectStage(int stageNumber)
    {
        stageText.text = "LEVEL_" + stageNumber;
        GameManager.instance.selectStage = stageNumber;
    }
}
