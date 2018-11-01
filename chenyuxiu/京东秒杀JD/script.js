// 刷新时间
function updateTime() {
    //   秒杀结束时间
    var endTime = new Date('2018/10/25,12:00:00');
    // 取当前时间
    var currentTime = new Date();
    //  计算剩余时间,用秒作为单位
    var leftSecond = parseInt((endTime.getTime() - currentTime.getTime()) / 1000);
    //计算剩余的小时
    h = parseInt(leftSecond / 3600);
    //计算剩余的分钟
    m = parseInt(leftSecond / 60 % 60);
    //计算剩余的秒
    s = parseInt(leftSecond % 60);
    // 调整格式
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


    //秒杀结束的操作
    if (leftSecond <= 0) {
        // 显示相对应信息“秒杀已经结束”
        document.getElementById('end-box').style.background = 'url(images/flash_end.png)on-repeat';
        document.getElementById('end-box').style.display = 'block';
        document.getElementById('end-box').innerHTML = "秒杀结束"

        clearInterval(countDown);
    }
}

var countDown = setInterval(updateTime, 1000);