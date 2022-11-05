var Restart=false;
function OnMouseUp(){
if(Restart==true){
//SceneManager.LoadScene("scene2");
UnityEngine.SceneManagement.SceneManager.LoadScene("scene2");
}
}