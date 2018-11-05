;
window.onload = function () {
    var imgobj = document.getElementById('img');
    var up = document.getElementById('up');
    var down = document.getElementById('down');
    var step = 10;
    var time;
    up.onmouseover = function () {
        time = setInterval(function (){
            if (step - 10 <= -1100)return;
            step -= 10;
            imgobj.style.top = step + 'px';
            console.log(imgobj.offsetTop);
        }, 100)
    }
    up.onmouseout = function () {
        clearInterval(time)
    }
    down.onmouseover = function () {
        time1 = setInterval(function () {
            if(step + 10>0)return;
            step += 10;
            imgobj.style.top = step + 'px';
            
        }, 100)
    }
    down.onmouseout = function () {
        clearInterval(time1)
    }
}