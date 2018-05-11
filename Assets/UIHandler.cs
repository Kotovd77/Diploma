using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour {

	public Button menuButton, startButton, pauseButton, resetButton;
	public Dropdown modelType;
	public GameObject menuPanel, additionalPlummet, linearPanel;

	void Start (){
		additionalPlummet.SetActive (true);
	}

	public void onMenuButtonClick(){
		if (menuPanel.activeSelf) {
			menuPanel.SetActive (false);
			linearPanel.SetActive (false);
		} else {
			menuPanel.SetActive (true);
			if (modelType.value == 0)
				linearPanel.SetActive (true);
		}
	}

	public void onValueChange(){
		if (modelType.value == 1) {
			additionalPlummet.SetActive (false);
			linearPanel.SetActive (false);
		} else {
			additionalPlummet.SetActive (true);
			linearPanel.SetActive (true);
		}
	}
		
}

