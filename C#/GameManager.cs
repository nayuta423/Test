using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isDown;
    public float starSpeed;


    public float money;
    public bool isNotPut;
    public int selectStage;
    //  public List<int> myAllys = new List<int>();
    public int allAllys;
    public List<bool> isGotAlly = new List<bool>();
    public List<int> myTeam;
    public List<int> allAllysLEVEL;
    public List<int> allAllysHP;
    public List<int> allAllysAttack;
    public List<int> allAllysSpeed;
    public List<int> allAllysCost;

   // public bool isTeamIitialSetting;


    private void Awake()
    {
        //myAllys.Add(1);
        //myAllys.Add(2);
        //myAllys.Add(3);
        //myAllys.Add(4);
        //myAllys.Add(5);

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        // ���� pixel�A�c�� pixel�A�E�B���h�E���[�h�A���t���b�V�����[�g(Hz) ���w��
        // �E�B���h�E���[�h�̏ꍇ�A�E�B���h�E�T�C�Y���ς��
        //ExclusiveFullScreen:�������΂����
        Screen.SetResolution(960, 540, FullScreenMode.FullScreenWindow, 60);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDown = true;
        }

        if (isDown)
        {
            if (Input.GetMouseButtonUp(0))
            {
                isDown = false;
            }
        }
        
    }
}
