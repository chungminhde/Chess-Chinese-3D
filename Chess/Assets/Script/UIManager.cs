using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public static UIManager instance;

    [SerializeField]
    private Button replayBtn;

    [SerializeField]
    private Button exitBtn;

    [SerializeField]
    private Text winText;

    void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start () {
        ShowUI(false);
        replayBtn.GetComponent<Button>().onClick.AddListener(OnClickReplayBtn);
        exitBtn.GetComponent<Button>().onClick.AddListener(OnClickExitBtn);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnClickReplayBtn()
    {
        //Restart Game
        GameManager.instance.RestartGame();
    }

    void OnClickExitBtn()
    {
        //Exit
        Application.Quit();
    }

    public void SetWinnerText(string text)
    {
        winText.text = text;
    }

    public void ShowUI(bool isShow)
    {
        this.gameObject.SetActive(isShow);
    }
}
