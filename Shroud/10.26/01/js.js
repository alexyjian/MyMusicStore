//W:87,A:65,S:83,D:68

window.onload = function () {
    var player = document.getElementById('bal');
    var move = 11;
    var toppos=player.offsetTop;
    var leftpos=player.offsetLeft;
    var t=1,l=1;
    
    document.onkeydown = function (event) {
        event = event ? event : window.event;
        
        if (event.keyCode == "87") {   
            t-=5;      
            player.style.top=t+'px';
        }else if(event.keyCode == "65"){
            l-=5;      
            player.style.left=l+'px';
            player.style.left='';
        }else if(event.keyCode == "83"){
            t+=5;      
            player.style.top=t+'px';
        }else if(event.keyCode == "68"){
            l+=5;      
            player.style.left=l+'px';
        }

    }
    
}