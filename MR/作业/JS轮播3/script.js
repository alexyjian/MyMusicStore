function $(id) {
    return document.getElementById(id);
}

window.onload = function () {
    var target = 0;
    var leader = 0;

    //鼠标悬停时箭头出现
    $("box").onmouseover = function () {
        $("arrow").style.display = "block";
    }

    $("box").onmouseout = function () {
        $("arrow").style.display = "none";
    }

    //点两只左箭头，left-520;right+520
    $("left").onclick = function () {
        target += 520;
    }
    $("right").onclick = function () {
        target -= 520;
    }
    //动画。把UL的left属性设置为对应的值
    setInterval(function () {
        if (target >= 0) {
            target = 0;
        }
        else if (target <= -2080) {
            target = -2080;
        }
        console.log(target);
        leader = leader + (target - leader) / 10;
        $("ad_imgs").style.left = leader + "px";
    }, 30);
}