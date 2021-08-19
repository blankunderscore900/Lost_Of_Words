using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuActions : MonoBehaviour
{

    public float tweenTime;
    public CanvasGroup canvasGroup;
    public GameObject background;
    public float fadetime;
    public float StartGameTime;
    [SerializeField] private GameObject MenuScene;
    [SerializeField] private GameObject BackScene;


    private int levelToLoad;


    // Start is called before the first frame update
    void Start()
    {
        FadeInToLevel();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //public void FadeOutToLevel(int levelIndex)
    public void FadeOutToLevel(GameObject Menu)
    {
        MenuScene = Menu;
        //levelToLoad = levelIndex;
        //LeanTween.alphaCanvas(canvasGroup, to: 1, fadetime).setOnComplete(OnFadeComplete);
        LeanTween.alphaCanvas(canvasGroup, to: 1, fadetime);
        Invoke("FadeInToLevel", fadetime);
        Invoke("ShowMenu", fadetime);
    }

    public void StartGame()
    {

    }

    private void ShowMenu()
    {
        BackScene = GameObject.FindGameObjectWithTag("Game");
        BackScene.SetActive(false);
        MenuScene.SetActive(true);
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void Tween()
    {
        LeanTween.cancel(gameObject);
        transform.localScale = Vector3.one;

        LeanTween.scale(gameObject, Vector3.one * 2, tweenTime).setEasePunch();
    }

    public void FadeInToLevel()
    {
        LeanTween.alphaCanvas(canvasGroup, to:0, fadetime);
    }
}
