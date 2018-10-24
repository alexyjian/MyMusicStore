;
// window.onload=function(){
//     var lidom=document.getElementById('myShopli');
//     var uldom=document.getElementById('myShopul');
//     lidom.onmouseover=function(){
//         uldom.style.display="block";
//         lidom.style.backgroundColor="#FFF";
//     }
//     lidom.onmouseleave=function(){
//         uldom.style.display="none";
//         lidom.style.backgroundColor="";
//     }
// }
window.onload=function(){
    var uldom=document.getElementById('myShopul');
    var lidom=document.getElementById('myShopli');
    lidom.addEventListener('mouseleave',function(){
        uldom.style.display="none";
        lidom.style.backgroundColor="";
    });
    lidom.addEventListener('mouseover',function(){
        uldom.style.display="block";
        uldom.style.borderTop="none";
        lidom.style.backgroundColor="#FFF";
    });
    console.log(this);
}
