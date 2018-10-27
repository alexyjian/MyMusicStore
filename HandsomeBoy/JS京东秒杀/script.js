
function updateTime() {
    // 秒杀结束时间
    var endTime = new Date('2018/10/25,12:00:50');
    //取当前时间
    var currentTime = new Date();
    // 计算剩余的时间，用秒作为单位
    var leftSecond = parseInt((endTime.getTime() - currentTime.getTime()) / 1000);
    // 计算剩余小时
    h = parseInt(leftSecond / 3600);
    // 计算剩余的分钟
    m = parseInt(leftSecond / 60%60);
    //计算剩余的秒
    s = parseInt(leftSecond % 60);
    if (h < 10)
    {
         h = "0" + h;
    }
    else if(h==0)
    {
         h="00";
    }
    if (m < 10 && m >= 0)
        m = "0" + m;
    else if (m < 0)
        m = "00";

    if (s < 10 && s >= 0)
        s = "0" + s;
    else if (s < 0) {
            s = "00";
        document.getElementById("hour").innerHTML = h;
        document.getElementById("minute").innerHTML = m;
        document.getElementById("secand").innerHTML = s;
    }
    //秒杀结束
    if(leftSecond<=0)
    {
        document.getElementById("end-box").style.display="block"
        document.getElementById("end-box").innerHTML = "秒杀结束!!!";
        clearInterval(countDown);
    }
}

  countDown = setInterval(updateTime,1000);



