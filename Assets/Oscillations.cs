using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Oscillations : MonoBehaviour {

	public float A_0,gamma,omega_0,omega_1,delta_0;
	public float initAngle,initAngleTMP, prevAngle, currAngle, deltaAngle;
	public InputField delta_0TextField, A_0TextField, gammaTextField, omega_0TextField;
	private string initDelta_0Angle, A_0Text, gammaText, omega_0Text;
	public bool isStartAmplAlreadyChanged, isStarted, isOnPause;
	public float startTime, pauseTime, currTime;
	public GameObject pendulum;
	public float sometmp;
	public Dropdown simulationType;
	public Quaternion initRotation;

	void Start () {
		
		initRotation = pendulum.transform.rotation;
		delta_0 = (float)1.57079;
		isStarted = false;
		isOnPause = false;
		prevAngle = 0.0f;
		initAngleTMP = 0.0f;
		isStartAmplAlreadyChanged = false;

	}
	

	void Update () {


		if (isStarted && !isOnPause) {
			currTime =  Time.timeSinceLevelLoad - startTime;

			currAngle = A_0 * Mathf.Exp ((-gamma) * currTime) * Mathf.Cos ((omega_1 * currTime) + delta_0) * Mathf.Rad2Deg;
			deltaAngle = currAngle - prevAngle;

			transform.rotation *= Quaternion.AngleAxis (deltaAngle, Vector3.up);

			prevAngle = currAngle;
		}
	}
		

	public void onLinearStartAngleTextFieldChange(){


		if (delta_0TextField.text != "") {
			if (isStartAmplAlreadyChanged) {
				transform.rotation *= Quaternion.AngleAxis (-initAngle, Vector3.up);

			}
			else 
				isStartAmplAlreadyChanged = true;

			initDelta_0Angle = delta_0TextField.text;
			initAngle = float.Parse (initDelta_0Angle);

			transform.rotation *= Quaternion.AngleAxis (initAngle, Vector3.up);

			initAngleTMP = initAngle;	
		} else {
			if (isStartAmplAlreadyChanged) {
				transform.rotation *= Quaternion.AngleAxis (-initAngle, Vector3.up);

				isStartAmplAlreadyChanged = false;
			} 
		}
	}

	public void onAmplitudeFieldChange(){
		if (A_0TextField.text != "") {
			A_0Text = A_0TextField.text;
			A_0 = float.Parse (A_0Text) * Mathf.Deg2Rad;
		} else {
			A_0 = 0.0f;
		}
	}

	public void onGammaFieldChange(){
		if (gammaTextField.text != "") {
			gammaText = gammaTextField.text;
			gamma = float.Parse (gammaText);
		} else {
			gamma = 0.0f;
		}
	}

	public void onOmega_0FieldChange(){

		if (omega_0TextField.text != "") {
			omega_0Text = omega_0TextField.text;
			omega_0 = float.Parse (omega_0Text);
			omega_1 = Mathf.Sqrt (Mathf.Pow (omega_0, 2) - Mathf.Pow (gamma, 2));
		} else {
			omega_0 = 0.0f;
		}
	}


	public void onStartClick(){
		if (!isStarted) {
			isStarted = true;
			startTime = Time.timeSinceLevelLoad;
			A_0TextField.interactable = false;
			gammaTextField.interactable = false;
			delta_0TextField.interactable = false;
			omega_0TextField.interactable = false;
			simulationType.interactable = false;
		} 
		if (isOnPause) {
			startTime += Time.timeSinceLevelLoad - pauseTime;
			isOnPause = false;
		}
	}

	public void onPauseClick(){
		if (isStarted && !isOnPause) {
			isOnPause = true;
			pauseTime = Time.timeSinceLevelLoad;
		}

	}


	public void onResetClick(){
		if (isStarted) {

			Scene thisScene = SceneManager.GetActiveScene ();
			SceneManager.LoadScene (thisScene.name);


		}
	}


}
