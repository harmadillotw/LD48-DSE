using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    InputField volumeInputField;
    Text volumeInputFieldText;
    int volume;
    // Start is called before the first frame update
    void Start()
    {
        volumeInputField = GameObject.Find("VolumeInputField").GetComponent<InputField>();
        volumeInputFieldText = volumeInputField.GetComponentInChildren<Text>();
        int volumeSet = PlayerPrefs.GetInt("volumeSet");
        volume = 100;
        if (volumeSet > 0)
        {
            volume = PlayerPrefs.GetInt("volume");
        }
        volumeInputFieldText.text = "" + volume;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateVolume()
    {
        string volumeString = volumeInputField.text;
        int volumeInt = 0;
        if (int.TryParse(volumeString, out volumeInt))
        {
            PlayerPrefs.SetInt("volumeSet", 1);
            PlayerPrefs.SetInt("volume", volumeInt);
        }
    }

    public void GoBack()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
