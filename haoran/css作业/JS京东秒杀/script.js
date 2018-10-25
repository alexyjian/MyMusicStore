function updateTime() {
    //秒杀结束的时间
    var endtime = new Date('2018/10/25,12：00：00');
    //取当前时间
    var currentTIme = new Date();
    //计算剩余的时间，用秒作为单位
    var leftSsecond = parseInt((endtime.getTime() - currentTime.getTime())/1000);
    //计算剩余小时
    h = parseInt(leftSsecond / 3600);
    //计算剩余分钟
    m = parseInt(leftSsecond / 60 % 60);
     //计算剩余秒
    s = parseInt(leftSsecond % 60);
    //调整
    
}