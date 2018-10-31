function $(id) {
    return document.getElementById(id);
}
window.onload = function () {
    var target = 0;
    var leader = 0;

    //鼠标悬停时箭头出现
    $("box").onmouseover = function () {
        $("ad").style.display = "block";
    }

    $("box").onmouseout = function () {
        $("ad").style.display = "none";
    }

    //箭头 左 -520 右 +520
    $("left").onclick = function () {
        target += 520;
    }
    $("right").onclick = function () {
        target -= 520;
    }

    //设置动画
    setInterval(function () {
        if (target >= 0) {
            target = 0;
        } else if (target <= -2080) {
            target = -2080;
        }
        leader = leader + (target - leader) / 10;
        $("ad_img").style.left = leader + "px";
    }, 30);
}