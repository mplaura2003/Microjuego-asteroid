using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float maxLifeTime =3f;
    public Vector3 targetVector;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject,maxLifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * targetVector *Time.deltaTime);
    }
	private void OnCollisionEnter(Collision collision){
	 	if (collision.gameObject.CompareTag("Enemy")){
			IncreaseScore();
			Destroy(collision.gameObject);
			Destroy(gameObject);
		}else{
			Debug.Log("He colisionado con otra cosa....");
		}
	}
	private void IncreaseScore(){
		Player.SCORE++;
		Debug.Log(Player.SCORE);
		UpdateScoreText();
	}
	private void UpdateScoreText(){
		GameObject go = GameObject.FindGameObjectWithTag("UI");
		go.GetComponent<Text>().text = "Puntos : " + Player.SCORE;
	}
}
