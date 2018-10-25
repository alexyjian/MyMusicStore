
function update() {
    //秒杀结束的时间
    var endtime = new Date('2018/10/25,12:00:00');
    //取当前的时间
    var currentTime = new Date();
    //计算剩余的时间
    var leftSecond = parseInt((endtime.getTime() - currentTime.getTime()) / 1000)
    //计算剩余小时
    hours = parseInt(leftSecond / 3600);
    //计算剩余分钟
    mins = parseInt(leftSecond / 60 % 60);
    //计算剩余秒
    seconds = parseInt(leftSecond % 60);
    //调整格式
    if (hours < 10)
        hours = '0' + hours;

    if (mins < 10 && mins >= 0) {
        mins = '0' + mins;
    }
    else if (mins < 0) {
        mins = '00';
    }

    if (seconds < 10 && seconds >= 0) {
        seconds = '0' + seconds;
    }
    else if (seconds < 0) {
        seconds = '00';
    }
    document.getElementById('hour').innerHTML = hours;
    document.getElementById('minute').innerHTML = mins;
    document.getElementById('second').innerHTML = seconds;

    // 秒杀结束的操作
    if (leftSecond<=0){
        end= document.getElementById('end-box').style.display='block';
        console.log(end);
        clearInterval(couptDown);
    }
}
var couptDown = setInterval(update, 1000);