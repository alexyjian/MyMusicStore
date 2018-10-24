;
window.onload=function(){
    var lidom=document.getElementById('myShopli');
    var uldom=document.getElementById('myShopul');
    lidom.onmouseover=function(){
        uldom.style.display="block";
        lidom.style.backgroundColor="#FFF";
    }
    lidom.onmouseleave=function(){
        uldom.style.display="none";
        lidom.style.backgroundColor="";
    }
}