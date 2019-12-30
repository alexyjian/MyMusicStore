window.onload = function () {
    var slider=document.getElementById("slider");
    var ul = document.getElementById("ad_ul");
    var ol = document.getElementById("ad_ol").getElementsByTagName("li")
    var timer=null;
    var index=0;
    var leader = 0;
    var target = 0;
    
    timer =setInterval(autoPlay,1000);

    function autoPlay() {
        index++;
        if (index >= ol.length) {
            index = 0;
        }
        cutimages(index);
    }
   
    function cutimages(cuindex) {
        for (var i = 0; i < ol.length; i++) {

            for (var i = 0; i < ol.length; i++) {
                ol[i].className = '';
            }
            ol[cuindex].className = "current";
            target = ol[cuindex].index * -490;
        }
    }

    setInterval(function () {
        
        leader = leader + (target - leader) / 10;
        ul.style.left = leader + 'px';
    }, 20)

    slider.onmouseover=function(){
        clearInterval(timer);
    }

    slider.onmouseout=function(){
        timer=setInterval(autoPlay,1500);
    }

    for (var i = 0; i < ol.length; i++) {
        ol[i].index = i;
        ol[i].onmouseover = function () {
            clearInterval(timer);
            cutimages(this.index);
            index = this.index;
        }
    }
}