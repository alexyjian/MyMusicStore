window.onload = function() {
    document.body.onkeydown = function(evt) {
        var e = evt ? evt : window.event;
        var ball = document.getElementById("img");
        var x = ball.offsetLeft;
        var y = ball.offsetTop;
        //left
        if(e.keyCode == 37) {
            ball.style.left = x - 10 + "px"
        }
        
        //up
        if(e.keyCode == 38){
            ball.style.top = y - 10 + "px"
        }

        //right
        if(e.keyCode == 39){
            ball.style.left = x + 10 + "px"
        }

        //down
        if(e.keyCode == 40) {
            ball.style.top = y + 10 + "px"
        }
    }
}