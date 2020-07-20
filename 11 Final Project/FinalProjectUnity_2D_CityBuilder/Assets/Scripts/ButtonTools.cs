using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

// Tools for using once a button has been clicked
public class ButtonTools : MonoBehaviour
{
    public GameObject HomeButton, MenuButton, MenuSpace;

    // Tool for disabling and enabling the buttons
    void Update(){
        if (MenuSpace.transform.position.x == 0){
            HomeButton.SetActive(false);
            MenuButton.SetActive(true);
        } else if (MenuSpace.transform.position.x == -30){
            HomeButton.SetActive(true);
            MenuButton.SetActive(false);
        }
    }

    // Tool For Quiting The Application
    public void QuitApplication(){
        Application.Quit();
    }

    // Tool for changing the scene
    public void ChangeScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }

    // Tool For tweening a gameobject's position
    public Transform targetTransform;
    public float tweenDuration = 1f;
    private Coroutine _currentCoroutine = null;
    public void TweenToTranformPosition(Transform target)
    {
        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
            _currentCoroutine = null;
        }
        
        if (gameObject.activeInHierarchy && targetTransform != null && target != null)
        {
            _currentCoroutine = StartCoroutine(TweenMove(tweenDuration,target));
        }
    }
    private IEnumerator TweenMove(float duration, Transform target)
    {
        Vector3 startPosition = targetTransform.position;
        
        float t = 0;
        float timeElapsed = 0;
        
        while (timeElapsed < duration)
        {
            timeElapsed += Time.deltaTime;
            t = timeElapsed/duration;
            
            targetTransform.position = Vector3.Lerp(startPosition, target.position,t);
            yield return null;
        }
        targetTransform.position = target.position;
    }
}