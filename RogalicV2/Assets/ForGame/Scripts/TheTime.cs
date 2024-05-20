using UnityEngine;

public class TheTime : MonoBehaviour
{
    public float timeScale;
    public void TimeStop()
    {
        Time.timeScale = 0;
    }

    public void TimeContinue()
    {
        Time.timeScale = 1f;
    }

    public void TimeStayTo()
    {
        Time.timeScale = timeScale;
    }
}
