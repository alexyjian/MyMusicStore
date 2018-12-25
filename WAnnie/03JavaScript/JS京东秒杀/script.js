function updateTime() {
    //秒杀结束的时间   
    var endTime = new Date('2018/10/25,11:09:00');
    //取当前时间
    var currentTime = new Date();
    //计算剩余的时间，用秒作为单位 
    var leftSecond = parseInt((endTime.getTime() - currentTime.getTime()) / 1000);
    //计算剩余小时
    h = parseInt(leftSecond / 3600);
    //计算剩余分钟AWDF
    m = parseInt(leftSecond / 60 % 60);
    //计算剩余秒
    s = parseInt(leftSecond % 60);
    //调整格式
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

    document.getElementById("hour").innerHTML = h;
    document.getElementById("minute").innerHTML = m;
    document.getElementById("second").innerHTML = s;

    //秒杀结束的操作
    if (leftSecond <= 0) {
        //显示相应的信息 "秒杀已经结束"
        document.getElementById("end_box").style.background = "url(./images/flash_end.png) no-repeat";
        document.getElementById("end_box").style.display = "block";
        document.getElementById("end_box").innerHTML = "秒杀已结束"; // innerHTML 获取对象的内容 或 向对象插入内容
        document.getElementById("end_box").style.color = "red";

        clearInterval(countDown);
    }
}

var countDown = setInterval(updateTime, 1000);