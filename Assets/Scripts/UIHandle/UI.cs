using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject messager;
    public GameObject messagerText;
    public GameObject closeButton;
    public GameObject superhot;
    public GameObject superhotTitle;
    public GameObject superhotText;
    public GameObject superhotCloseButton;
    public GameObject controls;
    public GameObject controlsCloseButton;
    public GameObject loading;
    public GameObject shuffler;
    public GameObject shufflerCloseButton;

    // Start is called before the first frame update
    void Start()
    {
        messager.SetActive(false);
        messagerText.SetActive(false);
        closeButton.SetActive(false);
        superhot.SetActive(false);
        superhotText.SetActive(false);
        superhotTitle.SetActive(false);
        superhotCloseButton.SetActive(false);
        controls.SetActive(false);
        controlsCloseButton.SetActive(false);
        loading.SetActive(false);
        shuffler.SetActive(false);
        shufflerCloseButton.SetActive(false);
        superhot.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonPress()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadTheGame()
    {
        loading.SetActive(true);
        Invoke("ButtonPress", 5f);
    }

    public void MessagerPress() 
    {
        messager.SetActive(true);
        messagerText.SetActive(true);
        closeButton.SetActive(true);    
    }

    public void CloseVoid()
    {
        messager.SetActive(false);
        messagerText.SetActive(false);
        closeButton.SetActive(false);
    }

    public void Superhot()
    {
        superhot.SetActive(true);
        superhotText.SetActive(true);
        superhotTitle.SetActive(true);
        superhotCloseButton.SetActive(true);
    }

    public void CloseSuperhot()
    {
        superhot.SetActive(false);
        superhotText.SetActive(false);
        superhotTitle.SetActive(false);
        superhotCloseButton.SetActive(false);
    }

    public void Controls()
    {
        controls.SetActive(true);
        controlsCloseButton.SetActive(true);
    }

    public void CloseControls()
    {
        controls.SetActive(false);
        controlsCloseButton.SetActive(false);
    }

    public void ShufflerGif()
    {
        shuffler.SetActive(true);
        shufflerCloseButton.SetActive(true);
    }

    public void CloseShufWindow()
    {
        shuffler.SetActive(false);
        shufflerCloseButton.SetActive(false);
    }

    public void LeadToWarning()
    {
        superhot.SetActive(true);
    }
}
