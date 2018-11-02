window.onload=function(){
    var naoll=document.getElementById('naoll');
    var ul=document.getElementById('on_ul');
    var ol=document.getElementById('on_ol').getElementsByTagName("li");
    var timer=null;
    var index=0;
    var leader=0;
    var target=0;
    
    timer=setInterval(autoPlay,900);

    function autoPlay(){
        index++;
        if(index >= ol.length) {
           index=0;
        }
        cutimages(index);
        console.log(index);
    }
    function cutimages(cuindex){
    for(var i=0; i < ol.length; i++){
        for(var i=0; i < ol.length; i++){
            ol[i].className ='';
        }
        ol[cuindex].className="arroet";
        target=ol[cuindex].index*-500;
      }
    }
    setInterval(function(){
        leader=leader +(target - leader)/10;
        ul.style.left=leader + 'px';
    },20)
    
    naoll.onmouseover=function(){
        clearInterval(timer);
    }
    naoll.onmouseover=function(){
        timer=setInterval(autoPlay,900);
    }

    for(var i=0; i< ol.length; i++){
        ol[i].index=i;
        ol[i].onmouseover=function(){
            clearInterval(timer);
            cutimages(this.index);
            index=this.index;
            console.log(index);
        }
    }
}