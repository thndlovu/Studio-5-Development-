using System.Collections;
using UnityEngine;

public class Brick : MonoBehaviour
{
    private Coroutine destroyRoutine = null;

    private void OnCollisionEnter(Collision other)
    {
        if(AudioManager.instance != null){
            AudioManager.instance.playSound(AudioManager.instance.explosionClip);
        }

        if (destroyRoutine != null) return;
        if (!other.gameObject.CompareTag("Ball")) return;
        destroyRoutine = StartCoroutine(DestroyWithDelay());
    }

    private IEnumerator DestroyWithDelay()
    {
        yield return new WaitForSeconds(0.1f); // two physics frames to ensure proper collision
        GameManager.Instance.OnBrickDestroyed(transform.position);
        Destroy(gameObject);
    }
}
