;
window.onload = function () {
    var ulscroll = document.getElementById('scroll');
    var step = 0;
    var LorR = false;
    setInterval(function () {
        if (step >= -(ulscroll.offsetWidth - 500)&&LorR==false) {
            step -= 1
            ulscroll.style.left = step + 'px';
            if(step==-(ulscroll.offsetWidth - 500))
            LorR=true;
        }else{
            step += 1
            ulscroll.style.left = step + 'px';
            if(step==0)
            LorR=false;
        }
    }, 10);
}
