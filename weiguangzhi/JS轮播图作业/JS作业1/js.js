window.onload=function(){
    var ul = document.getElementById('ad_ul');
    var ol = document.getElementById('ad_ol');
    var scroll = document.getElementById('scroll');
    //取子元素;
    var ul_ll = scroll.children[0];    
    //计时器
    var timer = null;

    var ollis = ol.children;

    var leader = 0;
    var target = 0;
   
    //用于控制动left的变量
    //计时器
    timer = setInterval(autoPlay, 10)
    
    function autoPlay() {
        target--;

        target <= -2000? target = 0 : target;
        leader = leader + (target - leader) /10;
        //console.log(leader);
        ul_ll.style.left = leader + "px";
    }

    //鼠标悬停事件
    slider.onmouseover = function(){
        clearInterval(timer);
    }
    slider.onmouseout = function(){
        timer = setInterval(autoPlay, 10);
    }

    for(var i=0; i < ollis.length; i++){
        ollis[i].index = i;
        ollis[i].onmouseover = function (){
            for (var j = 0;j < ollis.length; j++){
                ollis[j].className = '';
            }
            this.className = 'current';
            target = -this.index * 500;
        }
    }

    setInterval(function () {
        leader= leader + (target - leader) / 10;
        ul.style.left = leader + 'px';
    },20)
}