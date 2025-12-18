using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float lifeTime = 3f;
    
    private Vector3 _moveDirection;
    
    private void OnEnable()
    {
        
        StartCoroutine(WaitForUnactive());
    }
    
    private IEnumerator WaitForUnactive()
    {
        yield return new WaitForEndOfFrame();
        Camera cam = Camera.main;
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = Mathf.Abs(cam.transform.position.z);
        _moveDirection = (mousePos - transform.position).normalized;
        yield return new WaitForSeconds(lifeTime);
        gameObject.SetActive(false);
    }
    void Update()
    {
        transform.position += _moveDirection * (speed * Time.deltaTime);
    }
}
