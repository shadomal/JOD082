using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class InterfaceController : MonoBehaviour
{
    #region vars
    [SerializeField] private GameObject canvasMenuPause;
    private bool menupauseOn;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        menupauseOn = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.P) || Input.GetKey(KeyCode.Escape))
        {
            MenuPause();
        }
        if (Input.GetKey(KeyCode.F5))
        {
            //local para save;
        }
    }

    #region SceneChange
    //Local onde será gerenciado todas as cenas do jogo;
    public void FirstMap()
    {
        SceneManager.LoadScene("MapaBlocagem");
    }
    //Botão para fechar jogo;
    public void CloseGame()
    {
        //Fecha jogo
        Application.Quit();
    }
    #region Menus
    public void MenuPause()
    {

        if (menupauseOn == false)
        {
            menupauseOn = true;
            canvasMenuPause.gameObject.SetActive(true);
            TogglePause();
        }
        else
        {
            menupauseOn = false;
            canvasMenuPause.gameObject.SetActive(false);
            TogglePause();
        }
        

    }
    public void HomeMenu()
    {
        SceneManager.LoadScene("HomeMenu");
    }
    public void ConfigMenu()
    {
        SceneManager.LoadScene("ConfigMenu");
    }public void menuOpcao()
    {
        SceneManager.LoadScene("menuPause");
    }
    #endregion
    #region Functions
    public void TogglePause()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;

        }
        else Time.timeScale = 1;
    }

    #endregion
    #endregion
}

