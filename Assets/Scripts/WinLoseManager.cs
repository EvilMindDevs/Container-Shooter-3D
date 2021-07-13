using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class WinLoseManager : MonoBehaviour
{
    public int targetBoxCount;
    public BoxEvent boxEvent = new BoxEvent();

    private void OnEnable()
    {
        boxEvent.AddListener(WinLoseCondition);
    }

    private void OnDisable()
    {
        boxEvent.RemoveListener(WinLoseCondition);
    }

    public void WinLoseCondition(bool state)
    {
        if (state)
        {
            HMSAnalyticsManager.Instance.SendEventWithBundle("Winpoint", "point", 1);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}

public class BoxEvent : UnityEvent<bool>
{

}
