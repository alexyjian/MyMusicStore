
/* //方法1
var dd=document.getElementById("ddl");
var ss=document.getElementById("sc");
ss.onmouseover=function(){
    dd.style.display='block';
}
ss.onmouseout=function(){
    dd.style.display='none';
}
dd.onmouseover=function(){
    dd.style.display='block';
}
dd.onmouseout=function(){
    dd.style.display='none';
}
*/
//方法2
function change(id,mode){
    document.getElementById(id).style.display=mode;
}
 if(mode=='block'){
    document.getElementById(id).parentNode.style.backgroundColor='#fff';
    
 }
 else{
    
 }

