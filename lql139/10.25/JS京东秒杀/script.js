function clock() {
    var endtime = new Date('2018/10/25,11:58:00');
    var newtime = new Date();
    var second = parseInt((endtime.getTime() - newtime.getTime()) / 1000);
    h = parseInt(second / 3600);
    m = parseInt(second / 60 % 60);
    s = parseInt(second % 60);

    if (h < 10)
        h = "0" + h;

    if (m < 10 && m >= 0)
        m = "0" + m;
    else if (m < 0)
        m = "00";

    if (s < 10 && s >= 0)
        s = "0" + s;
    else if (s < 0)
        s = "00";

    document.getElementById('hour').innerHTML = h;
    document.getElementById('minute').innerHTML = m;
    document.getElementById('second').innerHTML = s;
    if (second <= 0) {
        document.getElementById('end-box').style.display = "block";
        document.getElementById('end-box').style.innerHTML="秒杀结束!!!";
        clearInterval(couptdown);
    }
}
var couptdown = setInterval(clock, 1000);
