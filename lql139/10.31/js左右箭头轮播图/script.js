function $(id) {
    return document.getElementById(id);
}
window.onload = function () {
    var target = 0;
    var leader = 0;

    $("box").onmouseover = function () {
        $("arrow").style.display = "block";
    }
    $("box").onmouseout = function () {
        $("arrow").style.display = "none";
    }

    $("left").onclick = function () {
        target += 405;

    }
    $("right").onclick = function () {
        target -= 405;
    }

    setInterval(function () {
        if (target >= 0) {
            target = 0;
        }
        else if (target <= -1215) {
            target = -1215;
        }

        leader = leader + (target - leader) / 10;
        console.log(leader);
        $("ad_ul").style.left = leader + "px";
    }, 30);
}
