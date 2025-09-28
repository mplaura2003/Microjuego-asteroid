using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
  
    public float thrustForce = 10f;
    public float rotationSpeed= 120f;

    public GameObject gun,bulletPrefab;

    public static int SCORE=0;	

    private Rigidbody _rigid;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
	if (PauseManager.IsPaused) return ;
	float rotation = Input.GetAxis("Horizontal")* Time.deltaTime;
        float thrust = Input.GetAxis("Vertical") * Time.deltaTime;

        Vector3 thrustDirection = transform.right;
        _rigid.AddForce(thrustForce * thrustDirection * thrust);
	
	transform.Rotate(Vector3.forward, -rotation * rotationSpeed);

	if(Input.GetKeyDown(KeyCode.Space))
	{
		GameObject bullet = Instantiate(bulletPrefab, gun.transform.position, Quaternion.identity);
		Bullet balaScript = bullet.GetComponent<Bullet>();	
		balaScript.targetVector = transform.right;
	}

	
    }
	private void OnCollisionEnter(Collision collision){
	 	if (collision.gameObject.tag == "Enemy"){
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			SCORE=0;
		}else{
			Debug.Log("He colisionado con otra cosa....");
		}
	}
	

}
