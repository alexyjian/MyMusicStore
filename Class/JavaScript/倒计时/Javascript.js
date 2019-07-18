function updateTime() {
    var statrTime = new Date();
    var endTime = new Date("2018/10/26 08:05:00");
    var leftSecond = parseInt((endTime.getTime() - statrTime.getTime()) / 1000);

    h = parseInt(leftSecond / 3600);
    m = parseInt(leftSecond / 60 % 60);
    s = parseInt(leftSecond % 60);

    if (h < 10) {
        h = "0" + h;
    }

    if (m < 10 && m >= 0) {
        m = "0" + m;
    }
    else if (m < 0) {
        m = "00";
    }

    if (s < 10 && s >= 0) {
        s = "0" + s;
    }
    else if (s < 0) {
        s = "00";
    }

    document.getElementById("hour").innerHTML = h;
    document.getElementById("minute").innerHTML = m;
    document.getElementById("second").innerHTML = s;

    if (leftSecond <= 0) {
        var eb = document.getElementById("end_box");
        eb.style.display="block";
        eb.innerHTML = "秒杀已结算！";
        clearInterval(CountDown);
    }
}

var CountDown = setInterval(updateTime, 1000);