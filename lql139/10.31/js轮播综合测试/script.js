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
        ollis[i].onmouseover = function () {
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
    var timer = null;
  
    function autoplay() {//--自动方法
        target -= 405;
        target <= -1700 ? target = 0 : target;
        leader = leader + (target - leader) / 10;
        $('ad_ul').style.left = leader + 'px' ;
        console.log(target);
        if (target == 0) {
            ollis[0].className = 'current';
            ollis[1].className = '';
            ollis[2].className = '';
            ollis[3].className = '';
            ollis[4].className = '';
        } else if (target == -405) {
            ollis[0].className = '';
            ollis[1].className = 'current';
            ollis[2].className = '';
            ollis[3].className = '';
            ollis[4].className = '';
        } else if (target == -810) {
            ollis[0].className = '';
            ollis[1].className = '';
            ollis[2].className = 'current';
            ollis[3].className = '';
            ollis[4].className = '';
        } else if (target == -1215) {
            ollis[0].className = '';
            ollis[1].className = '';
            ollis[2].className = '';
            ollis[3].className = 'current';
            ollis[4].className = '';
        } else if (target == -1620) {
            ollis[0].className = '';
            ollis[1].className = '';
            ollis[2].className = '';
            ollis[3].className = '';
            ollis[4].className = 'current';
        }

    }

  
    timer = setInterval(autoplay, 2000);

    $('box').onmouseover = function () {
        clearInterval(timer);
    }
    $('box').onmouseout = function () {
        timer = setInterval(autoplay, 2000);
    }

}