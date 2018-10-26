//W:87,A:65,S:83,D:68

window.onload = function () {
    var player = document.getElementById('bal');
    var move = 11;

    var t = 1,
        l = 1;

    document.onkeydown = function (event) {
        event = event ? event : window.event;
        var toppos = player.offsetTop;
        var leftpos = player.offsetLeft;
        if(toppos<=0||toppos>=236||leftpos<=0||leftpos>=441){
            
            alert('game over!');
            location.reload();
            return;
        }
        console.log(leftpos);
        if (event.keyCode == "87") {
            t -= 5;
            player.style.top = t + 'px';
        } else if (event.keyCode == "65") {
            l -= 5;
            player.style.left = l + 'px';
        } else if (event.keyCode == "83") {
            t += 5;
            player.style.top = t + 'px';
        } else if (event.keyCode == "68") {
            l += 5;
            player.style.left = l + 'px';
        }

    }

};