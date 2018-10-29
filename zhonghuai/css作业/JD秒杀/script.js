function updateTime() {
    //秒杀结束的时间
    var endTime = new Date('2018/10/25,12:00:00');
    //取当前时间按
    var currentTime = new Date();
    //计算剩余的时间,用秒作为单位
    var leftSecond = parseInt((endTime.getTime() - currentTime.getTime()) / 1000);
    //计算剩余小时
    h = parseInt(leftSecond / 3600);
    //   计算剩余分钟
    m = parseInt(leftSecond / 60 % 60);
    //   计算剩余秒
    s = parseInt(leftSecond % 60);
    //调正格式
    if (h < 10)
        h = "0" + h;

    if (m < 10 && m > 0)
        m = "0" + m;

    if (s < 10 && s > +0)
        s = "0" + s;
    else if (s < 0)
        s = "00";

    document.getElementById('hour').innerHTML = h;
    document.getElementById('minute').innerHTML = m;
    document.getElementById('second').innerHTML = s;

    //  显示相对于信息“秒杀结束的操作”
    document.getElementById('end_box').style.background = 'url(images/flash_end.png)no-repeat';
    document.getElementById('end_box').style.display = 'block';
    document.getElementById('end_box').style.innerHTML = '秒杀已结束';

    clearInterval(countDown);
}
var countDown = setInterval(updateTime, 1000);