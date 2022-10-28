using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SceneManagement;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [Header("o‚·“G‚Ìí—Ş")] public List<int> stage1enemyData = new List<int>();
    [Header("o‚·“G‚Ìí—Ş")] public List<int> stage2enemyData = new List<int>();

    public int enemyNumber;
    
    [Header("‚·‚×‚Ä‚Ì“G‚ğ“ü‚ê‚Ä‚¨‚­")]public GameObject[] enemiesObjects;
    
    public int[] stage1enemysPosition;
    public int[] stage2enemysPosition;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Enemy", 1, 1);
        enemyNumber = -3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void Enemy()
    {
        

        enemyNumber += 3;

        if(GameManager.instance.selectStage == 1)
        {
            if(stage1enemyData.Count > enemyNumber + 3)
            {
                if(enemiesObjects[stage1enemyData[enemyNumber]] != null)
                {
                    GameObject instance = Instantiate(enemiesObjects[stage1enemyData[enemyNumber]], new Vector2(11, stage1enemysPosition[enemyNumber]), Quaternion.identity);
                    instance.GetComponent<CharacterContoller>().isAlly = false;
                }

                if(enemiesObjects[stage1enemyData[enemyNumber+1]] != null)
                {
                    GameObject instance = Instantiate(enemiesObjects[stage1enemyData[enemyNumber+1]], new Vector2(11, stage1enemysPosition[enemyNumber+1]), Quaternion.identity);
                    instance.GetComponent<CharacterContoller>().isAlly = false;
                }

                if(enemiesObjects[stage1enemyData[enemyNumber+2]] != null)
                {
                    GameObject instance = Instantiate(enemiesObjects[stage1enemyData[enemyNumber+2]], new Vector2(11, stage1enemysPosition[enemyNumber+2]), Quaternion.identity);
                    instance.GetComponent<CharacterContoller>().isAlly = false;
                }
            }          
        }else if (GameManager.instance.selectStage == 2)
        {



            if (stage2enemyData.Count >= enemyNumber + 3)
            {
                if (enemiesObjects[stage2enemyData[enemyNumber]] != null)
                {
                    GameObject instance = Instantiate(enemiesObjects[stage2enemyData[enemyNumber]], new Vector2(11, stage2enemysPosition[enemyNumber]), Quaternion.identity);
                    instance.GetComponent<CharacterContoller>().isAlly = false;
                }

                if (enemiesObjects[stage2enemyData[enemyNumber + 1]] != null)
                {
                    GameObject instance = Instantiate(enemiesObjects[stage2enemyData[enemyNumber + 1]], new Vector2(11, stage2enemysPosition[enemyNumber+1]), Quaternion.identity);
                    instance.GetComponent<CharacterContoller>().isAlly = false;
                }

                if (enemiesObjects[stage2enemyData[enemyNumber + 2]] != null)
                {
                    GameObject instance = Instantiate(enemiesObjects[stage2enemyData[enemyNumber + 2]], new Vector2(11, stage2enemysPosition[enemyNumber+2]), Quaternion.identity);
                    instance.GetComponent<CharacterContoller>().isAlly = false;
                }
            }
        }


    }
}
