using HoloToolkit.Unity.InputModule;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour, IInputClickHandler{

    public Modes mode;
    public GameObject Orchestrator;
    public bool changeScene = false;
    public string sceneName;
    public static string keyboardText = "";

    TouchScreenKeyboard keyboard;

    public void OnInputClicked(InputClickedEventData eventData)
    {
        if (!changeScene)
        {
            Orchestrator.GetComponent<AppController>().ChangeMode(mode);
        }
        else
        {
            SceneManager.LoadScene(sceneName);
        }
        PlaySound();
    }

    private void PlaySound()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
        audio.Play(44100);
    }

    void Start()
    {
        keyboard = TouchScreenKeyboard.Open("New York", TouchScreenKeyboardType.Default, false, false, false, false, "Single-line title"); // FIXME
    }

    void Update() { }
}
