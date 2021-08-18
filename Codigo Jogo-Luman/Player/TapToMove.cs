using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TapToMove : MonoBehaviour {

    private bool flag = false;
	public Vector3 endPoint;
    public float speed;
    private float yAxis;
	public bool doubleTap;
	private bool firstTap = false;
	public bool secondTap;
	float clickTimer;
	public float clickDelay;
	public float minClicktime;
	Rigidbody rb;
	public float dashSpeed;
	private static Vector3 posicaoAtual;
	public float defspeed;
	public int howMuch;
	PlayerMana playerMana;
	float doubleTapTimer;
	public float maxDoubleTap;
	AudioSource walkAudio;
	public AudioClip walk;
	Animator annaAnim;
    public bool tocou;
	public bool finished;
	public bool isthere;
	public Transform finishPoint;


    void Start(){
        yAxis = gameObject.transform.position.y;
        defspeed = speed;
		playerMana = GetComponent<PlayerMana> ();
		doubleTap = false;
		annaAnim = GetComponentInChildren<Animator> ();
		walkAudio = GetComponent<AudioSource> ();
    }

    // Update is called once per frame
    void Update(){
		CheckClicks ();
		Dash ();
		Walk ();
		if(finished && !isthere){
			annaAnim.SetBool ("IsRunning", true);
			endPoint = finishPoint.position;
		}
		if(secondTap){
			playerMana.UseMana (howMuch);
			secondTap = false;
		}
		if (playerMana.currentMana == -howMuch){
			doubleTap = false;
		}
		if(gameObject.transform.position == endPoint){
			annaAnim.SetBool ("GunsBlasing", false);
			annaAnim.SetBool ("IsRunning", false);
		}

		if (doubleTap) {
			annaAnim.SetBool ("GunsBlasing", true);
			walkAudio.Pause ();
		}else if (!doubleTap){
			annaAnim.SetBool ("GunsBlasing", false);
			walkAudio.UnPause();
		}
	}
	void Dash(){
		if (doubleTap == true && playerMana.currentMana >= 0 && flag){
			doubleTapTimer += Time.deltaTime;
			this.transform.LookAt(endPoint);
			gameObject.transform.position = Vector3.MoveTowards (gameObject.transform.position, endPoint, dashSpeed * Time.deltaTime);
			if (gameObject.transform.position == endPoint || doubleTapTimer >= maxDoubleTap) {
				annaAnim.SetBool ("GunsBlasing", false);
				doubleTap = false;
                tocou = false;
				doubleTapTimer = 0f;
			}
		}
	}
	void Walk(){
		if (doubleTap == false && flag){
			this.transform.LookAt(endPoint);
			gameObject.transform.position = Vector3.MoveTowards (gameObject.transform.position, endPoint, speed * Time.deltaTime  );
			if(!walkAudio.isPlaying && speed > 0){
				walkAudio.Stop ();
				walkAudio.PlayOneShot (walk);
			}
			if(gameObject.transform.position == endPoint){
				walkAudio.Stop ();
				annaAnim.SetBool ("IsRunning", false);
			}
		}
	}
	public void CheckClicks(){
		if (Input.GetMouseButton (0) && !EventSystem.current.IsPointerOverGameObject()) {
				ResetSpeed ();
				RaycastHit hit;
				Ray ray;
				ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				if (Physics.Raycast (ray, out hit)) {
				if(hit.collider.tag != "estrutura" && hit.collider.tag != "Player" && hit.collider.tag != "slash"){
						annaAnim.SetBool ("IsRunning", true);
						flag = true;
						endPoint = hit.point;
						endPoint.y = yAxis;
						firstTap = true;
					}
				}
			}
			if (firstTap == true) {
				clickTimer += Time.deltaTime;
			}
			if (clickTimer >= minClicktime && clickTimer < clickDelay && Input.GetMouseButtonDown (0)) {
				secondTap = true;
				doubleTap = true;
				ResetTimer ();
			} else if (clickTimer > clickDelay) {
				ResetTimer ();
			}
	}
	public void ResetTimer (){
		clickTimer = 0f;
		firstTap = false;
	}
    public void ResetSpeed()
    {
        speed = defspeed;
    }
    void OnCollisionEnter(Collision c) {
        if (c.gameObject.tag == "estrutura") {
			endPoint = transform.position;
            speed = 0f;
        }
    }
	void OnCollisionStay(Collision c){
		if (c.gameObject.tag == "estrutura") {
            endPoint = transform.position;
            speed = 0f;
		}
	}
}