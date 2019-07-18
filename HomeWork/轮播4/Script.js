window.onload = function () {
    var ul = document.getElementById("list_img");
    var s_left = document.getElementById("s_left");
    var s_right = document.getElementById("s_right");
    var scoll = document.getElementById("scoll");
    var target = 0;
    var lender = 0;
    var index = 0;
    var timer = null;

    scoll.onmouseover = function() {
        s_left.style.display = "block";
        s_right.style.display = "block";
    }

    scoll.onmouseout = function() {
        s_left.style.display = "none";
        s_right.style.display = "none";
    }

    function rightPlay() {
        target = -index * 555;
        lender = lender + (target - lender) / 10;
        ul.style.left = lender + "px";
    }

    function leftPlay() {
        target = -index * 555;
        lender = lender + (target - lender) / 10;
        ul.style.left = lender + "px";
    }

    s_right.onclick = function () {
        if (index < 4) {
            index++;
            timer = setInterval(rightPlay, 20);
        }else {
            index = 4;
        }
    }

    s_left.onclick = function () {
        if (index > 0) {
            index--;
            timer = setInterval(leftPlay, 20);
        }else {
            index = 0;
        }
    }
}