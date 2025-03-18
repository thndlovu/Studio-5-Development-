using UnityEngine;
using UnityEngine.UI;

public class KillZone : MonoBehaviour
{
    [SerializeField] private GameObject redScreen;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Ball")) GameManager.Instance.KillBall();
        GameManager.health -= 1;
        killZoneScreen();
    }

    private void Update()
    {
        if (redScreen != null)
        {
            if (redScreen.GetComponent<Image>().color.a > 0)
            {
                var color = redScreen.GetComponent<Image>().color;
                color.a -= 0.001f;

                redScreen.GetComponent<Image>().color = color;
            }
        }
    }

    private void killZoneScreen()
    {
        var color = redScreen.GetComponent<Image>().color;
        color.a = 0.8f;

        redScreen.GetComponent<Image>().color = color;
    }
}
