function updateTime() {
	// 描述结束的时间
	var endtime = new Date('2018/10/26,11:25:00');

	// 取当前的时间
	var currentTime = new Date();
	// 计算剩余的时间,用秒作为单位
	var leftSecond = parseInt((endtime.getTime() - currentTime.getTime()) / 1000);
	// 计算剩余小时
	h = parseInt(leftSecond / 3600);
	//计算剩余的分钟
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

	document.getElementById('hour').innerHTML = h;
	document.getElementById('minute').innerHTML = m;
	document.getElementById('second').innerHTML = s;

	//秒杀结束的操作
	if(leftSecond<=0){
		
		
		document.getElementById("end").style.display='block';
		clearInterval(couptDown);
		
	}
	

}

var couptDown = setInterval(updateTime, 1000);