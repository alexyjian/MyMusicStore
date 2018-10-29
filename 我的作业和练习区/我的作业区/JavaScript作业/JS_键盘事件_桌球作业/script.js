var t = 50;
var r = 50;
window.onload = function () {
    document.body.onkeydown = function (evt) {
        var e = evt ? evt : window.event;

        //left  
        if (e.keyCode == 37) {
            r = r - 10;
            var let = document.getElementById('img');
            let.style.position = 'relative';
            let.style.left = r + 'px';
            if (r <= 10) {
                r = 10;
            }
        }
        //top  
        if (e.keyCode == 38) {
            t = t - 10;
            var let = document.getElementById('img');
            let.style.position = 'relative';
            let.style.top = t + 'px';
            if (t <= 10) {
                t = 10;
            }
        }
        //right 
        if (e.keyCode == 39) {
            r = r + 10;
            var let = document.getElementById('img');
            let.style.position = 'relative';
            let.style.left = r + 'px';           
            if (r >= 330) {
                r = 330;
            }
        }
        //botom 
        if (e.keyCode == 40) {
            t = t + 10;
            var let = document.getElementById('img');
            let.style.position = 'relative';
            let.style.top = t + 'px';
            if (t >= 160) {
                t = 165;
            }
        }


    }
}










