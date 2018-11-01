window.onload = function () {
    //获取各元素
    var slider=document.getElementById("wrap");
    var ul = document.getElementById("qx_ul");
    var ol = document.getElementById("qx_ol").getElementsByTagName("li")
    var timer=null;
    var index=0;
    var leader = 0;
    var target = 0;
    ul.appendChild(ul.children[0].cloneNode(true));

    timer =setInterval(autoPlay,2000);
 
    function autoPlay() {
        index++;
        if (index >= ol.length) {
            index = 0;
        }
        cutimages(index);
        console.log(index);
    }
   
    function cutimages(cuindex) {
        for (var i = 0; i < ol.length; i++) {

            for (var i = 0; i < ol.length; i++) {
                ol[i].className = '';
            }
            ol[cuindex].className = "current";
            target = ol[cuindex].index * -500;
        }
    }

    setInterval(function () {
        
        leader = leader + (target - leader) / 10;
        ul.style.left = leader + 'px';
    }, 20)
      //鼠标经过事件
    wrap.onmouseover=function(){
        clearInterval(timer);
    }
    //鼠标离开事件
    wrap.onmouseout=function(){
        timer=setInterval(autoPlay,2000);
    }
    
    for (var i = 0; i < ol.length; i++) {
        ol[i].index = i;
        ol[i].onmouseover = function () {
            clearInterval(timer);
            cutimages(this.index);
            index = this.index;
            console.log(index);
        }
    }
}

