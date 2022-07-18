/* Copyright (c) 2007-2008 Technicat, LLC */

var color = Color.yellow;

var fade = 0.5;

var alpha = 1.0;

function Start() {
	GetComponent.<GUIText>().material.color = color;
}

function Update() {
	if (GetComponent.<GUIText>().material.color.a>0) {
		GetComponent.<GUIText>().material.color.a-=fade*Time.deltaTime;
	}
}

function Score(text) {
	//Options.say(text);
	GetComponent.<GUIText>().text = text;
	GetComponent.<GUIText>().material.color.a = alpha;
}