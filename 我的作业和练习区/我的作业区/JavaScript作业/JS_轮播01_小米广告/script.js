window.onload = function () {
    var up = document.getElementById('picUp');
    var down = document.getElementById('picDown');
    var top = document.getElementById('pic').offsetTop;

    function ups() {
        top = top - 1;
        if (top < -1070) {
            clearInterval(time);
        }
        document.getElementById('pic').style.top = top + "px";
    }
    function downs() {
        top = top + 1;
        if (top >= 0) {
            clearInterval(times);
        }
        document.getElementById('pic').style.top = top + "px";
    }


    up.onmouseover = function () {
        time = setInterval(ups, 5);
        ups();
    }
    down.onmouseover = function () {
        times = setInterval(downs, 5);
        downs();
    }
    up.onmouseout = function () {
        clearInterval(time);
    }
    down.onmouseout = function () {
        clearInterval(times);
    }
}