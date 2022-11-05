#pragma strict
var button:GameObject;
function OnMouseUp(){
AudioListener.volume = 1;
gameObject.SetActive(false);
button.SetActive(true);
}