;
window.onload=function(){
    var imgs=document.getElementById('imgs');
    var lis=document.getElementById('btns').getElementsByTagName('li');
    var index=0;
    var imax=lis.length;
    var time=null;
    var delay;
    for(let i=0;i<lis.length;i++){
        lis[i].onclick=function(){
            index=i;
            imgs.style.left=-(index*420)+'px';
        }
        
    }
    time=setInterval(function(){
        index=++index>imax-1?0:index++;
        
        imgs.style.left=-(index*420)+'px';
        
    },3000);
}