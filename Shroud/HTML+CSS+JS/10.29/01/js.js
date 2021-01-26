;
window.onload = function () {
    var ulscroll = document.getElementById('scroll');
    var boxscroll = document.getElementById('box');
    var step = 0;
    var LorR = false;
    var timer = setInterval(move, 1);
    boxscroll.addEventListener('mouseover', function () {
        clearInterval(timer)
    })
    boxscroll.addEventListener('mouseout', function () {
        timer = setInterval(move, 1);
    })
    function move() {
        if (step >= -(ulscroll.offsetWidth - 500) && LorR == false) {
            step -= 1
            ulscroll.style.left = step + 'px';
            if (step == -(ulscroll.offsetWidth - 500))
                LorR = true;
        } else {
            step += 1
            ulscroll.style.left = step + 'px';
            if (step == 0)
                LorR = false;
        }
    }
}
