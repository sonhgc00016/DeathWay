#pragma strict

function Start () {

}

var target : Transform;
var distance : float;
var height: float;
function Update(){
 
    transform.position.z = target.position.z -distance;
    transform.position.y = target.position.y + height;
    transform.position.x = target.position.x;
}