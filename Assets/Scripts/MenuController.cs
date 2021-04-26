using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuController : MonoBehaviour
{
    private LoadSave loadSaveUtil;
    // Start is called before the first frame update
    void Start()
    {
        loadSaveUtil = new LoadSave();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGame()
    {
        SceneManager.LoadScene("SelectCaptainScene");
    }
    public void LoadGame()
    {
        loadSaveUtil.LoadData();
        SceneManager.LoadScene("BaseScene");
    }

    public void LoadOptions()
    {
        SceneManager.LoadScene("OptionsScene");
    }

    public void LoadInstructions()
    {
        SceneManager.LoadScene("InstructionsScene");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
