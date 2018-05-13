using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Oscillations : MonoBehaviour {

	public float A_0,gamma, omega, omega_0, omega_1, delta_0, epsilon, phi_c;
	public float initAngle, initAngleTMP, prevAngle, currAngle, deltaAngle;
	public InputField delta_0TextField, A_0TextField, gammaTextField, omega_0TextField;
	private string initDelta_0Angle, A_0Text, gammaText, omega_0Text;
	public bool isStartAmplAlreadyChanged, isStarted, isOnPause;
	public float startTime, pauseTime, currTime;
	public float startSpeed, C1, C2;
	public GameObject pendulum;
	public float sometmp;
	public Dropdown simulationType;
	public Quaternion initRotation;

	void Start () {
		
		initRotation = pendulum.transform.rotation;
		delta_0 = (float)1.57079;
		phi_c = 175;
		isStarted = false;
		isOnPause = false;
		prevAngle = 0.0f;
		initAngleTMP = 0.0f;
		isStartAmplAlreadyChanged = false;

	}
	

	void Update () {


		if (isStarted && !isOnPause) {
			currTime =  Time.timeSinceLevelLoad - startTime;

			if (simulationType.value == 1) {
				if ((Mathf.Abs (phi_c) * Mathf.Rad2Deg) < currAngle) {
					C1 = Mathf.PI - Mathf.Sqrt ((startSpeed / omega_0) + Mathf.PI);
					C2 = Mathf.Sqrt((startSpeed/omega_0)+Mathf.PI);
					currAngle = C1 * Mathf.Exp(omega_0 * currTime) + C2 * Mathf.Exp((-omega_0) * currTime);
				} else {
					currAngle = ((A_0 * Mathf.Sin (omega * currTime)) + (epsilon * A_0 * Mathf.Sin (3 * omega * currTime))) * Mathf.Rad2Deg;
				}
				}

			if (simulationType.value == 0)
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
		epsilon = Mathf.Pow (A_0, 2) / 192;
		Debug.Log ("Rad ampl = " + A_0);
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
		omega = omega_0 * (1 - (A_0 / 16));
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
			Scene thisScene = SceneManager.GetActiveScene ();
			SceneManager.LoadScene (thisScene.name);
	}


}
