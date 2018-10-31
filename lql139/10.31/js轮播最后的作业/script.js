window.onload = function () {
    function $(id) {
        return document.getElementById(id);
    }
    //----------焦点轮播
    var ollis = $('ad_ol').children;
    var leader = 0;
    var target = 0;
   
    for (var i = 0; i < ollis.length; i++) {
        ollis[i].index = i;
        ollis[i].onmouseover = function zid () {
            for (var j = 0; j < ollis.length; j++) {
                ollis[j].className = '';
            }
            this.className = 'current';
            target = -this.index * 405;
        }
    }
    setInterval(function () {
        leader = leader + (target - leader) / 10;
        $('ad_ul').style.left = leader + 'px';
    }, 20)
    //----------自动轮播
    var timer=null;

    function autoplay(){//--自动方法
        target--;
        target<=-1700 ? target=0:target;
        leader=leader+(target-leader)/10;
        $('ad_ul').style.left = leader + 'px';
            
    }

    timer=setInterval(autoplay,20);

    $('box').onmouseover=function(){
        clearInterval(timer);
    }
    $('box').onmouseout=function(){
        timer=setInterval(autoplay,20);
    }
    
}