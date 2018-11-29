//为页面加载键盘事件
window.onload=function(){
    document.body.onkeyup=function(evt){
        //定义小球的步长
        var step = 10;
        //获取球台和小球的元素
        var box = document.getElementById('box');
        var ball = document.getElementById('ball');
        //获取小球相对于球台DIV左侧和顶部的距离
        // var left= parseInt(ball.style.left)    
        // var top = parseInt(ball.style.top)
        
        // offsetLeft = left+margin
        // offsetTop = top+margin
        var left=ball.offsetLeft;
        var top = ball.offsetTop;
        console.log('球的出始位置：'+left+','+top);

        //获取球桌的高和宽
        var box_width=box.offsetWidth;
        var box_height = box.offsetHeight;
        console.log('球桌的高和宽：'+box_width+','+box_height);

        //小球的高和宽
        var ball_width = ball.width;
        var ball_height = ball.height;
        console,log('球的高和宽'+ball_width+','+ball_height);

        //小球距球桌左侧和顶部的最大距离
        var y_max = box_width - ball_width -step;
        var y_max = box_height - ball_heigth - step;
        console.log('x,y最大距离'+x_max +','+y_max);

        //创造键盘事件的对象
        var e=evt ? evt:window.event;
        //左键37 
        if(e.keyCode == 37&& (left-10)>step){
            ball.style.left=left-step+'px';
        }
        //右键39
        if(e.keyCode == 39&& left <= (x_max-20)){
            ball.style.left=left+step+'px';
        }
        //上键38
        if(e.keyCode == 38&& (top-10)>step){
            ball.style.top=top-step+'px';
        }

        if(e.keyCode == 40&& top<=(y_max-19)){
            ball.style.top=top+step+'px';
        }

    }
}