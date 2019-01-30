/**
 * Created by Steve on 2015/2/8.
 */
var test = document.getElementById("test");
var str = "str";

var c = document.getElementById("c");
var ctx = c.getContext("2d");
/** 这里控制显示的宽度和高度，且涵盖所有浏览器 */
c.width = window.innerWidth
    || document.documentElement.clientWidth
    || document.body.clientWidth;
c.height = window.innerHeight
    || document.documentElement.clientHeight
    || document.body.clientHeight;
//c.width = 300;
//c.height = 300;

//ctx.fillStyle = "1cba9c";
//ctx.fillRect(0,0,100,100);
//ctx.fillStyle = "ecb69c";
//ctx.fillText("雨滴",10,90);

var chinese = "知否";
chinese = chinese.split("");

var fsize = 20;
    columns = c.width / fsize;

var drops=[];
for(var x=0;x<columns;x++) {
    drops[x] = 0;
}

function draw(){
    ctx.fillStyle="rgba(0,0,0,0.09)";
    ctx.fillRect(0,0, c.width, c.height);

    ctx.fillStyle="#0f0";
    ctx.font = fsize + "px arial";// arial is font.

    for(var i=0;i<drops.length;i++){
        var text = chinese[Math.floor(Math.random()*chinese.length)];
        ctx.fillText(text,i*fsize,drops[i]*fsize);

        drops[i]++;
        if(drops[i]*fsize > c.height && Math.random() > 0.9){
            drops[i] = 0;
        }

        str = drops[i]+",";
    }
    test.innerText = columns + " , i:" + str;// 测试数据

}
/// draw();
var intervalId = setInterval(draw,50);// 这里修改控制速度

// 测试效果开始/暂停
function operateAnimation(objBtn){
    var operate = document.getElementById("operate");

    if(objBtn.value == "开始"){
        objBtn.value = "暂停";
        intervalId = setInterval(draw,30);
    }else{
        objBtn.value = "开始";
        clearInterval(intervalId);
    }
    return false;
}
