function updateTime(){
    //秒杀结束的时间
    var endTime = new Date('2018/10/25,12:10:00');
    //取当前时间
    var currentTime = new Date();
    //计算剩余的时间
    var leftSecond = parseInt((endTime.getTime()-currentTime.getTime())/1000);
    //计算剩余小时
    h = parseInt(leftSecond/3600);
    //计算剩余分钟
    m = parseInt(leftSecond/60%60);
    //计算剩余分钟
    s = parseInt(leftSecond%60);
    //调整格式
    if(h<10)
        h='0'+h;

    if(m<10&&m>=0)
        m="0"+m;

    else if(m<0)
        m='00';

    if(s<10&&s>=0)
        s="0"+s;
        
    else if(s<0)
        s='00';

    document.getElementById('hour').innerHTML = h;
    document.getElementById('minute').innerHTML = m;
    document.getElementById('second').innerHTML = s;

    var endbox = document.getElementById('end-box');
    if(leftSecond>0){
        endbox.style.display = 'none';
    }
    else
    {
        endbox.style.display = 'block';
    }

}
    //秒杀结束的操作
    var countDown = setInterval(updateTime,1000);
