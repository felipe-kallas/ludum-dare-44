using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
        private Toggle m_MenuToggle;
        private float m_TimeScaleRef = 1f;
        private float m_VolumeRef = 1f;
        private bool m_Paused;
        public GameObject ui;


    //    void Awake()
    //    {
    //        m_MenuToggle = GetComponent<Toggle>();
    //    }


        private void MenuOn()
        {
            m_TimeScaleRef = Time.timeScale;
            Time.timeScale = 0f;

            m_VolumeRef = AudioListener.volume;
            AudioListener.volume = 0f;

            m_Paused = true;
        }


        public void MenuOff()
        {
            Time.timeScale = m_TimeScaleRef;
            AudioListener.volume = m_VolumeRef;
            m_Paused = false;
        }

    //    public void Restart()
    //    {
    //        MenuOff();
    //        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    //    }

    //    public void Menu()
    //    {
    //        SceneManager.LoadScene(0);
    //    }

    //    public void Continue()
    //    {
    //        Debug.Log("Aki");
    //        m_MenuToggle.isOn = !m_MenuToggle.isOn;
    //        OnMenuStatusChange();
    //    }

    //    public void OnMenuStatusChange ()
    //    {
    //        if (m_MenuToggle.isOn && !m_Paused)
    //        {
    //            MenuOn();
    //        }
    //        else if (!m_MenuToggle.isOn && m_Paused)
    //        {
    //            MenuOff();
    //        }
    //    }


    //#if !MOBILE_INPUT
    //	void Update()
    //	{
    //		if(Input.GetKeyUp(KeyCode.P))
    //		{
    //		    m_MenuToggle.isOn = !m_MenuToggle.isOn;
    //            Cursor.visible = m_MenuToggle.isOn;//force the cursor visible if anythign had hidden it
    //		}
    //	}
    //#endif
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            Toggle();
        }
    }

    public void Toggle()
    {
        ui.SetActive(!ui.activeSelf);

        if (ui.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void Restart()
    {
        Toggle();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void Continue()
    {
        Debug.Log("aki");
        Toggle();
    }

}
